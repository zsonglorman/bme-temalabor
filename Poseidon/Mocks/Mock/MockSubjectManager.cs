using System;
using System.Collections.Generic;
using Interfaces;

namespace Mocks.Factory
{
    class MockSubjectManager : ISubjectManager
    {
        public List<Subject> GetSubjects()
        {
            return new List<Subject>()
            {
                new Subject(1, "Teszt tárgy", "ABC123", 4, 1, "Teszt Elek"),
                new Subject(2, "Elgondolkodtató tárgy", "DEF456", 5, 2, "Prof János")
            };
        }
    }
}