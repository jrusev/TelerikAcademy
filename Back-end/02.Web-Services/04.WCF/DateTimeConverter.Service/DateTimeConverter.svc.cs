namespace DateTimeConverter.Service
{
    using System;
    using System.Globalization;

    public class DateTimeConverter : IDateTimeConverter
    {
        // You can test the service by selecting the .svc file and pressing F5,
        // this will open the WCF Test Client
        public string GetDayOfWeek(DateTime date)
        {
            var cultureBG = new CultureInfo("bg-BG");
            string dayOfWeek = cultureBG.DateTimeFormat.DayNames[(int)date.DayOfWeek];

            return dayOfWeek;
        }
    }
}
