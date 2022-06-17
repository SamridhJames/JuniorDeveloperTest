using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace TakeawayCodingTask
{
    public class Task_03
    {
        public class TestScore
        {
            public string StudentName { get; set; } = string.Empty;
            public byte Score { get; set; }
        }

        /// <summary>
        /// The HonorRoll method will return the names of students who score 90 or higher in either subject, or 80 or higher in both subjects
        /// Both sets of scores have already been sorted by StudentName
        /// For this exercise, assume both sequences are VERY large, write the code so it runs as efficiently as possible. 
        /// </summary>
        /// <param name="maths"></param>
        /// <param name="science"></param>
        /// <returns></returns>
        public IEnumerable<string> HonorRoll(IEnumerable<TestScore> maths, IEnumerable<TestScore> science)
        {
            var honorStudents = new ConcurrentDictionary<string, int>();
            var potentialHonorStudents = new ConcurrentDictionary<string, int>();

            Parallel.ForEach(maths, student => {
                if (student.Score >= 90)
                {
                    honorStudents.TryAdd(student.StudentName, student.Score);
                }
                else if (student.Score >= 80 && student.Score < 90)
                {
                    potentialHonorStudents.TryAdd(student.StudentName, student.Score);
                }
            });

            Parallel.ForEach(science, student => {
                if (student.Score >= 90 && !honorStudents.ContainsKey(student.StudentName))
                {
                    honorStudents.TryAdd(student.StudentName, student.Score);
                }
                else if (student.Score >= 80 &&
                           potentialHonorStudents.ContainsKey(student.StudentName))
                {
                    honorStudents.TryAdd(student.StudentName, student.Score);
                }
            });

            return honorStudents.Keys;
        }
    }
}
