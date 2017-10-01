namespace Mocks.Factory
{
    public static class DataAccessFactory
    {
        private static bool _mocking = true;

        public static DataAccessMode GetDataAccess()
        {
            if (_mocking)
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