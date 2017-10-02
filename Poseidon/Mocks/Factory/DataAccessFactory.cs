namespace Mocks.Factory
{
    public static class DataAccessFactory
    {
        // TODO should be made private
        public static bool Mocking = true;

        public static Interfaces.ISubjectManager GetDataAccess()
        {
            if (Mocking)
            {
                return new MockSubjectManager();
            }
            else
            {
                return new WebApiSubjectManager();
            }
        }
    }
}