/*
Just as a note, the polymorphism here is found in answering the quesiton: Who's login in? is it a regular Casheer or a Manager?

Well... it doesn't matter! as the program will continue the loop 
BUT!! each different employee type will see and have access to their
own options, but the program running on Employee doesn't know nor
makes any differentiation, but each class has it's own unique way
of dealing with different situations, starting by DisplayMenu() and LoadPointOfSale()!



PROGRAM DESCRIPTION:

Efficient Point of Sale for small and medium stores, made in about week and a half.
The idea was to propose a simple but powerfull POS that could 
potentially run in a very small computer, maybe Arduinos or other small and cheap computers but without compromising characteristics
so SQLite was chosen by its light weight, high performance,
cross-platform and self-contained characteristics, avoiding the need of having a SQL instance running
all the time and consuming system resources, being able to store up to
140 TB of information on a single database.


PROGRAM CHARACTERISTICS

- Full CRUD operations from C# POS to SQLite DB
- Hashed passwords for all employees. (Salt will be added in v1.2)
- Different Menu options between Cashiers and Managers through polymorphism
- Coded with love :)

S.H. July 16, 2023

*/




class Program
{
    static void Main(string[] args)
    {   
        
        int attempts = 3;
        string employeeNumber;

        do{
            Console.Clear();

            //   LINE ONLY FOR TESTING
            Console.WriteLine("\nTest users:  1001 & 1002\nPWD: 1234\n");
            
            
            
            Console.WriteLine("- - - - - - - - - - - - - - - - - - -");
            Console.WriteLine(" - -          L O G I N           - -");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - -\n");
            Console.WriteLine("\nHit ENTER to quit or:\n");
            Console.WriteLine("Enter employee Number:\n");
            employeeNumber = Console.ReadLine();

            if(employeeNumber == ""){
                break;
            }

            Console.WriteLine("\nEnter password:\n");
            string password = GetMaskedInput();

            Employee employee = NewLogin(employeeNumber, password);

            if(employee != null){

                employee.LoadPointOfSale();

            }else{

                Console.WriteLine("\nInvalid username or password\n");                            
                attempts--;
                Console.WriteLine($"\n{attempts} more attempts.");
                Thread.Sleep(2000);
            }

        }while(attempts > 0 && employeeNumber != "");

        Console.Clear();

    }

    static string GetMaskedInput(){

        string input = string.Empty;
        ConsoleKeyInfo key;

        do{
            key = Console.ReadKey(true);

            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter){

                input += key.KeyChar;
                Console.Write("*");

            }else if (key.Key == ConsoleKey.Backspace && input.Length > 0){

                input = input.Remove(input.Length - 1);
                Console.Write("\b \b");
            }
        }while (key.Key != ConsoleKey.Enter);

        Console.WriteLine();
        return input;
    }

    static Employee NewLogin(string employeeNumber, string password){

            DataBaseManager dataBaseManager = new DataBaseManager();
        
            Employee employee = dataBaseManager.IsLoginValid(employeeNumber, password);
            

        // return null;
        return employee;
    }
}