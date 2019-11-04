using DatabaseViews.DataAccessLayer.Context;
using DatabaseViews.Test.Util;

namespace DatabaseViews.Test.Common
{
    public class DataInitializer
    {
        public static void Initialize(CloudContext db)
        {
            var dis = AssemblyUtil.GetAllDefaultConstructableConstructed<IDataInitializer>();
            foreach (var dataInitializer in dis)
            {
                dataInitializer.Initialize(db);
            }
            db.SaveChanges();
        }
    }
}