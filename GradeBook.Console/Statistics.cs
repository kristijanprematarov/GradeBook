namespace GradeBook
{
    public class Statistics
    {
        public double Average;
        public double Low;
        public double High;
        public char Letter;

        public Statistics()
        {
            Average = 0.0;
            Low = double.MinValue;
            High = double.MaxValue;
        }
    }
}