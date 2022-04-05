using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dcounter
{
    public class LetterCounter
    {
        public char Letter { get; set; }

        public LetterCounter(char letter)
        {
            Letter = letter;
        }

        public int CountLetters(string input) => input.ToLower().Where(x => x == Letter).Count();
    }
}
