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
            Console.WriteLine("Select one option or 0 to quit: ");
            input = Console.ReadLine();

            switch(input){
                // Create New Goal
                case "1":
                    string input2 = null;

                    do{
                        manager1.DisplayTypeOfGoals();
                        input2 = Console.ReadLine();

                        switch(input2){
                            //   Create Simple Goal
                            case "1":
                                Console.Clear();
                                manager1.CreateSimpleGoal();
                                break;
                            //   Create Eternal Goal
                            case "2":
                                Console.Clear();
                                manager1.CreateEternalGoal();
                                break;
                            //   Create Checklist Goal
                            case "3":
                                Console.Clear();
                                manager1.CreateChecklistGoal();
                                break;
                        }
                    }while(input2 != "");
                    break;
                
                //  Display Goals
                case "2":
                    Console.Clear(); 
                    manager1.DisplayGoals();         
                    Console.WriteLine("- - - - - - - - - - - - -");           
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    break;

                // Add Event
                case "3":                            
                    
                    string input3;

                    do{
                        Console.Clear();        
                        Console.WriteLine("- - - - - - - - - - - - - -");
                        Console.WriteLine("- -  A D D   E V E N T - -");
                        Console.WriteLine("- - - - - - - - - - - - - -\n");
                        manager1.DisplayGoals();
                        Console.WriteLine("- - - - - - - - - - - - -");
                        Console.WriteLine("Select the Goal to modify (Hit ENTER to Go Back): ");
                        input3 = Console.ReadLine();
                        Console.Clear();
                        int goalSelected;

                        if(int.TryParse(input3, out goalSelected)){
                            if(goalSelected == 0){
                                break;
                            }

                            if(goalSelected <= manager1.GetNumberOfGoals()){

                                Goal goal1 = manager1.GetGoal(goalSelected);
                                string res;
                                
                                switch(goal1.GetTypeOfGoal()){
                                    case "Simple Goal":
                                        if(goal1.GetGoalStatus()){
                                            Console.Write("Goal already Completed\n");
                                            Thread.Sleep(1000);
                                            Console.Clear();
                                        }else{
                                            do{
                                                Console.Clear();
                                                Console.Write("Was the goal COMPLETED? (y/n):");
                                                res = Console.ReadLine();

                                                if(res.ToLower() =="y"){
                                                    goal1.MarkCompleted();
                                                    Console.Write("\nThe goal was marked as COMPLETED!!\n");
                                                    Thread.Sleep(2000);
                                                    Console.Clear();
                                                    break;
                                                }
                                                else if(res.ToLower() == "n"){
                                                    Console.Write("\nNo problem, keep it up! :D\n\n");
                                                    Thread.Sleep(3000);
                                                    break;
                                                }
                                            }while(res != "y" || res !="n");
                                        }
                                        break;
                                    case "Eternal Goal":

                                        do{
                                            Console.Clear();
                                            Console.Write("Did you complete the goal today? (y/n):");
                                            res = Console.ReadLine();

                                            if(res.ToLower() =="y"){
                                                goal1.RecordEvent(true);
                                                Console.Write("\nThe goal was marked as COMPLETED!!\n");
                                                Thread.Sleep(2000);
                                                Console.Clear();
                                                break;
                                            }
                                            else if(res.ToLower() == "n"){
                                                Console.Write("Event recorded.\n");
                                                Console.Write("\nNo problem, keep it up! :D\n\n");
                                                goal1.RecordEvent(false);
                                                Thread.Sleep(3000);
                                                break;
                                            }
                                        }while(res != "y" || res !="n");
                                        break;
                                    case "Checklist Goal":
                                        break;
                                }
                            }else{
                                Console.Write("Goal " + goalSelected +" not found. Please try again.");
                                Thread.Sleep(3000);
                            }
                        }

                    }while(input3 != "");

                    break;

                
                case "4":
                    break;
                default:
                    break;
                
                
            }

        }while(input != "0");
        Console.Clear();
    }
}