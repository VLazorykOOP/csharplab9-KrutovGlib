using Lab9_10CharpT;
using Lab9_10CharpT.Fourth;
using Lab9_10CharpT.Third;


class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введiть номер завдання: ");
        int choise = int.Parse(Console.ReadLine());
        switch (choise)
        {
            case 1: first(); break;
            case 2: second(); break;
            case 3:
                Third.ThirdTask();
                someMethood();
                break;
            case 4:
                fourth();
                break;
        }
    }
    static void first()
    {
        string filepath = "D:\\CHsarp\\CHsarp_Lab9\\First.txt";
        string formul = File.ReadAllText(filepath);
        int result = CalculateFormula(formul);
        Console.WriteLine($"Результат: {result}");
    }

    static void someMethood()
    {
        string filepath = "D:\\CHsarp\\CHsarp_Lab9\\First.txt";
        string formul = File.ReadAllText(filepath);
        Formula formula = new Formula(formul);
        Console.WriteLine(formula.Evaluate());
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
            else if (c == 'm')
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

    static void fourth()
    {
        MusicCatalog catalog = new MusicCatalog();

        catalog.AddDisk("Best of 90s");
        catalog.AddDisk("Rock Classics");

        catalog.AddSongToDisk("Best of 90s", new Song("Wonderwall", "Oasis"));
        catalog.AddSongToDisk("Best of 90s", new Song("Smells Like Teen Spirit", "Nirvana"));
        catalog.AddSongToDisk("Rock Classics", new Song("Stairway to Heaven", "Led Zeppelin"));
        catalog.AddSongToDisk("Rock Classics", new Song("Bohemian Rhapsody", "Queen"));

        // Ввод команд з консолі
        while (true)
        {
            Console.WriteLine("Enter command (search/add/remove/exit/show):");
            string command = Console.ReadLine().ToLower();

            switch (command)
            {
                case "search":
                    Console.WriteLine("Enter artist name to search:");
                    string artist = Console.ReadLine();
                    catalog.SearchByArtist(artist);
                    break;
                case "add":
                    Console.WriteLine("Enter disk title to add song:");
                    string diskToAdd = Console.ReadLine();
                    Console.WriteLine("Enter song title:");
                    string songTitle = Console.ReadLine();
                    Console.WriteLine("Enter artist name:");
                    string songArtist = Console.ReadLine();
                    catalog.AddSongToDisk(diskToAdd, new Song(songTitle, songArtist));
                    break;
                case "remove":
                    Console.WriteLine("Enter disk title to remove song:");
                    string diskToRemove = Console.ReadLine();
                    Console.WriteLine("Enter song title:");
                    string songToRemove = Console.ReadLine();
                    catalog.RemoveSongFromDisk(diskToRemove, new Song(songToRemove, ""));
                    break;
                case "show":
                    catalog.ShowCatalog();
                    break;
                case "exit":
                    return;
                default:
                    Console.WriteLine("Invalid command. Please try again.");
                    break;
            }

        }
    }
}
