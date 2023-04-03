using mis_221_pa_5_mcscott5;

Trainer mike = new Trainer("12", "Mike Jones", "1401 Snow Hinton Dr", "mjones@gmail.com");
System.Console.WriteLine(mike.GetMailingAddress());



Listing aList = new Listing("12", "Mike Jones", "4/3/2023", "11:30 PM", 30.50, "Cancelled");

StreamWriter outFile = new StreamWriter("out.txt");
outFile.WriteLine(aList.ToFile());
System.Console.WriteLine(aList.ToString());
System.Console.WriteLine(aList.GetDate());
System.Console.WriteLine(aList.GetTime());
outFile.Close();

// DateTime today = DateTime.Today;
// System.Console.WriteLine(today.ToShortDateString());
// System.Console.WriteLine(today.ToShortTimeString());


 