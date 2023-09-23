using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrabbleLibrary
{
    class LetterScore
    {
        //Returns the Points of Each character
        public uint letterScore(char letter)
        {
            switch (letter)
            {
                case 'A':
                case 'E':
                case 'I':
                case 'L':
                case 'N':
                case 'O':
                case 'R':
                case 'S':
                case 'T':
                case 'U':
                    return 1;
                case 'D':
                case 'G':
                    return 2;
                case 'B':
                case 'C':
                case 'M':
                case 'P':
                    return 3;
                case 'F':
                case 'H':
                case 'V':
                case 'W':
                case 'Y':
                    return 4;
                case 'K':
                    return 5;
                case 'J':
                case 'X':
                    return 8;
                case 'Q':
                case 'Z':
                    return 10;
                default:
                    throw new NotImplementedException( letter + " is not present.");
            }
        }

        }
    }


