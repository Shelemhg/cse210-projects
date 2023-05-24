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
                        Console.WriteLine("\nCurrent journal is empty. Try loading journal from file or adding a new entry.\n");
                    }
                break;

                //   Read from File
                case "3":
                    
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
                break;

                //    Save to File
                case "4":
                    
                    if(File.Exists(Journal._fileName)){
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