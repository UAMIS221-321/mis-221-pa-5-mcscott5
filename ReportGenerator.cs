namespace mis_221_pa_5_mcscott5
{
    public class ReportGenerator
    {
        public void PrintIndividualCustomerReport()
        {

        }

        public void PrintHistoricalCustomerReports()
        {

        }

        public void PrintHistoricalRevenueReports()
        {
            for (int i = 0; i < ListingUtility.Listings.Count - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < ListingUtility.Listings.Count; j++)
                {
                    if (DateOnly.Parse(ListingUtility.Listings[j].GetDate()).Year < DateOnly.Parse(ListingUtility.Listings[minIndex].GetDate()).Year || (DateOnly.Parse(ListingUtility.Listings[j].GetDate()).Year == DateOnly.Parse(ListingUtility.Listings[minIndex].GetDate()).Year && DateOnly.Parse(ListingUtility.Listings[j].GetDate()).Month < DateOnly.Parse(ListingUtility.Listings[minIndex].GetDate()).Month))
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    Swap(minIndex, i, ListingUtility.Listings);
                }
            }

            foreach (Listing l in ListingUtility.Listings)
            {
                System.Console.WriteLine(l.ToString());
            }

            int currMonth = DateOnly.Parse(ListingUtility.Listings[0].GetDate()).Month;
            int currYear = DateOnly.Parse(ListingUtility.Listings[0].GetDate()).Year;
            double monthlyTotal = ListingUtility.Listings[0].GetCost();
            double yearlyTotal = ListingUtility.Listings[0].GetCost();

            for (int i = 1; i < ListingUtility.Listings.Count; i++)
            {
                    if ((DateOnly.Parse(ListingUtility.Listings[i].GetDate()).Month == currMonth) && (DateOnly.Parse(ListingUtility.Listings[i].GetDate()).Year == currYear))
                    {
                        monthlyTotal += ListingUtility.Listings[i].GetCost();
                    } else
                    {
                        ProcessBreakMonth(ref currMonth, ref monthlyTotal, ListingUtility.Listings[i]);
                    }

                    if ((DateOnly.Parse(ListingUtility.Listings[i].GetDate()).Year == currYear)){
                        yearlyTotal += ListingUtility.Listings[i].GetCost();
                    }
                    else{
                        ProcessBreakYear(ref currYear, ref yearlyTotal, ListingUtility.Listings[i]);
                    }
            }

            ProcessBreakMonth2(ref currMonth, ref monthlyTotal);
            ProcessBreakYear2(ref currYear, ref yearlyTotal);

        }

        public void ProcessBreakMonth(ref int currMonth, ref double monthlyTotal, Listing nextListing)
        {
            System.Console.WriteLine(currMonth + "\t" + monthlyTotal);
            currMonth = DateOnly.Parse(nextListing.GetDate()).Month;
            monthlyTotal = nextListing.GetCost();
        }
        public void ProcessBreakYear(ref int currYear, ref double yearlyTotal, Listing nextListing)
        {
            System.Console.WriteLine(currYear + "\t" + yearlyTotal);
            currYear = DateOnly.Parse(nextListing.GetDate()).Year;
            yearlyTotal = nextListing.GetCost();
        }

        public void ProcessBreakMonth2(ref int currMonth, ref double monthlyTotal)
        {
            System.Console.WriteLine(currMonth + "\t" + monthlyTotal);
        }

        public void ProcessBreakYear2(ref int currYear, ref double yearlyTotal)
        {
            System.Console.WriteLine(currYear + "\t" + yearlyTotal);
        }

        public void Swap(int x, int y, List<Listing> listings)
        {
            Listing temp = listings[x];
            listings[x] = listings[y];
            listings[y] = temp;
        }




    }
}