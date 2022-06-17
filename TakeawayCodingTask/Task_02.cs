using System.Collections.Generic;
using System.Linq;

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
            var mathScores = maths.ToList();
            var scienceScores = science.ToList();

            var studentNames = mathScores.Where(x => x.Score >= 80).Select(x => x.StudentName).
                Intersect(scienceScores.Where(x => x.Score >= 80).Select(x => x.StudentName)).ToList();

            mathScores.Where(x => x.Score >= 90).Select(x => x.StudentName).ToList().ForEach(x => {
                if (!studentNames.Contains(x)) studentNames.Add(x);
            }
            );
            scienceScores.Where(x => x.Score >= 90).Select(x => x.StudentName).ToList().ForEach(x => {
                if (!studentNames.Contains(x)) studentNames.Add(x);
            }
            );
            return studentNames;
        }
    }
}
