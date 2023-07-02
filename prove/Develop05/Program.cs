/*
EXCEEDING REQUIREMENTS:


DATE RECORD
- The program stores and shows when each goal was created.

SUPER CHECKLIST
- The checklist Goals class has been expanded so now the user can specify the name of the General goal and add (not a number of occurrences, but actually) multiple specific steps to be completed, allowing the user to input Goals from a Shopping List all the way to a HW List or more, and he is able to complete the steps in the order he wishes, making this new Checklist Goal way more specific, flexible and useful.

ADD TO EXISTING CHECKLIST
- You can add more items to a checklist after its creation, and in the process, the program will only show you Checklists saved, so you can choose the one you want to modify instead of showing you all the goals including not checklists.

GREAT UX
- All the menu and options have been polished for an easy reading and input experience. ENTER goes back one step from any part of the menu but does not allow the user to exit by accident.

-The DisplayGoals method has been vastly improved, with nice formatting and colors: Every yellow line indicates a pending goal, and every green one indicates a completed goal.

- The user receives useful messages when no goals are saved and he tries calling a method.

FOOLPROOF INPUTS
- The program now has a much stronger data validation in all inputs, not only allowing the user to type virtually anything without breaking the program and keeping a clean screen (ok, maybe not anything, but I haven't found an input that breaks the program or makes it misbehave) but also, it does not allow for Goals to go without a name, or using only spaces as a name.

*/


using System;

