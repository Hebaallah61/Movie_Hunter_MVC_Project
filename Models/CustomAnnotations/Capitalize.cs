using System.ComponentModel.DataAnnotations;

namespace Movie_Hunter_FinalProject.Models.CustomAnnotations
{
    public class Capitalize:ValidationAttribute
    {


        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return false;
            }

            string stringValue = value.ToString();
            if (string.IsNullOrEmpty(stringValue))
            {
                return false;
            }

            string firstLetter = stringValue.Substring(0, 1).ToUpper();
            string restOfLetters = stringValue.Substring(1).ToLower();
            string formattedValue = firstLetter + restOfLetters;

            if (stringValue == formattedValue)
            {
                return true;
            }

            return false;
        }
    }
}
