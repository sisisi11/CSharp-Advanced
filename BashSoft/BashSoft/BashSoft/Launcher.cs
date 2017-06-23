using System;

namespace BashSoft
{
    public class Launcher
    {
        static void Main()
        {
            IOManager.TraverseDirectory(@"C:\Users\Acasa\Source\Repos\CSharp-Advanced\BashSoft");
            OutputWriter.WriteEmptyLine();

            StudentsRepository.InitializeData();
            StudentsRepository.GetStudentScoresFromCourse("Unity", "Ivan");
        }
    }
}
