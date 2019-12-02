using EF_WWT.Data;
using EF_WWT.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EF_WWT.CQRS.Commands
{
    public class SavePersonEmailCommand : IRequest
    {
        public Guid PersonIdentifier { get; set; }
        public string EmailAddress { get; set; }
    }


    public class SavePersonEmailCommandHandler : AsyncRequestHandler<SavePersonEmailCommand>
    {
        private readonly EFWWTContext _context;
        public SavePersonEmailCommandHandler(EFWWTContext context)
        {
            _context = context;
        }

        protected async override Task Handle(SavePersonEmailCommand request, CancellationToken cancellationToken)
        {
            var person = _context.Person.AsNoTracking()
                .Include(c => c.EmailAddress)
                .FirstOrDefault(c => c.Rowguid == request.PersonIdentifier);

            if (person == null)
            {
                throw new ResourceNotFoundException($"Query for {nameof(SavePersonEmailCommand)} returned no results: {JsonConvert.SerializeObject(request, Formatting.Indented)}");
            }

            var email = person.EmailAddress.FirstOrDefault();

            if (email == null)
            {
                person.EmailAddress.Add(new EmailAddress()
                {
                    EmailAddress1 = request.EmailAddress,
                    ModifiedDate = DateTime.UtcNow
                });
            }
            else
            {
                email.EmailAddress1 = request.EmailAddress;
                email.ModifiedDate = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
        }

        public async Task TestHandle(SavePersonEmailCommand request, CancellationToken cancellationToken)
        {
            await this.Handle(request, cancellationToken);
        }
    }
}
