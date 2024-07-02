using System;
using System.Collections.Generic;
using System.Globalization;

namespace TheatricalPlayersRefactoringKata
{
    public class StatementPrinter
    {
        public string Print(Invoice invoice, Dictionary<string, Play> plays)
        {

            var result = string.Format("Statement for {0}\n", invoice.Customer);
            CultureInfo cultureInfo = new CultureInfo("en-US");

            var resultPlay = "";
            foreach(var perf in invoice.Performances) 
            {
                var play = plays[perf.PlayID];
                var thisAmount = play.GetPlayAmount(perf.Audience);
                // print line for this order
                resultPlay += String.Format(cultureInfo, "  {0}: {1:C} ({2} seats)\n", play.Name, Convert.ToDecimal(thisAmount / 100), perf.Audience);
            }

            result += resultPlay;
            var totalAmount = invoice.TotalAmount(plays);
            var volumeCredits = invoice.VolumeCredits(plays);
            
       
            result += PrintVolumeCredit(volumeCredits, totalAmount);
            return result;
        }

        private static string PrintVolumeCredit(int volumeCredits, int totalAmount)
        {
            CultureInfo cultureInfo = new CultureInfo("en-US");
            return String.Format(cultureInfo, "Amount owed is {0:C}\n", Convert.ToDecimal(totalAmount / 100)) + String.Format("You earned {0} credits\n", volumeCredits);
        }
    }
}
