using System.Collections.Generic;
using DatabaseViews.DataAccessLayer.Dto;
using MediatR;

namespace DatabaseViews.DataAccessLayer.Queries
{
    public class FindHostsByLoginNameQuery : IRequest<IEnumerable<HostDto>>
    {
        public string LoginName { get; set; }
    }
}