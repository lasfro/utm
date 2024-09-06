using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RU_NO_CRM_Functions.Services
{
    public static class AddressHelperService
    {
        public static (string street, string  houseNumber) SplitStreetAndHouseNumber(string text)
        {
            text = text.Trim();
            // find last index that contains a numeric value

            int index = text.Length - 1;
            while (index > 0)
            {

                if (char.IsAsciiDigit(text[index]))
                {
                    break;
                }
                --index;
            }

            // if no digits found, no way to split
            if (index == 0)
                return (text, string.Empty);

            while (index > 0)
            {
                if (text[index] == ' ')
                    break;

                --index;
            }

            if (index == 0)
                return (text, string.Empty);

            // split
            string street = text.Substring(0, index).Trim();
            string houseNumber = text.Substring(index + 1).Trim();

            // if any of the values contains a blank string, we can't split
            if (string.IsNullOrWhiteSpace(street) || string.IsNullOrWhiteSpace(houseNumber))
                return (text, string.Empty);

            return (street, houseNumber);
        }
    }
}
