namespace Mocks.Factory
{
    public static class SubjectManagerFactory
    {
        // TODO should be made private
        public static bool Mocking = true;

        public static Interfaces.ISubjectManager GetSubjectManager()
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