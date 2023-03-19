using System;

namespace exercise_12
{
    interface IStudent
    {
        string[] TestsTaken { get; set; }
        void TakeTest(ITestpaper paper, string[] answers);
    }

    class Student :IStudent
    {
        public string[] TestsTaken { get; set; }

        public Student()
        {
            TestsTaken = new string[] { "No tests taken" };
        }

        public void TakeTest(ITestpaper paper, string[] answers)
        {
            int correctRes = 0;

            for (int i = 0; i < paper.MarkScheme.Length; i++)
            {
                if (paper.MarkScheme[i] == answers[i])
                {
                    correctRes++;
                }
            }

            double correctResPercent = (double)correctRes / paper.MarkScheme.Length * 100;

            string result = (decimal)correctResPercent >= Decimal.Parse(paper.PassMark.Trim('%')) ? "Passed!" : "Failed!";
            string resultFormat = $"{paper.Subject}: {result} {string.Format("{0:F0}", correctResPercent)}%";

            if (TestsTaken[0] == "No tests taken")
            {
                TestsTaken[0] = resultFormat;
            }
            else
            {
                string[] newTemp = TestsTaken;
                Array.Resize(ref newTemp, TestsTaken.Length + 1);
                newTemp[TestsTaken.Length] = resultFormat;
                TestsTaken = newTemp;
            }
        }
    }
}
