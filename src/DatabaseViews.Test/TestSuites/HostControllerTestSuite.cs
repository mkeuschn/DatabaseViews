using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using DatabaseViews.DataAccessLayer.Dto;
using DatabaseViews.DataAccessLayer.Queries;
using DatabaseViews.Test.Common;
using DatabaseViews.Test.DataInitializer;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace DatabaseViews.Test.TestSuites
{
    public class HostControllerTestSuite : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;

        public HostControllerTestSuite(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            // client must be created otherwise the server will not be initialized
            _client = factory.CreateClient();
        }

        [Fact]
        public void Test01()
        {
            IEnumerable<HostDto> hosts;

            using (var scope = _factory.Services.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

                hosts = mediator.Send(new FindHostsByLoginNameQuery{LoginName = UserDataInitializer.UserOneLoginName }).Result;
            }

            Assert.Equal(HostDataInitializer.HostOneName, hosts.First().Name);
        }
    }
}