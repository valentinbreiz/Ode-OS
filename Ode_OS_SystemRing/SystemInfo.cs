using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.HAL;

namespace Ode_OS_SystemRing
{
    public class DateTime
    {
        public int Second { get; set; }
        public int Minute { get; set; }
        public int Hour { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int DayOfTheWeek { get; set; }

        public string MonthName
        {
            get
            {
                string[] months = { "Janvier", "Fevrier", "Mars", "Avril", "Mai", "Juin", "Juillet", "Aout", "Septembre", "Octobre", "Novembre", "Decembre" };
                return months[Month - 1];
            }
        }

        public override string ToString()
        {
            return $"{MonthName} {Day}, {Year} a {Hour}:{Minute}:{Second}.";
        }
    }

    public static class SystemInfo
    {
        public static DateTime Time
        {
            get
            {
                var dt = new DateTime();
                dt.Second = RTC.Second;
                dt.Minute = RTC.Minute;
                dt.Hour = RTC.Hour;
                dt.Month = RTC.Month;
                dt.Year = RTC.Year;
                dt.Day = RTC.DayOfTheMonth;
                dt.DayOfTheWeek = RTC.DayOfTheWeek;
                return dt;
            }
        }
    }

    public static class SystemHelpers
    {
        private static Waiter waiter = new Waiter();

        public static void Beep(int freq, int len)
        {
            while (SoundPlaying == true)
            {

            }
            waiter.waitAndPlay(freq, len);
        }

        public static bool SoundPlaying { get { return Waiter.playing; } }

        private class Waiter
        {
            private static PCSpeaker pcs = new PCSpeaker();
            private static PIT pit = new PIT();
            public static bool playing = false;

            public void waitAndPlay(int freq, int len)
            {
                playing = true;
                pcs.playSound((uint)freq);
                var t = new PIT.PITTimer(handle_stop, len * 1000000, false);
                pit.RegisterTimer(t);
            }

            public void handle_stop()
            {
                pcs.nosound();
                playing = false;
            }
        }

    }
}
