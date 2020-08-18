using System;

namespace Tholumuntu.Helpers
{
    public static class CalculateAge
    {
        public static string GetAge(DateTime age)
        {
            return (DateTime.Now.Year - age.Year).ToString();
        }
    }
}