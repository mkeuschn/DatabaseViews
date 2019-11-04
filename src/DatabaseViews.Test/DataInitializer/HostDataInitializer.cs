using DatabaseViews.DataAccessLayer.Context;
using DatabaseViews.DataAccessLayer.Model;
using DatabaseViews.Test.Common;

namespace DatabaseViews.Test.DataInitializer
{
    public class HostDataInitializer : IDataInitializer
    {
        public const string HostOneName = "HostOne";

        public void Initialize(CloudContext context)
        {
            context.Hosts.Add(new Host
            {
                Name = HostOneName,
                UserPersonnelNumber = UserDataInitializer.UserOneLoginName
            });
        }
    }
}