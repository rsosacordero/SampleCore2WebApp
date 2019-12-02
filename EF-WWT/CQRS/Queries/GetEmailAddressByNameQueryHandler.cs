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
    public class GetEmailAddressByNameQuery : IRequest<List<Contact>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class GetEmailAddressByNameQueryHandler : IRequestHandler<GetEmailAddressByNameQuery, List<Contact>>
    {
        private readonly EFWWTContext _context;
        private readonly IMapper<List<GetEmailAddressByName>, List<Contact>> _mapper;
        public GetEmailAddressByNameQueryHandler(EFWWTContext context, IMapper<List<GetEmailAddressByName>, List<Contact>> mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Contact>> Handle(GetEmailAddressByNameQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Query<GetEmailAddressByName>().FromSql("EXEC dbo.GetEmailAddressByName @FirstName={0}, @LastName={1}", request.FirstName, request.LastName).ToListAsync();

            var mappedResult = _mapper.MapDestination(result); 

            return mappedResult;
        }
    }
}
