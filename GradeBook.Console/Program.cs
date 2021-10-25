using System.IO;

namespace GradeBook
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Natasa Prematarova Student Grades");
            book.GradeAddedEvent += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"{book.Name}");
            Console.WriteLine($"The lowest grade from exams is {stats.Low.ToString("N3")}");
            Console.WriteLine($"The highest grade from exams is {stats.High.ToString("N3")}");
            Console.WriteLine($"The average grade from exams is {stats.Average.ToString("N3")}");
            Console.WriteLine($"The letter grade of the average grade is {stats.Letter}");
        }

        private static void EnterGrades(IBook inMemoryBook)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or enter 'q' to quit.");
                var input = Console.ReadLine();
                if (input.ToLower() == "q")
                    break;

                try
                {
                    var grade = double.Parse(input);
                    inMemoryBook.AddGrade(grade);
                }
                catch (FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                finally
                {
                    Console.WriteLine("**********************************************");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("A grade was added");
        }
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAddedEvent != null)
                {
                    GradeAddedEvent(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }

        public override event GradeAddedDelegate GradeAddedEvent;
    }
}
