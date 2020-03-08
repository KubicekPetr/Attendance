using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace attendance
{
    public class Record
    {
        private string time;
        private string end;
        private int endday;

        public string FirstName { get; }
        public string LastName { get; }
        public int StartDay { get; }
        public int EndDay
        {
            get
            {
                return endday;
            }
            set
            {
                if (Ending == "Neukončeno")
                {
                    endday = 0;
                }
                else
                {
                    endday = value;
                }
            }
        }
        public string ConcatDay { get; }

        public int Month { get; }
        public int Year { get; }
        public string Beginning { get; }
        public DateTime Begin { get; }
        public DateTime End { get; }
        public string Ending
        {
            get
            {
                return end;
            }
            set
            {
                if (value == "0:00")
                {
                    end = "Neukončeno";
                }
                else
                {
                    end = value;
                }
            }
        }
        public string Time
        {
            get
            {
                return time.ToString();
            }
            set
            {
                if (Ending == "Neukončeno" & (DateTime.Now - Begin).TotalSeconds <= 86399)
                {
                    time = (DateTime.Now - Begin).ToString().Remove(8, 8);
                }
                else if (Ending != "Neukončeno" & (End - Begin).TotalSeconds <= 86399)
                {
                    time = (End - Begin).ToString();
                }
                else if ((Ending == "Neukončeno" & (DateTime.Now - Begin).TotalSeconds > 86399) | (Ending != "Neukončeno" & (End - Begin).TotalSeconds > 86399))
                {
                    time = "Mimo limit";
                }
                else
                {
                    time = value.ToString();
                }
            }
        }

        public Record(DateTime beginning, DateTime end)
        {
            Month = beginning.Month;
            Year = beginning.Year;

            Beginning = beginning.ToString("H:mm");
            Ending = end.ToString("H:mm");

            StartDay = beginning.Day;
            EndDay = end.Day;

            //Property Begin se musí nastavit před property Time, protože Time s ní následně pracuje!
            Begin = beginning;
            End = end;
            Time = (end - beginning).ToString();

            if (StartDay == EndDay)
            {
                ConcatDay = StartDay.ToString();
            }
            else if (StartDay != EndDay & EndDay == 0)
            {
                ConcatDay = StartDay.ToString();
            }
            else
            {
                ConcatDay = StartDay + " až " + EndDay;
            }
        }

        public Record(string firstname, string lastname, DateTime beginning, DateTime end)
        {
            FirstName = firstname;
            LastName = lastname;

            Month = beginning.Month;
            Year = beginning.Year;

            Beginning = beginning.ToString("H:mm");
            Ending = end.ToString("H:mm");

            StartDay = beginning.Day;
            EndDay = end.Day;

            //Property Begin se musí nastavit před property Time, protože Time s ní následně pracuje!
            Begin = beginning;
            End = end;
            Time = (end - beginning).ToString();

            if (StartDay == EndDay)
            {
                ConcatDay = StartDay.ToString();
            }
            else if (StartDay != EndDay & EndDay == 0)
            {
                ConcatDay = StartDay.ToString();
            }
            else
            {
                ConcatDay = StartDay + " až " + EndDay;
            }
        }
    }
}
