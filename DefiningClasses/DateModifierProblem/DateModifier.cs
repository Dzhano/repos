using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifierProblem
{
    public static class DateModifier
    {
        public static int DifferenceBetweenDates(string firstDate, string secondDate)
        {
            DateTime dateOne = DateTime.Parse(firstDate);
            DateTime dateTwo = DateTime.Parse(secondDate);

            TimeSpan difference = dateOne - dateTwo;
            return Math.Abs(difference.Days);
        }
    }
}
