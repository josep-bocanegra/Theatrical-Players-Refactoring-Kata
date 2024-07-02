using System;
using System.Collections.Generic;
using System.Globalization;

namespace TheatricalPlayersRefactoringKata
{
    public class StatementPrinter
    {
        public string Print(Invoice invoice, Dictionary<string, Play> plays)
        {
            var totalAmount = 0;
            var volumeCredits = 0;
            var result = string.Format("Statement for {0}\n", invoice.Customer);
            CultureInfo cultureInfo = new CultureInfo("en-US");

            foreach(var perf in invoice.Performances) 
            {
                var play = plays[perf.PlayID];
                var thisAmount = play.GetPlayAmount(perf.Audience);
                // print line for this order
                result += String.Format(cultureInfo, "  {0}: {1:C} ({2} seats)\n", play.Name, Convert.ToDecimal(thisAmount / 100), perf.Audience);
                totalAmount += thisAmount;
            }
            foreach(var perf in invoice.Performances) 
            {
                var play = plays[perf.PlayID]; 
                var volumeCreditPlay = VolumeCreditPlay(perf, play);
                volumeCredits += volumeCreditPlay;
            }
            result += String.Format(cultureInfo, "Amount owed is {0:C}\n", Convert.ToDecimal(totalAmount / 100));
            result += String.Format("You earned {0} credits\n", volumeCredits);
            return result;
        }

        private static int VolumeCreditPlay(Performance perf, Play play)
        {
            // add volume credits
            var volumeCreditPlay = Math.Max(perf.Audience - 30, 0);
            // add extra credit for every ten comedy attendees
            if ("comedy" == play.Type) volumeCreditPlay += (int)Math.Floor((decimal)perf.Audience / 5);
            return volumeCreditPlay;
        }
    }
}
