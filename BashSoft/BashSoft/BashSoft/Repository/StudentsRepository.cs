using BashSoft.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using BashSoft.Data;

namespace BashSoft
{
    public static class StudentsRepository
    {
        public static bool IsDataInitialized = false;
        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;
        public static bool isDataInitialized = false;

        private static void ReadData(string fileName)
        {
            string path = SessionData.currentPath + "\\" + fileName;

            if (File.Exists(path))
            {
                string pattern = @"([A-Z][a-zA-Z#+]*_[A-Z][a-z]{2}_\d{4})\s+([A-Z][a-z]{0,3}\d{2}_\d{2,4})\s+(\d+)";
                Regex rgx = new Regex(pattern);
                string[] allInputLines = File.ReadAllLines(path);

                for (int line = 0; line < allInputLines.Length; line++)
                {
                    if (!string.IsNullOrEmpty(allInputLines[line]) && rgx.IsMatch(allInputLines[line]))
                    {
                        Match currentMatch = rgx.Match(allInputLines[line]);
                        string course = currentMatch.Groups[1].Value;
                        string student = currentMatch.Groups[2].Value;
                        bool hasParsedScore = int.TryParse(currentMatch.Groups[3].Value, out int mark);

                        if (hasParsedScore && mark >= 0 && mark <= 100)
                        {
                            if (studentsByCourse.ContainsKey(course))
                            {
                                if (studentsByCourse[course].ContainsKey(student))
                                {
                                    studentsByCourse[course][student].Add(mark);
                                }
                                else
                                {
                                    studentsByCourse[course].Add(student, new List<int>() { mark });
                                }
                            }
                            else
                            {
                                studentsByCourse.Add(course, new Dictionary<string, List<int>> { { student, new List<int>() { mark } } });
                            }
                        }
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }

            isDataInitialized = true;

            OutputWriter.WriteMessageOnNewLine("Data read!");
        }

        public static bool IsQueryForCoursePossible(string courseName)
        {
            if (IsDataInitialized)
            {
                if (studentsByCourse.ContainsKey(courseName))
                {
                    return true;
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
                }
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }
            return false;
        }

        public static bool IsQueryForStudentPossiblе(string courseName, string studentsUserName)
        {
            if (IsQueryForCoursePossible(courseName) && studentsByCourse[courseName].ContainsKey(studentsUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
            }
            return false;
        }
        public static void GetStudentScoresFromCourse(string courseName, string userName)
        {
            if (IsQueryForStudentPossiblе(courseName, userName))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string, List<int>>(userName, studentsByCourse[courseName][userName]));
            }
        }

        public static void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}.");
                foreach (var studentsMarks in studentsByCourse[courseName])
                {
                    OutputWriter.PrintStudent(studentsMarks);
                }
            }
        }

        internal static void InitializeData(string fileName)
        {
            if (!IsDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");
                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData();
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.ExeptiDataAlreadyInitialised);
            }
        }
        public static void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = studentsByCourse[courseName].Count;
                }

                RepositoryFilters.FilterAndTake(studentsByCourse[courseName], givenFilter, studentsToTake.Value);
            }
        }
        public static void OrderAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = studentsByCourse[courseName].Count;
                }

                RepositorySorters.OrderAndTake(studentsByCourse[courseName], givenFilter, studentsToTake.Value);
            }
        }
    }
}
