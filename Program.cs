using mis_221_pa_5_mcscott5;

Trainer mike = new Trainer("12", "Mike Jones", "1401 Snow Hinton Dr", "mjones@gmail.com");
System.Console.WriteLine(mike.GetMailingAddress());
System.Console.WriteLine(mike.ToString());

// DateTime today = DateTime.Today;
// System.Console.WriteLine(today.ToShortDateString());
// System.Console.WriteLine(today.ToShortTimeString());

Listings aList = new Listings();
try{
    aList.SetDate("3-30-2023");
    System.Console.WriteLine(aList.GetDate());
} catch {
    System.Console.WriteLine("Invalid");
}

//System.Console.WriteLine(aList.GetDate()); 