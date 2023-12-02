using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ACSystem.Infrastructure.Utilities
{
    public static class DateAndTimeShamsi
    {

       

        public static string DateTimeShamsi()
        {
            var currentDate = DateTime.Now;

            PersianCalendar pcCalender = new PersianCalendar();

            int year = pcCalender.GetYear(currentDate);
            int month = pcCalender.GetMonth(currentDate);
            int day = pcCalender.GetDayOfMonth(currentDate);

            int hour = pcCalender.GetHour(currentDate);
            int min = pcCalender.GetMinute(currentDate);

           
            return String.Format(@"{0}/{1}/{2}  {3}:{4}", year, month, day, hour, min);


        }



        public static string ToPersianDateTimeString(this DateTime dateTime)
        {
            PersianCalendar pc = new PersianCalendar();

            int year = pc.GetYear(dateTime);
            int month = pc.GetMonth(dateTime);
            int day = pc.GetDayOfMonth(dateTime);

            int hour = pc.GetHour(dateTime);
            int min = pc.GetMinute(dateTime);
          

            return String.Format(@"{0}/{1}/{2}  {3}:{4}", year, month, day , hour, min);
        }


        public static DateTime ShamsiToMiladi(this string dateTime)
        {
            int day = Convert.ToInt32(dateTime.Split('/')[2]);
            int month = Convert.ToInt32(dateTime.Split('/')[1]);
            int year = Convert.ToInt32(dateTime.Split('/')[0]);

            var persianCalendar = new PersianCalendar();
            var date = persianCalendar.ToDateTime(year, month, day, 23, 0, 0, 0);

            return date;

        }


        public static DateTime ToMiladiDate(this DateTime dt)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.ToDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0, 0);
        }

    }
}
