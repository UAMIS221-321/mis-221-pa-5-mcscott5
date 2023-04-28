namespace mis_221_pa_5_mcscott5
{
    public class ReportGenerator
    {
        public void PrintIndividualCustomerReport()
        {
            List<Booking> CompletedBookings = new List<Booking>();
            foreach (Booking b in BookingUtility.Bookings)
            {
                if (b.GetStatus() == "Completed")
                {
                    CompletedBookings.Add(b);
                }
            }

            System.Console.WriteLine("Please enter a customer email address: ");
            string inputEmail = "";
           
            inputEmail = Console.ReadLine();
            
                foreach (Booking b in CompletedBookings)
                {
                    if (b.GetCustomerEmail().CompareTo(inputEmail) == 0)
                    {
                        System.Console.WriteLine(b.ToString());
                    }
                }
        }

        public void PrintHistoricalCustomerReports()
        {
            //Completed or all?
            List<Booking> CompletedBookings = new List<Booking>();
            foreach (Booking b in BookingUtility.Bookings)
            {
                if (b.GetStatus() == "Completed")
                {
                    CompletedBookings.Add(b);
                }
            }

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

        }

        public void ProcessBreakMonth(ref int currMonth, ref double monthlyTotal, Booking nextBooking)
        {
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