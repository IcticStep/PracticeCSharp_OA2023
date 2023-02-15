using Common;
using Common.DataSave;

namespace Task3_3;

public static class Program
{
    private static readonly PersistantRepository<StudentGrades> _repository = new("students.txt");

    public static void Main()
    {
        Inputter.Init();
        Outputter.Init();
    }
}