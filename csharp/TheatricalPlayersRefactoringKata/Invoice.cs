using System.Collections.Generic;

namespace TheatricalPlayersRefactoringKata
{
    public class Invoice
    {
        private string _customer;
        private List<Performance> _performances;

        public string Customer { get => _customer; set => _customer = value; }
        public List<Performance> Performances { get => _performances; set => _performances = value; }

        public Invoice(string customer, List<Performance> performance)
        {
            this._customer = customer;
            this._performances = performance;
        }

        public int TotalAmount(Dictionary<string, Play> plays)
        {
            var totalAmount = 0;
            foreach(var perf in Performances) 
            {
                var play = plays[perf.PlayID];
                var thisAmount = play.GetPlayAmount(perf.Audience);
                totalAmount += thisAmount;
            }

            return totalAmount;
        }
    }
}
