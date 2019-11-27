using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EF_WWT.Data;
using EF_WWT.Domain;
using EF_WWT.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EF_WWT.CQRS.Queries
{
    public class GetContactByNameQuery : IRequest<List<Contact>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class GetContactByNameQueryHandler : IRequestHandler<GetContactByNameQuery, List<Contact>>
    {
        private readonly EFWWTContext _context;
        private readonly IMapper<List<GetContactByName>, List<Contact>> _mapper;
        public GetContactByNameQueryHandler(EFWWTContext context, IMapper<List<GetContactByName>, List<Contact>> mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Contact>> Handle(GetContactByNameQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Query<GetContactByName>().FromSql("EXEC dbo.GetContactByName @FirstName={0}, @LastName={1}", request.FirstName, request.LastName).ToListAsync();

            var mappedResult = _mapper.MapDestination(result); 

            return mappedResult;
        }
    }
}
