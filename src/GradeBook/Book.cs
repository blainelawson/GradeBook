using System;
using System.Collections.Generic;

namespace GradeBook

{
    public class Book // public is like JS' "export"
    {   
        public Book(string name)
        // This is known as a constructor method
        // This is ran upon instantiation
        {
            grades = new List<double>();
            Name = name;
        }
        
    //  [export][return type][method name](){}
        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach(double grade in grades)
            {
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Average += grade;
            }

            result.Average /= grades.Count;

            return result;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        private List<double> grades;
        public string Name;
    }
}