using System;
using System.Data.SQLite;

using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {   
        
        int attempts = 3;
        string employeeNumber;

        do{
            Console.Clear();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - -");
            Console.WriteLine(" - -          L O G I N           - -");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - -\n");
            Console.WriteLine("Enter employee Number:\n");
            employeeNumber = Console.ReadLine();

            if(employeeNumber == ""){
                break;
            }

            Console.WriteLine("\nEnter password:\n");
            string password = GetMaskedInput();


        //     string password = Console.ReadLine();
        //     DataBaseManager dataBaseManager = new DataBaseManager();

        //     using (SHA256 sha256 = SHA256.Create())
        // {
        //     byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        //     StringBuilder builder = new StringBuilder();
        //     foreach (byte b in bytes)
        //     {
        //         builder.Append(b.ToString("x2"));
        //     }
            

        //     Console.WriteLine(builder.ToString());
        //     Thread.Sleep(5000);             
        // }


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


        // PointOfSale pointOfSale = new PointOfSale();
        // Store store = new Store();
        
        // string menuChoice = null;

        // do{
        //     Console.Clear();
        //     pointOfSale.DisplayMenu();
        //     Console.WriteLine("Select one option or 0 to quit:\n");
        //     menuChoice = Console.ReadLine();

        //     switch(menuChoice){

        //         //  New Cart
        //         case "1":
        //             pointOfSale.LoadNewCart();
        //             break;
        //         //  Check Item Price
        //         case "2":
                    
        //             break;
        //             //  Add Item
        //         case "3":
                    
        //             break;
        //             //  Check Item Price
        //         case "4":
                    
        //             break;

        //     }


        // }while(menuChoice != "0");

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