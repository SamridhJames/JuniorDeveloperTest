using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        }
    }
}