class Program
{
    static void Main(string[] args)
    {
        Manager manager = new Manager();        
        string menuChoice = null;

        do{
            Console.Clear();
            manager.DisplayMenu();
            manager.DisplayTotalScore();
            
            Console.WriteLine("Select one option or 0 to quit:\n");
            menuChoice = Console.ReadLine();

            switch(menuChoice){
                // CREATE NEW GOAL
                case "1":

                    string subMenuChoice = null;

                    do{
                        manager.DisplayTypeOfGoals();
                        subMenuChoice = Console.ReadLine();

                        switch(subMenuChoice){
                            //   Create Simple Goal
                            case "1":
                                Console.Clear();
                                manager.CreateSimpleGoal();
                                break;
                            //   Create Eternal Goal
                            case "2":
                                Console.Clear();
                                manager.CreateEternalGoal();
                                break;
                            //   Create Checklist Goal
                            case "3":
                                Console.Clear();
                                manager.CreateChecklistGoal();
                                break;
                        }
                    }while(subMenuChoice != "");

                    break;
                
                //  DISPLAY  GOALS
                case "2":
                    
                    if(manager.GetNumberOfGoals() == 0){
                        Console.WriteLine("\nNo Goals saved. Try Adding a new goal.");
                        Thread.Sleep(2000);
                        break;
                    }

                    Console.Clear();
                    manager.DisplayHorizontalLine();
                    Console.WriteLine("- - -            G O A L S            - - -");
                    manager.DisplayHorizontalLine();
                    manager.DisplayAllGoals();
                    manager.DisplayTotalScore();        
                    Console.WriteLine("Press ENTER to go back.");
                    Console.ReadLine();

                    break;

                // RECORD EVENT
                case "3":

                    if(manager.GetNumberOfGoals() == 0){
                        Console.WriteLine("\nNo Goals saved. Try Adding a new goal.");
                        Thread.Sleep(2000);
                        break;
                    }
                    
                    string subMenuChoice3;

                    do{
                        Console.Clear();        
                        manager.DisplayHorizontalLine();
                        Console.WriteLine("- - - -   R E C O R D   E V E N T   - - - -");
                        manager.DisplayHorizontalLine();
                        manager.DisplayAllGoals();
                        manager.DisplayTotalScore(); 

                        Console.WriteLine("Select the Goal to modify (Hit ENTER to Go Back):\n");
                        subMenuChoice3 = Console.ReadLine();
                        // Console.Clear();
                        int goalSelected;

                        if(int.TryParse(subMenuChoice3, out goalSelected)){

                            if(goalSelected == 0){

                                break;
                            }

                            if(goalSelected <= manager.GetNumberOfGoals()){

                                Goal goal1 = manager.GetGoal(goalSelected);
                                
                                if(goal1.GetGoalStatus()){
                                    Console.Write("\nGoal already COMPLETED.\n");
                                    Thread.Sleep(2000);
                                    Console.Clear();

                                }else{

                                    Boolean changes = goal1.RecordEvent();

                                    if(changes){
                                        manager.AddUnsavedChanges();
                                    }
                                }
                            }
                        }

                    }while(subMenuChoice3 != "");

                    break;

                //  ADD TO CHECKLIST
                case "4":
                    if(manager.GetNumberOfChecklists() == 0){
                        // Console.Clear();
                        Console.WriteLine("\nNo checklists found. Try adding one from the main menu.");
                        Thread.Sleep(3000);
                        break;
                    }
                    string checklistSelected;

                    do{
                        Console.Clear();        
                        manager.DisplayHorizontalLine();
                        Console.WriteLine("- -  A D D   T O   C H E C K L I S T  - - -");
                        manager.DisplayHorizontalLine();
                        manager.DisplayAllChecklists();
                        manager.DisplayTotalScore();   
                        Console.WriteLine("Select the Cheklist in Pink to modify\nor Hit ENTER to Go Back): \n");
                        checklistSelected = Console.ReadLine();

                        if(checklistSelected == ""){
                            break;
                        }

                        Console.Clear();
                        int goalSelected;

                        if(int.TryParse(checklistSelected, out goalSelected)){

                            if(goalSelected <= manager.GetNumberOfGoals()){
                                
                                if(manager.GetGoal(goalSelected).GetTypeOfGoal() == "Checklist Goal"){

                                    if(manager.GetGoal(goalSelected) is ChecklistGoal checklistGoal){
                                        manager.AddItemToChecklist(checklistGoal);
                                    }
                                }
                            }
                        }

                    }while(checklistSelected != "");
                    break;

                // SAVE to file
                case "5":
                    
                    if(manager.GetNumberOfGoals() == 0){
                        Console.WriteLine("No goals found. Try creating a new Goal.");
                        Thread.Sleep(2000);
                        break;
                    }

                    string fileNameToSave;

                    do{
                        Console.Clear();
                        manager.DisplayHorizontalLine();
                        Console.WriteLine("- - -     S A V E   T O   F I L E     - - -");
                        manager.DisplayHorizontalLine(); 
                        Console.WriteLine("\nType the name of the file to save and hit ENTER:\n");
                        fileNameToSave = Console.ReadLine();

                        if(!string.IsNullOrWhiteSpace(fileNameToSave)){

                            if(File.Exists(fileNameToSave + ".txt")){                            
                                string res;

                                do{
                                    Console.Clear();
                                    manager.DisplayHorizontalLine();
                            Console.WriteLine("- - -     S A V E   T O   F I L E     - - -");
                            manager.DisplayHorizontalLine(); 
                                    Console.WriteLine("\nType the name of the file to save and hit ENTER:\n");
                                    Console.WriteLine("\nA file with that name was found. Would you like  to overwrite it? (y/n)\n\nTHIS WILL PERMANENTLY DELETE ALL THE INFORMATION IN IT.\n");
                                    res = Console.ReadLine();

                                    if(res.ToLower() == "y"){
                                        manager.SaveToFile(fileNameToSave);
                                        Console.WriteLine("\nGoals saved to file.");
                                        Thread.Sleep(2000);
                                        fileNameToSave = "";
                                        break;
                                    }

                                }while(res.ToLower() != "n");
                            }
                            else{
                                manager.SaveToFile(fileNameToSave);
                                Console.WriteLine("\n\nGoals saved to file.");
                                Thread.Sleep(2000);
                                break;
                            }
                        }
                    }while(fileNameToSave != "");

                    break;
                
                //  LOAD from file
                case "6":

                    string fileNameToLoad = null;
                    

                    do{
                        
                        if(!manager.GetUnsavedChanges()){
                            
                            fileNameToLoad = manager.StartFileLoad(fileNameToLoad); 

                            break;            
                        }
                        else{
                            string res2 = "";
                            
                            do{
                                Console.Clear();
                                manager.DisplayHorizontalLine();
                                
                                manager.DisplayHorizontalLine();
                                Console.WriteLine("- - -   L O A D   F R O M   F I L E   - - -");
                                manager.DisplayHorizontalLine();
                                Console.WriteLine("\nThere are UNSAVED goals.\nWould you like to load the file anyways? (y/n)\n\nThis will PERMANENTLY DELETE all existing goal in the program.\n");
                                res2 = Console.ReadLine();

                                if(res2.ToLower() == "y"){
                                    
                                    fileNameToLoad = manager.StartFileLoad(fileNameToLoad);
                                    
                                    break;
                                }
                                else if(res2.ToLower() == "n"){
                                    fileNameToLoad = "";
                                    break;
                                }
                            }while(fileNameToLoad != "");  
                        }
                        
                    }while(fileNameToLoad != "");

                    break;
            }

            if(manager.GetNumberOfGoals() != 0 && menuChoice == "0" && manager.GetUnsavedChanges()){
            
                Console.WriteLine("\nThere are UNSAVED GOALS that would be lost.\n\nWould you like to EXIT anyway? (y/n)\n");
                menuChoice = Console.ReadLine();
                if(menuChoice.ToLower() == "y"){
                    break;
                }
            }

        }while(menuChoice != "0");

        Console.Clear();
    }
}