using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Hospital
{
    class Hospital
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();
            var departmentInfo = new Dictionary<string, Queue<string>>();
            var doctorInfo = new Dictionary<string, List<string>>();


            while (inputLine != "Output")
            {
                var inputArgs = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var department = inputArgs[0];
                var nameDoctor = inputArgs[1] + inputArgs[2];
                var patients = inputArgs[3];


                if (!departmentInfo.ContainsKey(department))
                {
                    departmentInfo.Add(department, new Queue<string>(new[] { patients }));
                }
                else
                {
                    if (departmentInfo[department].Count < 60)
                    {

                        departmentInfo[department].Enqueue(patients);
                    }
                }

                if (!doctorInfo.ContainsKey(nameDoctor))
                {
                    doctorInfo.Add(nameDoctor, new List<string>(new[] { patients }));
                }
                else
                {
                    doctorInfo[nameDoctor].Add(patients);
                }

                inputLine = Console.ReadLine();
            }
            Console.WriteLine();
            var outputCommand = Console.ReadLine();
            while (outputCommand != "End")

            {
                var outPutArgs = outputCommand.Split(' ');
                if (departmentInfo.ContainsKey(outputCommand))
                {
                    var depName = outPutArgs[0];
                    Print(departmentInfo, depName);
                }
                else if (outPutArgs.Length > 1)
                {

                    var depName = outPutArgs[0];
                    int n;
                    bool isNum = int.TryParse(outPutArgs[1], out n);

                    if (departmentInfo.ContainsKey(outPutArgs[0]) && isNum)
                    {
                        int roomNum = int.Parse(outPutArgs[1]);
                        PrintDepAndRooms(departmentInfo, roomNum, depName);
                    }

                    else if (doctorInfo.ContainsKey(outPutArgs[0] + outPutArgs[1]))
                    {
                        var docName = outPutArgs[0] +  outPutArgs[1];
                        PrintDoctor(doctorInfo, docName);
                    }
                }
                outputCommand = Console.ReadLine();
            }
        }
        private static void PrintDepAndRooms(Dictionary<string, Queue<string>> departmentInfo, int roomNum, string depName)
        {
            foreach (var department in departmentInfo)
            {
                if (department.Key == depName)
                {
                    var totalRoom = 1;
                    var patients = department.Value.ToList();
                    var namePatients = new List<string>();
                    if (department.Value.Count > 3)
                    {
                        totalRoom = department.Value.Count / 3;
                        if (totalRoom >= roomNum)
                        {
                            roomNum = roomNum * 3 - 1;
                            namePatients.Add(patients[roomNum]);
                            namePatients.Add(patients[roomNum - 1]);
                            namePatients.Add(patients[roomNum - 2]);
                        }
                        foreach (var namePatient in namePatients.OrderBy(n => n))
                        {
                            Console.WriteLine($"{namePatient}");
                        }
                    }
                    else
                    {
                        foreach (var pat in department.Value.OrderBy(n => n))
                        {
                            Console.WriteLine($"{pat}");
                        }
                    }
                }

            }
        }

        private static void PrintDoctor(Dictionary<string, List<string>> doctorInfo, string docName)
        {
            foreach (var patient in doctorInfo)
            {
                if (patient.Key == docName)
                {
                    foreach (var pat in patient.Value.OrderBy(n => n))
                    {

                        Console.WriteLine($"{pat}");
                    }
                }

            }
        }

        private static void Print(Dictionary<string, Queue<string>> departmentInfo, string depName)
        {
            foreach (var department in departmentInfo)
            {
                if (department.Key == depName)
                {
                    foreach (var pat in department.Value)
                    {
                        Console.WriteLine($"{pat}");
                    }
                }
            }
        }
    }
}
