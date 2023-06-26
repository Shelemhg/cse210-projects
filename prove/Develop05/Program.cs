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
        Manager manager1 = new Manager();        
        string input = null;

        do{
            manager1.DisplayMenu();
            manager1.DisplayTotalScore();
            
            Console.WriteLine("Select one option or 0 to quit:\n");
            input = Console.ReadLine();

            switch(input){
                // CREATE NEW GOAL
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
                
                //  DISPLAY  GOALS
                case "2":
                    
                    if(manager1.GetNumberOfGoals() == 0){
                        Console.WriteLine("\nNo Goals saved. Try Adding a new goal.");
                        Thread.Sleep(2000);
                        break;
                    }

                    Console.Clear();
                    Console.WriteLine("- - - - - - - - - - - -");
                    Console.WriteLine("- -    G O A L S    - -");
                    Console.WriteLine("- - - - - - - - - - - -\n"); 
                    manager1.DisplayAllGoals();
                    manager1.DisplayTotalScore();        
                    Console.WriteLine("Press ENTER to go back.");
                    Console.ReadLine();

                    break;

                // RECORD EVENT
                case "3":

                    if(manager1.GetNumberOfGoals() == 0){
                        Console.WriteLine("\nNo Goals saved. Try Adding a new goal.");
                        Thread.Sleep(2000);
                        break;
                    }
                    
                    string input3;

                    do{
                        Console.Clear();        
                        Console.WriteLine("- - - - - - - - - - - - - -");
                        Console.WriteLine("- -  R E C O R D   E V E N T - -");
                        Console.WriteLine("- - - - - - - - - - - - - -\n");
                        manager1.DisplayAllGoals();
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
                                                Console.Write("Was the goal '" + goal1.GetGoalDescription() + "' Completed? (y/n):\n\n");
                                                res = Console.ReadLine();

                                                if(res.ToLower() =="y"){
                                                    manager1.AddUnsavedChanges();
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

                                        if(goal1 is EternalGoal eternalGoal){
                                            
                                            do{
                                                Console.Clear();
                                                Console.Write("Did you complete the goal '" + eternalGoal.GetGoalDescription() + "' today? (y/n):");
                                                res = Console.ReadLine();

                                                if(res.ToLower() =="y"){
                                                    eternalGoal.RecordEvent(DateTime.Now, true);
                                                    manager1.AddUnsavedChanges();
                                                    Console.Write("\nThe goal was marked as COMPLETED!!\n");
                                                    Thread.Sleep(2000);
                                                    Console.Clear();
                                                    break;
                                                }
                                                else if(res.ToLower() == "n"){
                                                    eternalGoal.RecordEvent(DateTime.Now, false);
                                                    manager1.AddUnsavedChanges();
                                                    Console.Write("Event recorded.\n");
                                                    Console.Write("\nNo problem, keep it up! :D\n\n");
                                                    Thread.Sleep(3000);
                                                    break;
                                                }
                                            }while(res != "y" || res !="n");
                                        }

                                        break;
                                    
                                    case "Checklist Goal":
                                        
                                        if(goal1 is ChecklistGoal checklistGoal){
                                            string selection;

                                            do{
                                                Console.Clear();
                                                manager1.DisplaySingleChecklist(checklistGoal);
                                                int numberSelected;
                                            
                                                Console.WriteLine("Select one Item to mark as done, or Hit ENTER to go Back:\n");
                                                selection = Console.ReadLine();

                                                if(selection != "" && int.TryParse(selection, out numberSelected)){
                                                    checklistGoal.UpdateItem(numberSelected);
                                                    manager1.AddUnsavedChanges();
                                                }
                                            }while(selection != "");
                                        }
                                        break;
                                }
                            }
                        }

                    }while(input3 != "");

                    break;

                //  ADD TO CHECKLIST
                case "4":
                    if(manager1.GetNumberOfChecklists() == 0){
                        // Console.Clear();
                        Console.WriteLine("\nNo checklists found. Try adding one from the main menu.");
                        Thread.Sleep(3000);
                        break;
                    }
                    string input4;

                    do{
                        Console.Clear();        
                        Console.WriteLine("- - - - - - - - - - - - - - - - -");
                        Console.WriteLine(" A D D   T O   C H E C K L I S T");
                        Console.WriteLine("- - - - - - - - - - - - - - - - -\n");
                        manager1.DisplayAllChecklists();
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
                                    if(manager1.GetGoal(goalSelected) is ChecklistGoal checklistGoal){
                                        manager1.AddItemToChecklist(checklistGoal);
                                    }
                                }
                            }
                        }

                    }while(input4 != "");
                    break;

                // SAVE to file
                case "5":
                    
                    if(manager1.GetNumberOfGoals() == 0){
                        Console.WriteLine("No goals found. Try creating a new Goal.");
                        Thread.Sleep(2000);
                        break;
                    }

                    string fileName;

                    do{
                        Console.Clear();
                        Console.WriteLine("- - - - - - - - - - - - - - - -");
                        Console.WriteLine("- - S A V E   T O   F I L E - -");
                        Console.WriteLine("- - - - - - - - - - - - - - - -\n"); 
                        Console.WriteLine("Type the name of the file to save and hit ENTER:\n");
                        fileName = Console.ReadLine();

                        if(!string.IsNullOrWhiteSpace(fileName)){

                            if(File.Exists(fileName + ".txt")){                            
                                string res;

                                do{
                                    Console.Clear();
                                    Console.WriteLine("- - - - - - - - - - - - - - - -");
                                    Console.WriteLine("- - S A V E   T O   F I L E - -");
                                    Console.WriteLine("- - - - - - - - - - - - - - - -\n"); 
                                    Console.WriteLine("Type the name of the file to save and hit ENTER:\n");
                                    Console.WriteLine("\nA file with that name was found. Would you like  to overwrite it? (y/n)\n\nTHIS WILL PERMANENTLY DELETE ALL THE INFORMATION IN IT.\n");
                                    res = Console.ReadLine();

                                    if(res.ToLower() == "y"){
                                        manager1.SaveToFile(fileName);
                                        Console.WriteLine("\nGoals saved to file.");
                                        Thread.Sleep(2000);
                                        fileName = "";
                                        break;
                                    }

                                }while(res.ToLower() != "n");
                            }
                            else{
                                manager1.SaveToFile(fileName);
                                Console.WriteLine("\n\nGoals saved to file.");
                                Thread.Sleep(2000);
                                break;
                            }
                        }
                    }while(fileName != "");

                    break;
                
                //  LOAD from file
                case "6":

                    string fileNameToLoad = null;
                    

                    do{
                        
                        if(!manager1.GetUnsavedChanges()){
                            
                            fileNameToLoad = manager1.StartFileLoad(fileNameToLoad); 

                            break;            
                        }
                        else{
                            string res2 = "";
                            
                            do{
                                Console.Clear();
                                Console.WriteLine("- - - - - - - - - - - - - - - - - -");
                                Console.WriteLine("- - L O A D   F R O M   F I L E - -");
                                Console.WriteLine("- - - - - - - - - - - - - - - - - -\n");
                                Console.WriteLine("There are UNSAVED goals.\nWould you like to load the file anyways? (y/n)\n\nThis will PERMANENTLY DELETE all existing goal in the program.\n");
                                res2 = Console.ReadLine();

                                if(res2.ToLower() == "y"){
                                    
                                    fileNameToLoad = manager1.StartFileLoad(fileNameToLoad);
                                    
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

            if(manager1.GetNumberOfGoals() != 0 && input == "0" && manager1.GetUnsavedChanges()){
            
                Console.WriteLine("\nThere are UNSAVED GOALS that would be lost.\n\nWould you like to EXIT anyway? (y/n)\n");
                input = Console.ReadLine();
                if(input.ToLower() == "y"){
                    break;
                }
            }

        }while(input != "0");

        Console.Clear();
    }
}