using System;
using System.Linq;

namespace QAWorkshop
{
    public class ProductCodeValidator
    {
        public ProductCodeValidator()
        {
            
        }

        public bool Validate(string code)
        {
            if (code.Length == 9 && StartsWithThreeUppercaseLetters(code) 
                && ContainsOnlyNumbersAndOneOptionalDash(code))
            {
                return true;
            }
            return false;
        }

        private bool StartsWithThreeUppercaseLetters(string code)
        {
            char[] letters =
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K',
                'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V',
                'W', 'X', 'Y', 'Z'
            };

            if (letters.Contains(code[0]) && letters.Contains(code[1]) && letters.Contains(code[2]))
            {
                return true;
            }
            
            return false;
        }

        private bool ContainsOnlyNumbersAndOneOptionalDash(string code)
        {
            string[] chars = code.Split();
            int digits = 0;

            for (var i = 0; i < code.Length; i++)
            {
                if (i > 2 && Char.IsDigit(code[i]))
                {
                    digits++;
                }
            }

            if (digits >= 5)
            {
                return true;
            }
            
            return false;
        }
    }
}