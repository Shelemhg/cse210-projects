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