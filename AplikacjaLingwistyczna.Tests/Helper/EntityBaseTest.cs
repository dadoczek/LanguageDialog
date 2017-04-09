using Model.Context;

namespace AplikacjaLingwistyczna.Tests.Helper
{
    public class EntityBaseTest
    {
        protected EfContext Context;
        protected const string TestDb = "TestDb";
        protected const string TestDb2 = "TestDbWithData";

        public EntityBaseTest(bool withData = false)
        {
            Context = withData ? new EfContext(TestDb2): new EfContext(TestDb);
        }
    }
}
