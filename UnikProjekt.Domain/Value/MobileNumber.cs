using System.Text.RegularExpressions;
using UnikProjekt.Domain.Shared;

namespace UnikProjekt.Domain.Value
{
    public record MobileNumber(string Value) : RecordWithValidation
    {
        protected override void Validate()
        {
            //Removes non-digit characters from Value with Regex.Replace (where \D matches any char not a digit)
            string cleanedNumber = Regex.Replace(Value, @"\D", "");

            //Checks that a number has been entered
            if (string.IsNullOrWhiteSpace(cleanedNumber)) throw new ArgumentException("Mobilnummeret må ikke være tom");

            //Checks is the number is exactly 8 digits long
            if (cleanedNumber.Length != 8) throw new ArgumentException("Mobilnummeret skal være 8 tal langt");
        }
    }
}
