namespace Interfaces
{
    public class Subject
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Code { get; private set; }

        public int Credit { get; private set; }

        public int RecommendedSemester { get; private set; }

        public string ResponsibleProfessor { get; private set; }

        public Subject(int id, string name, string code, int credit, int recommendedSemester, string responsibleProfessor)
        {
            Id = id;
            Name = name;
            Code = code;
            Credit = credit;
            RecommendedSemester = recommendedSemester;
            ResponsibleProfessor = responsibleProfessor;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", Name, Code);
        }
    }
}
