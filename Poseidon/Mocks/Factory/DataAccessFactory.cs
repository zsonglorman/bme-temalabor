namespace Mocks.Factory
{
    public static class DataAccessFactory
    {
        // TODO should be made private
        public static bool Mocking = true;

        public static DataAccessMode GetDataAccess()
        {
            if (Mocking)
            {
                return new MockingDataAccess();
            }
            else
            {
                return new WebApiDataAccess();
            }
        }
    }
}