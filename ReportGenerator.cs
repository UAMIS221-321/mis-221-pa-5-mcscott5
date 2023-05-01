namespace mis_221_pa_5_mcscott5
{
    public class ReportGenerator
    {
        public void PrintIndividualCustomerReport()
        {
            List<Booking> CompletedBookings = new List<Booking>();
            foreach (Booking b in BookingUtility.Bookings)
            {

                CompletedBookings.Add(b);

            }

            System.Console.WriteLine("Please enter a customer email address: ");
            string inputEmail = "";

            inputEmail = Console.ReadLine();
            bool found = false;

            foreach (Booking b in CompletedBookings)
            {
                if (b.GetCustomerEmail().CompareTo(inputEmail) == 0)
                {
                    found = true;
                    System.Console.WriteLine(b.ToString());
                }
            }

            if (!found)
            {
                System.Console.WriteLine("No customers with email " + inputEmail + " exist!");
                return;
            }

            System.Console.WriteLine("Would you to save this document to a file? (Y/N)");
            string fileOption = Console.ReadLine();

            if (fileOption == "Y" || fileOption == "y")
            {
                System.Console.WriteLine("Please enter file name to send the file to: ");
                string outputFileName = Console.ReadLine();
                StreamWriter outFile = new StreamWriter($"{outputFileName}.txt");

                foreach (Booking b in CompletedBookings)
                {
                    if (b.GetCustomerEmail().CompareTo(inputEmail) == 0)
                    {
                        outFile.WriteLine(b.ToString());
                        outFile.WriteLine("__________________________________");
                    }
                }

                outFile.Close();
            }
            else
            {
                return;
            }

        }

        public void IncomeStatement()
        {
            List<Booking> CompletedBookings = new List<Booking>();
            foreach (Booking b in BookingUtility.Bookings)
            {
                if (b.GetStatus() == "Completed")
                    CompletedBookings.Add(b);
            }

            for (int i = 0; i < CompletedBookings.Count - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < CompletedBookings.Count; j++)
                {
                    if ((DateOnly.Parse(CompletedBookings[j].GetDate()).CompareTo(DateOnly.Parse(CompletedBookings[minIndex].GetDate())) < 0) || ((DateOnly.Parse(CompletedBookings[j].GetDate()).CompareTo(DateOnly.Parse(CompletedBookings[minIndex].GetDate())) == 0) && (CompletedBookings[j].GetCustomerName().CompareTo(CompletedBookings[minIndex].GetCustomerName()) < 0)))
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    Swap(minIndex, i, CompletedBookings);
                }
            }

            foreach (Booking b in CompletedBookings)
            {
                System.Console.WriteLine(b.ToString());
                System.Console.WriteLine("__________________________________");
            }

            double netSales;
            double costOfSales;
            double grossProfit;
            double adminExpenses;
            double operatingIncome;
            double incomeTax;
            double netIncome;


            int currYear;
            double yearlyTotal;



            try
            {
                currYear = DateOnly.Parse(CompletedBookings[0].GetDate()).Year;
                netSales = CompletedBookings[0].GetCost();
                adminExpenses = CompletedBookings[0].GetCost() * 0.50;
            }
            catch
            {
                System.Console.WriteLine("No completed bookings!");
                return;
            }

            System.Console.WriteLine("Income Statement");
            System.Console.WriteLine("For Years Ended December 31");


            for (int i = 1; i < CompletedBookings.Count; i++)
            {
                if ((DateOnly.Parse(CompletedBookings[i].GetDate()).Year == currYear))
                {
                    netSales += CompletedBookings[i].GetCost();
                    adminExpenses += CompletedBookings[i].GetCost() * 0.50;
                }
                else
                {
                    //ProcessBreakMonth(ref currMonth, ref monthlyTotal, CompletedBookings[i]);
                    costOfSales = netSales * 0.40;
                    grossProfit = netSales - costOfSales;
                    operatingIncome = grossProfit - adminExpenses;
                    incomeTax = operatingIncome * 0.10;
                    netIncome = operatingIncome - incomeTax;

                    System.Console.WriteLine(currYear + "\t");
                    System.Console.WriteLine("----");
                    System.Console.WriteLine($"Net Sales\t\t{netSales:C}\t");
                    System.Console.WriteLine($"Cost of Sales\t\t{costOfSales:C}\t");
                    System.Console.WriteLine("-------------");
                    System.Console.WriteLine($"Gross Profit\t\t{grossProfit:C}\t");
                    System.Console.WriteLine($"Selling, Operating, and Administrative Expenses\t\t{adminExpenses:C}\t");
                    System.Console.WriteLine("-------------");
                    System.Console.WriteLine($"Operating Income\t\t{operatingIncome:C}\t");
                    System.Console.WriteLine($"Income Tax Expense\t\t{incomeTax:C}\t");
                    System.Console.WriteLine("-------------");
                    System.Console.WriteLine($"Net Income\t\t{netIncome:C}\t");
                    System.Console.WriteLine("");
                    System.Console.WriteLine("");

                    currYear = DateOnly.Parse(CompletedBookings[i].GetDate()).Year;
                    netSales = CompletedBookings[i].GetCost();
                    adminExpenses = CompletedBookings[i].GetCost() * 0.50;

                }
            }

            costOfSales = netSales * 0.40;
            grossProfit = netSales - costOfSales;
            operatingIncome = grossProfit - adminExpenses;
            incomeTax = operatingIncome * 0.10;
            netIncome = operatingIncome - incomeTax;

            System.Console.WriteLine(currYear + "\t");
            System.Console.WriteLine("----");
            System.Console.WriteLine($"Net Sales\t\t{netSales:C}\t");
            System.Console.WriteLine($"Cost of Sales\t\t{costOfSales:C}\t");
            System.Console.WriteLine("-------------");
            System.Console.WriteLine($"Gross Profit\t\t{grossProfit:C}\t");
            System.Console.WriteLine($"Selling, Operating, and Administrative Expenses\t\t{adminExpenses:C}\t");
            System.Console.WriteLine("-------------");
            System.Console.WriteLine($"Operating Income\t\t{operatingIncome:C}\t");
            System.Console.WriteLine($"Income Tax Expense\t\t{incomeTax:C}\t");
            System.Console.WriteLine("-------------");
            System.Console.WriteLine($"Net Income\t\t{netIncome:C}\t");
            System.Console.WriteLine("");
            System.Console.WriteLine("");

        }

        public void AverageRevenueByTrainerChart()
        {

        }

        public void RetrieveTrainerName()
        {

        }

        public void PrintHistoricalCustomerReports()
        {
            //Completed or all?
            List<Booking> CompletedBookings = new List<Booking>();
            foreach (Booking b in BookingUtility.Bookings)
            {

                CompletedBookings.Add(b);

            }

            for (int i = 0; i < CompletedBookings.Count - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < CompletedBookings.Count; j++)
                {
                    if ((CompletedBookings[j].GetCustomerName().CompareTo(CompletedBookings[minIndex].GetCustomerName()) < 0) || (CompletedBookings[j].GetCustomerName().CompareTo(CompletedBookings[minIndex].GetCustomerName()) == 0) && DateOnly.Parse(CompletedBookings[j].GetDate()).CompareTo(DateOnly.Parse(CompletedBookings[minIndex].GetDate())) < 0)
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    Swap(minIndex, i, CompletedBookings);
                }
            }

            foreach (Booking b in CompletedBookings)
            {
                System.Console.WriteLine(b.ToString());
                System.Console.WriteLine("__________________________________");
            }

            string currCustomer;
            int sessionCount;

            try
            {
                currCustomer = CompletedBookings[0].GetCustomerName();
                sessionCount = 1;
            }
            catch
            {
                System.Console.WriteLine("No completed bookings!");
                return;
            }

            //System.Console.WriteLine(CompletedBookings[0].ToString());

            for (int i = 1; i < CompletedBookings.Count; i++)
            {
                //System.Console.WriteLine(CompletedBookings[i].ToString());
                if (CompletedBookings[i].GetCustomerName().CompareTo(currCustomer) == 0)
                {
                    //System.Console.WriteLine(CompletedBookings[i].ToString());
                    sessionCount++;
                }
                else
                {
                    ProcessBreakCustomer(ref currCustomer, ref sessionCount, CompletedBookings[i]);
                }
            }

            ProcessBreakCustomer2(ref currCustomer, ref sessionCount);

            System.Console.WriteLine("Would you to save this document to a file? (Y/N)");
            string fileOption = Console.ReadLine();

            if (fileOption == "Y" || fileOption == "y")
            {
                System.Console.WriteLine("Please enter file name to send the file to: ");
                string outputFileName = Console.ReadLine();
                StreamWriter outFile = new StreamWriter($"{outputFileName}.txt");

                foreach (Booking b in CompletedBookings)
                {
                    outFile.WriteLine(b.ToString());
                    outFile.WriteLine("__________________________________");
                }

                currCustomer = CompletedBookings[0].GetCustomerName();
                sessionCount = 1;

                for (int i = 1; i < CompletedBookings.Count; i++)
                {

                    if (CompletedBookings[i].GetCustomerName().CompareTo(currCustomer) == 0)
                    {

                        sessionCount++;
                    }
                    else
                    {
                        //ProcessBreakCustomer(ref currCustomer, ref sessionCount, CompletedBookings[i]);
                        outFile.WriteLine(currCustomer + "'s Session Total:\t" + sessionCount);
                        currCustomer = CompletedBookings[i].GetCustomerName();
                        sessionCount = 1;
                    }
                }

                //ProcessBreakCustomer2(ref currCustomer, ref sessionCount);
                outFile.WriteLine(currCustomer + "'s Session Total:\t" + sessionCount);

                outFile.Close();
            }
            else
            {
                return;
            }

        }

        public void ProcessBreakCustomer(ref string currCustomer, ref int sessionCount, Booking nextBooking)
        {
            System.Console.WriteLine(currCustomer + "'s Session Total:\t" + sessionCount);
            currCustomer = nextBooking.GetCustomerName();
            sessionCount = 1;
        }
        public void ProcessBreakCustomer2(ref string currCustomer, ref int sessionCount)
        {
            System.Console.WriteLine(currCustomer + "'s Session Total:\t" + sessionCount);
        }

        public void PrintHistoricalRevenueReports()
        {
            List<Booking> CompletedBookings = new List<Booking>();
            foreach (Booking b in BookingUtility.Bookings)
            {
                if (b.GetStatus() == "Completed")
                {
                    CompletedBookings.Add(b);
                }
            }

            for (int i = 0; i < CompletedBookings.Count - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < CompletedBookings.Count; j++)
                {
                    if (DateOnly.Parse(CompletedBookings[j].GetDate()).Year < DateOnly.Parse(CompletedBookings[minIndex].GetDate()).Year || (DateOnly.Parse(CompletedBookings[j].GetDate()).Year == DateOnly.Parse(CompletedBookings[minIndex].GetDate()).Year && DateOnly.Parse(CompletedBookings[j].GetDate()).Month < DateOnly.Parse(CompletedBookings[minIndex].GetDate()).Month))
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    Swap(minIndex, i, CompletedBookings);
                }
            }

            foreach (Booking b in CompletedBookings)
            {
                System.Console.WriteLine(b.ToString());
            }

            int currMonth;
            int currYear;
            double monthlyTotal;
            double yearlyTotal;

            try
            {
                currMonth = DateOnly.Parse(CompletedBookings[0].GetDate()).Month;
                currYear = DateOnly.Parse(CompletedBookings[0].GetDate()).Year;
                monthlyTotal = CompletedBookings[0].GetCost();
                yearlyTotal = CompletedBookings[0].GetCost();
            }
            catch
            {
                System.Console.WriteLine("No completed bookings!");
                return;
            }

            for (int i = 1; i < CompletedBookings.Count; i++)
            {
                if ((DateOnly.Parse(CompletedBookings[i].GetDate()).Month == currMonth) && (DateOnly.Parse(CompletedBookings[i].GetDate()).Year == currYear))
                {
                    monthlyTotal += CompletedBookings[i].GetCost();
                }
                else
                {
                    ProcessBreakMonth(ref currMonth, ref monthlyTotal, CompletedBookings[i]);
                }

                if ((DateOnly.Parse(CompletedBookings[i].GetDate()).Year == currYear))
                {
                    yearlyTotal += CompletedBookings[i].GetCost();
                }
                else
                {
                    ProcessBreakYear(ref currYear, ref yearlyTotal, CompletedBookings[i]);
                }
            }

            ProcessBreakMonth2(ref currMonth, ref monthlyTotal);
            ProcessBreakYear2(ref currYear, ref yearlyTotal);

            System.Console.WriteLine("Would you to save this document to a file? (Y/N)");
            string fileOption = Console.ReadLine();

            if (fileOption == "Y" || fileOption == "y")
            {
                System.Console.WriteLine("Please enter file name to send the file to: ");
                string outputFileName = Console.ReadLine();
                StreamWriter outFile = new StreamWriter($"{outputFileName}.txt");

                currMonth = DateOnly.Parse(CompletedBookings[0].GetDate()).Month;
                currYear = DateOnly.Parse(CompletedBookings[0].GetDate()).Year;
                monthlyTotal = CompletedBookings[0].GetCost();
                yearlyTotal = CompletedBookings[0].GetCost();
                string monthName = "";

                for (int i = 1; i < CompletedBookings.Count; i++)
                {
                    if ((DateOnly.Parse(CompletedBookings[i].GetDate()).Month == currMonth) && (DateOnly.Parse(CompletedBookings[i].GetDate()).Year == currYear))
                    {
                        monthlyTotal += CompletedBookings[i].GetCost();
                    }
                    else
                    {
                        //ProcessBreakMonth(ref currMonth, ref monthlyTotal, CompletedBookings[i]);
                        DateTime myDate = new DateTime(2020, currMonth, 1);
                        monthName = myDate.ToString("MMMM");
                        outFile.WriteLine(monthName + "\t" + monthlyTotal);
                        currMonth = DateOnly.Parse(CompletedBookings[i].GetDate()).Month;
                        monthlyTotal = CompletedBookings[i].GetCost();
                    }

                    if ((DateOnly.Parse(CompletedBookings[i].GetDate()).Year == currYear))
                    {
                        yearlyTotal += CompletedBookings[i].GetCost();
                    }
                    else
                    {
                        //ProcessBreakYear(ref currYear, ref yearlyTotal, CompletedBookings[i]);
                        outFile.WriteLine(currYear + "\t" + yearlyTotal);
                        outFile.WriteLine("__________________________________");
                        currYear = DateOnly.Parse(CompletedBookings[i].GetDate()).Year;
                        yearlyTotal = CompletedBookings[i].GetCost();
                    }
                }

                // ProcessBreakMonth2(ref currMonth, ref monthlyTotal);
                // ProcessBreakYear2(ref currYear, ref yearlyTotal);
                DateTime date = new DateTime(2020, currMonth, 1);
                monthName = date.ToString("MMMM");
                outFile.WriteLine(monthName + "\t" + monthlyTotal);

                outFile.WriteLine(currYear + "\t" + yearlyTotal);
                outFile.WriteLine("__________________________________");

                outFile.Close();
            }
            else
            {
                return;
            }

        }

        public void PrintHistoricalRevenueChart()
        {
            List<Booking> CompletedBookings = new List<Booking>();
            foreach (Booking b in BookingUtility.Bookings)
            {
                if (b.GetStatus() == "Completed")
                {
                    CompletedBookings.Add(b);
                }
            }

            for (int i = 0; i < CompletedBookings.Count - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < CompletedBookings.Count; j++)
                {
                    if (DateOnly.Parse(CompletedBookings[j].GetDate()).Year < DateOnly.Parse(CompletedBookings[minIndex].GetDate()).Year || (DateOnly.Parse(CompletedBookings[j].GetDate()).Year == DateOnly.Parse(CompletedBookings[minIndex].GetDate()).Year && DateOnly.Parse(CompletedBookings[j].GetDate()).Month < DateOnly.Parse(CompletedBookings[minIndex].GetDate()).Month))
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    Swap(minIndex, i, CompletedBookings);
                }
            }

            foreach (Booking b in CompletedBookings)
            {
                System.Console.WriteLine(b.ToString());
            }

            int currMonth;
            int currYear;
            double monthlyTotal;
            double yearlyTotal;
            string monthName = "";

            try
            {
                currMonth = DateOnly.Parse(CompletedBookings[0].GetDate()).Month;
                currYear = DateOnly.Parse(CompletedBookings[0].GetDate()).Year;
                monthlyTotal = CompletedBookings[0].GetCost();
                yearlyTotal = CompletedBookings[0].GetCost();
            }
            catch
            {
                System.Console.WriteLine("No completed bookings!");
                return;
            }

            for (int i = 1; i < CompletedBookings.Count; i++)
            {
                if ((DateOnly.Parse(CompletedBookings[i].GetDate()).Month == currMonth) && (DateOnly.Parse(CompletedBookings[i].GetDate()).Year == currYear))
                {
                    monthlyTotal += CompletedBookings[i].GetCost();
                }
                else
                {
                    DateTime myDate = new DateTime(2020, currMonth, 1);
                    monthName = myDate.ToString("MMMM");
                    //ProcessBreakMonth(ref currMonth, ref monthlyTotal, CompletedBookings[i]);
                    Console.Write(" ");
                    System.Console.WriteLine(monthName);

                    Console.BackgroundColor = ConsoleColor.DarkBlue;

                    for (var k = 0; k < monthlyTotal; k++)
                        Console.Write("⊡");

                    //Console.BackgroundColor = ConsoleColor.Black;
                    Console.ResetColor();

                    Console.Write(" ");

                    Console.WriteLine(monthlyTotal);

                    //System.Console.WriteLine(monthName + "\t" + monthlyTotal);
                    currMonth = DateOnly.Parse(CompletedBookings[i].GetDate()).Month;
                    monthlyTotal = CompletedBookings[i].GetCost();
                }

                if ((DateOnly.Parse(CompletedBookings[i].GetDate()).Year == currYear))
                {
                    yearlyTotal += CompletedBookings[i].GetCost();
                }
                else
                {
                    //ProcessBreakYear(ref currYear, ref yearlyTotal, CompletedBookings[i]);
                    // DateTime date = new DateTime(2020, currMonth, 1);
                    // string monthName = date.ToString("MMMM");
                    //ProcessBreakMonth(ref currMonth, ref monthlyTotal, CompletedBookings[i]);
                    // Console.Write(" ");
                    // System.Console.WriteLine(currYear);

                    // Console.BackgroundColor = ConsoleColor.DarkBlue;

                    // for (var k = 0; k < monthlyTotal; k++)
                    //     Console.Write("#");

                    // Console.BackgroundColor = ConsoleColor.Black;

                    // Console.Write(" ");

                    // Console.WriteLine(yearlyTotal);

                    //System.Console.WriteLine(monthName + "\t" + monthlyTotal);
                    System.Console.WriteLine(currYear + "\t" + yearlyTotal);
                    System.Console.WriteLine("__________________________________");
                    currYear = DateOnly.Parse(CompletedBookings[i].GetDate()).Year;
                    yearlyTotal = CompletedBookings[i].GetCost();
                }
            }

            DateTime date = new DateTime(2020, currMonth, 1);
            monthName = date.ToString("MMMM");
            //ProcessBreakMonth(ref currMonth, ref monthlyTotal, CompletedBookings[i]);
            Console.Write(" ");
            System.Console.WriteLine(monthName);

            Console.BackgroundColor = ConsoleColor.DarkBlue;

            for (var k = 0; k < monthlyTotal; k++)
                Console.Write("⊡");

            //Console.BackgroundColor = ConsoleColor.Black;
            Console.ResetColor();

            Console.Write(" ");

            Console.WriteLine(monthlyTotal);

            System.Console.WriteLine(currYear + "\t" + yearlyTotal);
            System.Console.WriteLine("__________________________________");


            System.Console.WriteLine("Would you to save this document to a file? (Y/N)");
            string fileOption = Console.ReadLine();

            if (fileOption == "Y" || fileOption == "y")
            {
                System.Console.WriteLine("Please enter file name to send the file to: ");
                string outputFileName = Console.ReadLine();
                StreamWriter outFile = new StreamWriter($"{outputFileName}.txt");

                currMonth = DateOnly.Parse(CompletedBookings[0].GetDate()).Month;
                currYear = DateOnly.Parse(CompletedBookings[0].GetDate()).Year;
                monthlyTotal = CompletedBookings[0].GetCost();
                yearlyTotal = CompletedBookings[0].GetCost();
                monthName = "";

                for (int i = 1; i < CompletedBookings.Count; i++)
                {
                    if ((DateOnly.Parse(CompletedBookings[i].GetDate()).Month == currMonth) && (DateOnly.Parse(CompletedBookings[i].GetDate()).Year == currYear))
                    {
                        monthlyTotal += CompletedBookings[i].GetCost();
                    }
                    else
                    {
                        //ProcessBreakMonth(ref currMonth, ref monthlyTotal, CompletedBookings[i]);
                        DateTime myDate = new DateTime(2020, currMonth, 1);
                        monthName = myDate.ToString("MMMM");
                        //ProcessBreakMonth(ref currMonth, ref monthlyTotal, CompletedBookings[i]);
                        outFile.Write(" ");
                        outFile.WriteLine(monthName);

                        //Console.BackgroundColor = ConsoleColor.DarkBlue;

                        for (var k = 0; k < monthlyTotal; k++)
                            outFile.Write("⊡");

                        //Console.BackgroundColor = ConsoleColor.Black;

                        outFile.Write(" ");

                        
                        outFile.WriteLine(monthlyTotal);

                        //System.Console.WriteLine(monthName + "\t" + monthlyTotal);
                        currMonth = DateOnly.Parse(CompletedBookings[i].GetDate()).Month;
                        monthlyTotal = CompletedBookings[i].GetCost();
                    }

                    if ((DateOnly.Parse(CompletedBookings[i].GetDate()).Year == currYear))
                    {
                        yearlyTotal += CompletedBookings[i].GetCost();
                    }
                    else
                    {
                        //ProcessBreakYear(ref currYear, ref yearlyTotal, CompletedBookings[i]);
                        outFile.WriteLine(currYear + "\t" + yearlyTotal);
                        outFile.WriteLine("__________________________________");
                        currYear = DateOnly.Parse(CompletedBookings[i].GetDate()).Year;
                        yearlyTotal = CompletedBookings[i].GetCost();

                    }
                }

                // ProcessBreakMonth2(ref currMonth, ref monthlyTotal);
                // ProcessBreakYear2(ref currYear, ref yearlyTotal);
                DateTime ndate = new DateTime(2020, currMonth, 1);
                monthName = ndate.ToString("MMMM");
                //ProcessBreakMonth(ref currMonth, ref monthlyTotal, CompletedBookings[i]);
                outFile.Write(" ");
                outFile.WriteLine(monthName);

                //outFile.BackgroundColor = outFile.DarkBlue;

                for (var k = 0; k < monthlyTotal; k++)
                    outFile.Write("⊡");

                //outFile.BackgroundColor = ConsoleColor.Black;

                outFile.Write(" ");

                outFile.WriteLine(monthlyTotal);

                outFile.WriteLine(currYear + "\t" + yearlyTotal);
                outFile.WriteLine("__________________________________");

                outFile.Close();
            }
            else
            {
                return;
            }



        }
        public void ProcessBreakMonth(ref int currMonth, ref double monthlyTotal, Booking nextBooking)
        {
            //Console.Write(item.Key.PadLeft(max));

            Console.Write(" ");

            // change color
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            // Write the bars
            for (var i = 0; i < monthlyTotal; i++)
                Console.Write("#");

            // change back
            Console.BackgroundColor = ConsoleColor.Black;

            Console.Write(" ");
            // this creates the new line
            Console.WriteLine(monthlyTotal);
            DateTime date = new DateTime(2020, currMonth, 1);
            string monthName = date.ToString("MMMM");
            System.Console.WriteLine(monthName + "\t" + monthlyTotal);
            currMonth = DateOnly.Parse(nextBooking.GetDate()).Month;
            monthlyTotal = nextBooking.GetCost();
        }
        public void ProcessBreakYear(ref int currYear, ref double yearlyTotal, Booking nextBooking)
        {
            System.Console.WriteLine(currYear + "\t" + yearlyTotal);
            currYear = DateOnly.Parse(nextBooking.GetDate()).Year;
            yearlyTotal = nextBooking.GetCost();
        }

        public void ProcessBreakMonth2(ref int currMonth, ref double monthlyTotal)
        {
            DateTime date = new DateTime(2020, currMonth, 1);
            string monthName = date.ToString("MMMM");
            System.Console.WriteLine(monthName + "\t" + monthlyTotal);
        }

        public void ProcessBreakYear2(ref int currYear, ref double yearlyTotal)
        {
            System.Console.WriteLine(currYear + "\t" + yearlyTotal);
        }

        public void Swap(int x, int y, List<Booking> bookings)
        {
            Booking temp = bookings[x];
            bookings[x] = bookings[y];
            bookings[y] = temp;
        }




    }
}