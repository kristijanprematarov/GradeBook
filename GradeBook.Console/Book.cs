using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    public class Book
    {
        private List<double> _grades;
        public string Name;

        public Book(string name)
        {
            Name = name;
            _grades = new List<double>();
        }

        public void AddGrade(double grade)
        {
            _grades.Add(grade);
        }

        /// <summary>
        /// Returns object of type Statistics containing values for Lowest,Highest and Average grade.
        /// </summary>
        /// <returns></returns>
        public Statistics GetStatistics()
        {
            var result = new Statistics();

            result.Low = _grades.Min();
            result.High = _grades.Max();
            result.Average = _grades.Average();

            return result;
        }
    }
}