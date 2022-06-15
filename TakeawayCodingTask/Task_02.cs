using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeawayCodingTask
{
    public class Task_02
    {
        public class TestScore
        {
            public string StudentName { get; set; } = string.Empty;
            public byte Score { get; set; }
        }

        /// <summary>
        /// The HonorRoll method will return the names of students who score 90 or higher in either subject, or 80 or higher in both subjects
        /// Both sets of scores have already been sorted by StudentName
        /// For this exercise, don't worry about the size of the lists or the time taken to run.
        /// </summary>
        /// <param name="maths"></param>
        /// <param name="science"></param>
        /// <returns></returns>
        public IEnumerable<string> HonorRoll(IEnumerable<TestScore> maths, IEnumerable<TestScore> science)
        {

        }
    }
}
