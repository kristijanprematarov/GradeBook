namespace GradeBook
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Natasa Prematarova GradeBook");
            book.AddGrade(68.6);
            book.AddGrade(75.4);
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            var stats = book.GetStatistics();
            Console.WriteLine($"The lowest grade is {stats.Low.ToString("N3")}");
            Console.WriteLine($"The highest grade is {stats.High.ToString("N3")}");
            Console.WriteLine($"The average grade is {stats.Average.ToString("N3")}");
        }
    }
}
