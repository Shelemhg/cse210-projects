/*
Exceeding Requirements

1. Prompt guides for the user

    Due to the simplicity of the program there are a few limitations and actions that can cause some trouble, but what a better way to approach that than through prompts that can guide the user and allowing him know what is going on so he can make the right choices being guided by useful prompts.

2. Data validation

    The user has to make a few choices when using the program, and using data validation and making sure that most inputs won't cause any trouble on the program, just the screen cleans and the user has another chance to input a right option.


*/

using System;

class Program
{
    static void Main(string[] args)
    {
        
        Journal journal1 = new Journal();
        string selection;
        do {           
            
            selection = Journal.DisplayMenu();

            switch(selection) {
                //   New Entry
                case "1":

                    Console.Clear();
                    if(File.Exists(Journal._fileName)){
                        string res1;
                        do {
                            Console.WriteLine("A Journal file has been found, would you like to add this entry to it? (y/n):");
                            res1 = Console.ReadLine();
                            
                            if (res1.ToLower() == "y"){
                                Console.Clear();
                                Journal.ReadFromFile(journal1);
                                Journal.NewEntry(journal1);
                                Console.Clear();
                                Console.WriteLine("- Entry Received. Please remember to Save your changes. -");
                            }
                            else if(res1.ToLower() =="n"){
                                string res2;
                                Console.Clear();

                                do {
                                    Console.WriteLine("Would you like to create a new independent entry (y/n):");
                                    res2 = Console.ReadLine();
                                    Console.Clear();

                                    if (res2.ToLower() == "y"){
                                        Journal.NewEntry(journal1);
                                        Console.Clear();
                                        Console.WriteLine("- Entry Received. Please remember to Save your changes. -");
                                    }
                                }while (res2.ToLower() != "y" && res2.ToLower() != "n");
                            }
                            else{
                                Console.Clear();
                            }
                        }while (res1.ToLower() != "y" && res1.ToLower() != "n");
                    }else{
                        Journal.NewEntry(journal1);
                        Console.Clear();
                        Console.WriteLine("- Entry Received. Please remember to Save your changes. -");
                    }
                    
                break;

                //   Display Journal
                case "2":
                        if(journal1._entries.Count() > 0){
                            Console.Clear();
                            Journal.DisplayJournal(journal1);
                        }
                        else{
                            Console.Clear();
                            Console.WriteLine("\nCurrent journal is empty.\n\nTry loading journal from file or adding a new entry.\n");
                        }
                break;

                //   Read from File
                case "3":
                    if(File.Exists(Journal._fileName)){
                        Console.Clear();
                        if(journal1._entries.Count > 0){
                            string res;
                            do{
                                Console.WriteLine("By loading a new file the follow information will be permanently deleted:");                    
                                Journal.DisplayJournal(journal1);
                                Console.WriteLine("\nDo you wish to continue (y/n):");
                                res = Console.ReadLine();
                                
                                if(res.ToLower() == "y"){
                                    journal1._entries.Clear();
                                    Journal.ReadFromFile(journal1);
                                }
                                else if (res.ToLower() == "n"){
                                    break;
                                }
                            } while (res.ToLower() != "y" && res.ToLower() != "n");
                        }
                        else{    
                            Journal.ReadFromFile(journal1);
                        }            
                            Console.Clear();     
                            Journal.DisplayJournal(journal1);   
                    }else{
                        Console.Clear();
                        Console.WriteLine("No Journal file was found.\n\nTry creating a new one or moving the journal to the program folder.\n");
                    }   
                break;

                //    Save to File
                case "4":
                    
                    if(File.Exists(Journal._fileName)){
                        if(journal1._entries.Count > 0){
                            string res;
                            do {
                                Console.WriteLine("By saving recent entries the current information in the existing file will be permanently deleted.\n\nDo you wish to continue? (y/n):");
                                res = Console.ReadLine();
                                if (res.ToLower() == "y"){
                                    Console.Clear();
                                    Journal.SaveToFile(journal1);
                                    Console.WriteLine("Journal saved on file.");
                                }
                                else{
                                    Console.Clear();
                                }
                            } while (res.ToLower() != "y" && res.ToLower() != "n");
                        }else{
                            Console.Clear();
                            Console.WriteLine("No new entry was found.\n\nTry creating a new one by selecting option 1.\n");
                        }
                    }
                    else{
                        Console.Clear();
                        Journal.SaveToFile(journal1);
                        Console.WriteLine("Journal saved on file.");
                    }                    
                break;

                case "0":
                    Console.Clear();
                    Console.WriteLine("Closing Journal, bye!\n");
                break;

                default:
                break;
                }

        } while (selection != "0");
    }
}