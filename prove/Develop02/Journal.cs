class Journal {

    public static string _fileName = "journal.csv";
    public List<Entry> _entries = new List<Entry>();
    public static List<string> _prompts = new List<string> {
        "What was the highlight of your day?",
        "What kind of day are you having, and why?",
        "What's something did well today?",
        "What were your top priorities today?",
        "What were you thankful for today?",
        "What is a decision you need to make soon?",
        "What are some things I would like to do differently tomorrow?",
        "What did you learn today?",
        "What did you accomplish today?",
        "How did I handle any difficult situations that arose today?",
        "What am I looking forward to tomorrow?"
    };
    
    public static string DisplayMenu(){

        Console.WriteLine("- - - - - - - - - - - -");
        Console.WriteLine("-    J O U R N A L    -");
        Console.WriteLine("- - - - - - - - - - - -");
        Console.WriteLine("1. New Entry");
        Console.WriteLine("2. Display Journal");
        Console.WriteLine("3. Load Journal from File");
        Console.WriteLine("4. Save Journal to File");
        Console.WriteLine(". . . . . . . . . . . .");
        Console.WriteLine("0. Exit\n");
        return Console.ReadLine();
    }

    public static void NewEntry(Journal journal1){
        DateTime date = DateTime.Now;

        Random rnd = new Random();
        // int num = rnd.Next(1, _prompts.Count());
        string prompt1 = _prompts[rnd.Next(1, _prompts.Count())];

        Entry entry1 = new Entry();                  
        entry1._date = date.ToString();
        entry1._prompt = prompt1;

        Console.WriteLine(prompt1);
        Console.WriteLine("Type entry:");
        entry1._response = Console.ReadLine();

        journal1._entries.Add(entry1);
    }

  public static void DisplayJournal(Journal journal1){
        Console.WriteLine("\n______________________");
        foreach(var e in journal1._entries)
            {             
                Console.WriteLine(e._date);
                Console.WriteLine(e._prompt + "\n");
                Console.WriteLine(e._response);
                Console.WriteLine("______________________");
            }
        
    }

    public static void ReadFromFile(Journal journal1){
        
        // List<Entry> entries = new List<Entry>();
        string[] lines = System.IO.File.ReadAllLines(_fileName);

        foreach (string line in lines){

            string[] parts = line.Split(" ~ ");
            Entry newEntry = new Entry();
            newEntry._date =  parts[0];
            newEntry._prompt =  parts[1];
            newEntry._response =  parts[2];
            journal1._entries.Add(newEntry);
        }
    }
  
    public static void SaveToFile(Journal journal1){
        using (StreamWriter outputFile = new StreamWriter(_fileName)){
            foreach (Entry e in journal1._entries){
                outputFile.WriteLine($"{e._date} ~ {e._prompt} ~ {e._response}");
            }
        }
        Console.WriteLine("Journal Saved in file: " + _fileName);
    }
}

