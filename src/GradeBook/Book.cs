using System;
using System.Collections.Generic;

namespace GradeBook

{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class Book // public is like JS' "export"
    {   
        public Book(string name)
        // This is known as a constructor method
        // This is ran upon instantiation
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(char letter)
        {
            switch(letter)
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
                case 'D':
                    AddGrade(60);
                    break;
                case 'F':
                    AddGrade(50);
                    break;
                
                default:
                    AddGrade(0);
                    break;                
            }
        }
        
    //  [export][return type][method name](){}
        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            // foreach(double grade in grades)
            // {
            //     result.High = Math.Max(grade, result.High);
            //     result.Low = Math.Min(grade, result.Low);
            //     result.Average += grade;
            // }

            for(var index = 0; index < grades.Count; index += 1)
            {
                if(grades[index] == 42.1)
                {
                    break; // or `continue` here, if you only 
                           // want to skip this iteration
                           // Can also use `goto e.g. done` which will
                           // direct the compiler to `done:` somewhere
                           // else in the code, but it's ill-advised.
                }

                result.High = Math.Max(grades[index], result.High);
                result.Low = Math.Min(grades[index], result.Low);
                result.Average += grades[index];
            }

            // var index = 0;

            // do
            // {
            //     result.High = Math.Max(grades[index], result.High);
            //     result.Low = Math.Min(grades[index], result.Low);
            //     result.Average += grades[index];

            //     index++;
            // } while(index < grades.Count);

            result.Average /= grades.Count;

            switch(result.Average)
            {
                case var d when d > 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d > 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d > 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d > 60.0:
                    result.Letter = 'D';
                    break;
                
                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
        }

        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public event GradeAddedDelegate GradeAdded;
        // `event` keyword adds additional restrictions and capabilities
        // that make the delegate safer to use

        public List<double> grades;
        public string Name
        {
           get; 
           set;
        }

        public const string CATEGORY = "Science";
    }
}