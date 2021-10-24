using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var grades = new List<double>() { 12.7, 10.3, 6.11, 4.1 };
            grades.Add(56.1);

            var result = grades.Average();
            Console.WriteLine($"The average grade is {result.ToString("N3")}");
        }
    }
}
