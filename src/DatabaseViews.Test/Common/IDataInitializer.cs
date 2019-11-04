using DatabaseViews.DataAccessLayer.Context;

namespace DatabaseViews.Test.Common
{
    public interface IDataInitializer
    {
        void Initialize(CloudContext context);
    }
}