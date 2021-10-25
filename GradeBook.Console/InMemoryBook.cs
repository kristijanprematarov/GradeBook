using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs eventArgs);

    public class NamedObject
    {
        public string Name { get; set; }

        public NamedObject(string name)
        {
            Name = name;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        public string Name { get; }//atleast getter
        event GradeAddedDelegate GradeAddedEvent;
    }

    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
        public abstract event GradeAddedDelegate GradeAddedEvent;
    }

    public class InMemoryBook : Book
    {
        private List<double> _grades;
        public const string CATEGORY = "Science";
        //public string Name { get; set; }

        public InMemoryBook(string name) : base(name)
        {
            Name = name;
            _grades = new List<double>();
        }

        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                default:
                    AddGrade(0);
                    break;
            }
        }

        public override void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                _grades.Add(grade);
                if (GradeAddedEvent != null)
                {
                    GradeAddedEvent(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}, {nameof(grade)} must be between 0 and 100");
            }
        }

        public override event GradeAddedDelegate GradeAddedEvent;

        /// <summary>
        /// Returns object of type Statistics containing values for Lowest,Highest and Average grade.
        /// </summary>
        /// <returns></returns>
        public override Statistics GetStatistics()
        {
            var result = new Statistics();



            for (var index = 0; index < _grades.Count; index += 1)
            {
                result.Low = Math.Min(_grades[index], result.Low);
                result.High = Math.Min(_grades[index], result.High);
                result.Average += _grades[index];
            }

            result.Average /= _grades.Count;

            switch (result.Average)
            {
                case var grade when grade >= 90.0:
                    result.Letter = 'A';
                    break;

                case var grade when grade >= 80.0:
                    result.Letter = 'B';
                    break;

                case var grade when grade >= 70.0:
                    result.Letter = 'C';
                    break;

                case var grade when grade >= 60.0:
                    result.Letter = 'D';
                    break;

                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
        }
    }
}