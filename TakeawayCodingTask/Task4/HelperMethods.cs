using System.Collections.Generic;

namespace TakeawayCodingTask.Task4
{
    public class HelperMethods
    {
        public static Dictionary<string, string> RegexDict()
        {
            var regexDict = new Dictionary<string, string>()
            {
                {"Name", "^[\\p{L} \\.\\-\\'\\&]+$"},
                {"Address", "(?s).*"},
                {"PostCode", "(?s).*"},
                {"EmailAddress", "(?s).*"},
                {"PhoneNumber", "(?s).*"},
            };
            return regexDict;
        }

        public static void SetupStudentScoresForTask3(out List<Task_03.TestScore> mathStudentList, out List<Task_03.TestScore> scienceStudentList)
        {
            mathStudentList = new List<Task_03.TestScore>() {
                new Task_03.TestScore(){StudentName = "Amy", Score = 90},
                new Task_03.TestScore(){StudentName = "Bob", Score = 80},
                new Task_03.TestScore(){StudentName = "Carl", Score = 50},
                new Task_03.TestScore(){StudentName = "Dennis", Score = 50},
                new Task_03.TestScore(){StudentName = "Emily", Score = 80},
                new Task_03.TestScore(){StudentName = "Fiona", Score = 40},
                new Task_03.TestScore(){StudentName = "Gus", Score = 90},
                new Task_03.TestScore(){StudentName = "Harry", Score = 85},
                new Task_03.TestScore(){StudentName = "Ivana", Score = 85},
            };
            scienceStudentList = new List<Task_03.TestScore>() {
                new Task_03.TestScore(){StudentName = "Amy", Score = 90},
                new Task_03.TestScore(){StudentName = "Bob", Score = 80},
                new Task_03.TestScore(){StudentName = "Carl", Score = 50},
                new Task_03.TestScore(){StudentName = "Dennis", Score = 80},
                new Task_03.TestScore(){StudentName = "Emily", Score = 40},
                new Task_03.TestScore(){StudentName = "Fiona", Score = 90},
                new Task_03.TestScore(){StudentName = "Gus", Score = 40},
                new Task_03.TestScore(){StudentName = "Harry", Score = 89},
                new Task_03.TestScore(){StudentName = "Ivana", Score = 95},
            };
        }

        public static void SetupStudentScoresForTask2(out List<Task_02.TestScore> mathStudentList, out List<Task_02.TestScore> scienceStudentList)
        {
            mathStudentList = new List<Task_02.TestScore>() {
                new Task_02.TestScore(){StudentName = "Amy", Score = 90},
                new Task_02.TestScore(){StudentName = "Bob", Score = 80},
                new Task_02.TestScore(){StudentName = "Carl", Score = 50},
                new Task_02.TestScore(){StudentName = "Dennis", Score = 50},
                new Task_02.TestScore(){StudentName = "Emily", Score = 80},
                new Task_02.TestScore(){StudentName = "Fiona", Score = 40},
                new Task_02.TestScore(){StudentName = "Gus", Score = 90},
                new Task_02.TestScore(){StudentName = "Harry", Score = 85},
                new Task_02.TestScore(){StudentName = "Ivana", Score = 85},
            };
            scienceStudentList = new List<Task_02.TestScore>() {
                new Task_02.TestScore(){StudentName = "Amy", Score = 90},
                new Task_02.TestScore(){StudentName = "Bob", Score = 80},
                new Task_02.TestScore(){StudentName = "Carl", Score = 50},
                new Task_02.TestScore(){StudentName = "Dennis", Score = 80},
                new Task_02.TestScore(){StudentName = "Emily", Score = 40},
                new Task_02.TestScore(){StudentName = "Fiona", Score = 90},
                new Task_02.TestScore(){StudentName = "Gus", Score = 40},
                new Task_02.TestScore(){StudentName = "Harry", Score = 89},
                new Task_02.TestScore(){StudentName = "Ivana", Score = 95},
            };
        }
    }
}
