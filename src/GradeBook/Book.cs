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

            // foreach(double grade in grades)
            // {
            //     result.High = Math.Max(grade, result.High);
            //     result.Low = Math.Min(grade, result.Low);
            //     result.Average += grade;
            // }
            
            for(var index = 0; index < grades.Count; index += 1)
            {
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

            return result;
        }

        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                Console.WriteLine("Invalid value");
            }
        }

        public List<double> grades;
        public string Name;
    }
}