using Lab9_10CharpT;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        second();
    }
    static void first()
    {
        string formula = "m(9,p(p(3,5),m(3,8)))";
        int result = CalculateFormula(formula);
        Console.WriteLine($"Результат: {result}");
    }

    static int CalculateFormula(string formula)
    {
        Stack<int> numbers = new();
        Stack<char> operators = new();

        foreach (char c in formula)
        {
            if (c == '(')
            {
                operators.Push(c);
            }
            else if (char.IsDigit(c))
            {
                numbers.Push((int)char.GetNumericValue(c));
            }
            else if (c == 'p')
            {
                operators.Push('+');
            } 
            else if(c == 'm')
            {
                operators.Push('-');
            }
            else if (c == ')')
            {
                while (operators.Count > 0 && operators.Peek() != '(')
                {
                    int num2 = numbers.Pop();  
                    int num1 = numbers.Pop();  
                    char op = operators.Pop();

                    if (op == '+')
                    {
                        numbers.Push(Add(num1, num2));
                    }
                    else if (op == '-')
                    {
                        numbers.Push(Subtract(num1, num2)); 
                    }
                }

                
                operators.Pop();
            }
        }

        return numbers.Pop();
    }

    static int Add(int a, int b)
    {
        return (a + b) % 10;
    }

    static int Subtract(int a, int b)
    {
        return (a - b + 10) % 10 + 3; 
    }

    static void second()
    {
        // Читаємо дані з файлу та розділяємо на дві групи
        List<Student> passedStudents = new List<Student>();
        Queue<Student> failedStudents = new Queue<Student>();

        string[] lines = File.ReadAllLines("D:\\CHsarp\\CHsarp_Lab9\\students.txt");
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            string lastName = parts[0];
            string firstName = parts[1];
            string middleName = parts[2];
            string group = parts[3];
            int[] grades = Array.ConvertAll(parts[4].Split(), int.Parse);

            Student student = new Student(lastName, firstName, middleName, group, grades);
            if (IsPassed(grades))
                passedStudents.Add(student);
            else
                failedStudents.Enqueue(student);
        }

        Console.WriteLine("Passed Students:");
        foreach (var student in passedStudents)
        {
            Console.WriteLine(student);
        }

        Console.WriteLine("\nFailed Students:");
        while (failedStudents.Count > 0)
        {
            Console.WriteLine(failedStudents.Dequeue());
        }
    }

    static bool IsPassed(int[] grades)
    {
        foreach (int grade in grades)
        {
            if (grade < 60)
                return false;
        }
        return true;
    }

}
