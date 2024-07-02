using System;

namespace TheatricalPlayersRefactoringKata
{
    public class Play
    {
        private string _name;
        private string _type;

        public string Name { get => _name; set => _name = value; }
        public string Type { get => _type; set => _type = value; }

        public Play(string name, string type) {
            this._name = name;
            this._type = type;
        }

        public int GetPlayAmount(int perfAudience)
        {
            var thisAmount = 0;
            switch (Type) 
            {
                case "tragedy":
                    thisAmount = 40000;
                    if (perfAudience > 30) {
                        thisAmount += 1000 * (perfAudience - 30);
                    }
                    break;
                case "comedy":
                    thisAmount = 30000;
                    if (perfAudience > 20) {
                        thisAmount += 10000 + 500 * (perfAudience - 20);
                    }
                    thisAmount += 300 * perfAudience;
                    break;
                default:
                    throw new Exception("unknown type: " + Type);
            }

            return thisAmount;
        }

        public int VolumeCreditPlay(Performance perf)
        {
            // add volume credits
            var volumeCreditPlay = Math.Max(perf.Audience - 30, 0);
            // add extra credit for every ten comedy attendees
            if ("comedy" == Type) volumeCreditPlay += (int)Math.Floor((decimal)perf.Audience / 5);
            return volumeCreditPlay;
        }
    }
}
