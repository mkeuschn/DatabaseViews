using DatabaseViews.DataAccessLayer.Context;
using DatabaseViews.DataAccessLayer.Model;
using DatabaseViews.Test.Common;

namespace DatabaseViews.Test.DataInitializer
{
    public class UserDataInitializer : IDataInitializer
    {
        public const string UserOneLoginName = "UserOne";
        public const string UserOnePersonnelNumber = "UserOne12345";

        public void Initialize(CloudContext context)
        {
            context.User.Add(new User
            {
                LoginName = UserOneLoginName,
                PersonnelNumber = UserOnePersonnelNumber
            });
        }
    }
}