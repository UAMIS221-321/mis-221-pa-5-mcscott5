using mis_221_pa_5_mcscott5;

Trainer mike = new Trainer("12", "Mike Jones", "1401 Snow Hinton Dr", "mjones@gmail.com");
System.Console.WriteLine(mike.GetMailingAddress());
StreamWriter outFile = new StreamWriter("out.txt");
outFile.WriteLine(mike.ToFile());
System.Console.WriteLine(mike.ToString());
outFile.Close();
// DateTime today = DateTime.Today;
// System.Console.WriteLine(today.ToShortDateString());
// System.Console.WriteLine(today.ToShortTimeString());


//System.Console.WriteLine(aList.GetDate()); 