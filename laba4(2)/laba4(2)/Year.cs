using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
//Створити об'єкт класу Рік, використовуючи класи Місяць, День. 
//Методи: задати дату, вивести на консоль день тижня по заданій даті,
//розрахувати кількість днів, місяців в заданому часовому проміжку.


namespace laba4;
class Date //Year
{
    Month month;
    Day day;

    public int getDay() {
        return day.dayNumber;
    }
    public int getMonth()
    {
        return month.monthNumber;
    }

    public Date(int month, int day)
    {

        this.month = new Month(month);
        this.day = new Day(day);
    }


    public void PrintWeekDay()
    {
        int totalDays = this.month.ToDays() + this.day.dayNumber;
        Console.WriteLine("totalDays=" + totalDays);

        int rest = totalDays % 7;
        string[] weekDays = { "ST", "SN", "MN", "TU", "WD", "TH", "FR" };

        Console.WriteLine(weekDays[rest]);
    }
    public void Print()
    {
        Console.WriteLine("2023-" + this.month.monthNumber + "-" + this.day.dayNumber);
    }

    public class Month
    {
        int[] daysInMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        public int monthNumber;
        public Month(int monthNumber)
        {
            this.monthNumber = monthNumber;
        }

        public int getDaysInMonth() {
            return daysInMonth[monthNumber - 1];
        }

        public int ToDays()
        {
            int days = 0;
            for (int i = 0; i < monthNumber - 1; i++)
            {
                days = days + daysInMonth[i];
            }
            return days;
        }
    }
    public class Day
    {
        public Day(int dayNumber)
        {
            this.dayNumber = dayNumber;
        }
        public int dayNumber;

    }

    public  static Interval getInterval(Date d1, Date d2) 
    {
        int dayDiff = 0;
        int monthDiff = 0;
        if (d2.getMonth() > d1.getMonth() && d2.getDay() < d1.getDay())
        {
            int daysInMonth =  d2.month.getDaysInMonth();
            d2 = new Date(d2.getMonth()-1, d2.getDay() + daysInMonth);
        }
        if (d1.getDay() < d2.getDay())
        {
            dayDiff = d2.getDay() - d1.getDay();
             
        }
        else if (d1.getDay() > d2.getDay())
        {
            dayDiff = d1.getDay() - d2.getDay();

        }
        if (d1.getMonth() < d2.getMonth())
        {
           monthDiff = d2.getMonth() - d1.getMonth();

        }
        else if (d1.getMonth() > d2.getMonth())
        {
            monthDiff = d1.getMonth() - d2.getMonth();

        }
        return new Interval(monthDiff, dayDiff);
   
    }
}

 class Interval {
    public int months;
    public int days;
    public Interval(int months, int days)
    {
        this.months = months;
        this.days = days;
    }

    public override string? ToString()
    {
        return "months=" + months + ", days=" + days;
    }
}