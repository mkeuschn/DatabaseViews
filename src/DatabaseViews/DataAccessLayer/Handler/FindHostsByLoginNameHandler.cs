using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DatabaseViews.DataAccessLayer.Context;
using DatabaseViews.DataAccessLayer.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DatabaseViews.DataAccessLayer.Queries
{
    public class FindHostsByLoginNameHandler : IRequestHandler<FindHostsByLoginNameQuery, IEnumerable<HostDto>>
    {
        private readonly CloudContext _context;

        public FindHostsByLoginNameHandler(CloudContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<HostDto>> Handle(FindHostsByLoginNameQuery request, CancellationToken cancellationToken)
        {
            var result = await (from h in _context.Hosts
                    join u in _context.User on h.UserPersonnelNumber equals u.PersonnelNumber
                    where u.LoginName == request.LoginName
                    select h)
                .ToListAsync(cancellationToken);

            return result.Select(x => new HostDto
            {
                Name = x.Name,
                UserPersonnelNumber = x.UserPersonnelNumber
            });
        }
    }
}