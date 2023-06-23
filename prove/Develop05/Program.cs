using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Develop05 World!");
        Manager manager1 = new Manager();

        
        string input = null;
        do{
            manager1.DisplayMenu();
            Console.WriteLine("Select one option: ");
            input = Console.ReadLine();

            switch(input){
                // Create New Goal
                case "1":
                    string input2 = null;

                    do{
                        manager1.DisplayTypeOfGoals();
                        Console.WriteLine("Select one option: ");
                        input2 = Console.ReadLine();

                        switch(input2){
                            //   Create Simple Goal
                            case "1":
                                manager1.CreateSimpleGoal();
                                break;
                            //   Create Eternal Goal
                            case "2":
                                manager1.CreateEternalGoal();
                                break;
                            //   Create Checklist Goal
                            case "3":
                                manager1.CreateChecklistGoal();
                                break;
                        }
                    }while(input2 != "0");
                    break;
                //  Display Goals
                case "2":
                    break;
                // Add Event
                case "3":
                    manager1.DisplayGoals();

                    break;

                
                case "4":
                    break;
                default:
                    break;
                
                
            }

        }while(input != "5");
    }
}