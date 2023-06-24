/*
EXCEEDING REQUIREMENTS:

- The program stores and shows when each goal was created.

- The checklist Goals class has been expanded to allow the user to specify the different steps to complete, allowing the user to input Goals from a Shopping List all the way to a HW List, and he is able to complete the steps in the order he wishes, making this type of goal way more specific, flexible and useful.

- You can even add more items to a checklist after it's creation and in the process, the program will only show you Checklists saved, so you can choose the one you want to modify.

- The Display Goals method has been bastly improved with nice formating and colors: Every yellow line indicates a pending goal, and every green one indicates a completed goal. All this changes make for a much easier reading experience on a console.

- The program now has a much stronger data validation in all inputs, not only allowing the user to type virtually anything without breaking the program and keeping a clean screen (ok, maybe not anything, but I haven't found an input that breaks the program or makes it misbehave) but also, it does not allow for Goals to go without a name, or using only spaces as a name.

*/


using System;

class Program
{
    static void Main(string[] args)
    {
        Manager manager1 = new Manager();        
        string input = null;

        do{
            manager1.DisplayMenu();
            manager1.DisplayTotalScore();
            
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
                    Console.WriteLine("- - - - - - - - - - - -");
                    Console.WriteLine("- -    G O A L S    - -");
                    Console.WriteLine("- - - - - - - - - - - -\n"); 
                    manager1.DisplayGoals();
                    manager1.DisplayTotalScore();        
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    break;

                // Add Event
                case "3":                            
                    
                    string input3;

                    do{
                        Console.Clear();        
                        Console.WriteLine("- - - - - - - - - - - - - -");
                        Console.WriteLine("- -  R E C O R D   E V E N T - -");
                        Console.WriteLine("- - - - - - - - - - - - - -\n");
                        manager1.DisplayGoals();
                        manager1.DisplayTotalScore();   
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
                                                Console.Write("Was the goal '" + goal1.GetDescription() + "' Completed? (y/n):");
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
                                            Console.Write("Did you complete the goal '" + goal1.GetDescription() + "' today? (y/n):");
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
                                        
                                        string selection;

                                        do{
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Magenta;
                                            Console.WriteLine(goal1.GetDescription());                    
                                            Console.ResetColor();
                                            Console.WriteLine("    Checklist Goal");
                                            Console.WriteLine("Created: " + goal1.GetDateCreated());
                                            Console.WriteLine("Points: " + goal1.GetPoints());
                                            goal1.DisplayGoal();
                                            Console.ResetColor();

                                            int numberSelected;
                                        
                                            Console.WriteLine("Select one Item to mark as done, or Hit ENTER to go Back:\n");
                                            selection = Console.ReadLine();

                                            if(selection != "" && int.TryParse(selection, out numberSelected)){
                                                goal1.UpdateItem(numberSelected);
                                            }
                                        }while(selection != "");
                                        break;
                                }
                            }
                            // else{
                            //     Console.Write("Goal " + goalSelected +" not found. Please try again.");
                            //     Thread.Sleep(3000);
                            // }
                        }

                    }while(input3 != "");

                    break;

                //  Add to Checklist
                case "4":
                    string input4;

                    do{
                        Console.Clear();        
                        Console.WriteLine("- - - - - - - - - - - - - -");
                        Console.WriteLine("- -  A D D   T O   C H E C K L I S T - -");
                        Console.WriteLine("- - - - - - - - - - - - - -\n");
                        manager1.DisplayChecklists();
                        manager1.DisplayTotalScore();   
                        Console.WriteLine("Select the Cheklist in Pink to modify\nor Hit ENTER to Go Back): \n");
                        input4 = Console.ReadLine();

                        if(input4 == ""){
                            break;
                        }
                        Console.Clear();
                        int goalSelected;

                        if(int.TryParse(input4, out goalSelected)){

                            if(goalSelected <= manager1.GetNumberOfGoals()){
                                ;
                                if(manager1.GetGoal(goalSelected).GetTypeOfGoal() == "Checklist Goal"){
                                    manager1.AddItemToChecklist(manager1.GetGoal(goalSelected));
                                }
                            }
                        }

                    }while(input4 != "");
                    break;
            }

        }while(input != "0");
        Console.Clear();
    }
}