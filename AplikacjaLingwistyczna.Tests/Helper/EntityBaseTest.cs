using Model.Context;

namespace AplikacjaLingwistyczna.Tests.Helper
{
    public class EntityBaseTest
    {
        protected EfContext Context;
        protected const string TestDb = "TestDb";

        public EntityBaseTest()
        {
            Context = new EfContext(TestDb);
        }
    }
}
