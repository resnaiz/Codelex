namespace exercise_12
{
    interface ITestpaper
    {
        string Subject { get; set; }
        string[] MarkScheme { get; set; }
        string PassMark { get; set; }
    }

    class Testpaper : ITestpaper
    {
        public string Subject { set; get; }
        public string[] MarkScheme { get; set; }
        public string PassMark { set; get; }
        
        public Testpaper(string subject, string[] markScheme, string passMark)
        {
            Subject = subject;
            MarkScheme = markScheme;
            PassMark = passMark;
        }
    }


}
