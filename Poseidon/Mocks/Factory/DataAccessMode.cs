using System.Collections.Generic;
using Interfaces;

namespace Mocks.Factory
{
    public abstract class DataAccessMode : ISubject
    {
        public abstract List<Subject> GetSubjects();
    }
}
