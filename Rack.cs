using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace ScrabbleLibrary
{
    internal class Rack : IRack
    {
        //Objects
        private readonly IBag bag;
        private Bag bBag;

        //Save upto 7 tiles
        List<char> rack;

        //total points scored.
        uint totalPoint = 0;

        string? output;

        //object
        LetterScore le = new LetterScore();

        //checks the word with MS
        Application wordApplication = new Microsoft.Office.Interop.Word.Application();
        
        //Hidden Rack constructor 
        internal Rack(Bag bag) 
        {
            this.bag = bag;
            rack= new List<char>();
            AddTiles();

        }

        
        public uint TotalPoints => totalPoint;

        //Add tiles in the rack list created above.
        public uint AddTiles()
        {
        

            while(rack.Count < 7) {
                if(bag.TileCount <= 0)
                {
                    break;
                }
                bBag = (Bag)bag;

                Random random = new Random();
                List<KeyValuePair<char, int>> rdmTile = new List<KeyValuePair<char, int>>();
                foreach (var c in bBag.tiles)
                {
                    if (c.Value > 0)
                    {
                        rdmTile.Add(c);
                    }
                }
                int x = random.Next(0, rdmTile.Count);
                char randomTile = rdmTile.ElementAt(x).Key;
                bBag.tiles[randomTile]--;

                rack.Add(randomTile);
            }
            return (uint)rack.Count;
        }

        //Checks the tiles
        public bool PlayWord(string candidate)
        {

            uint score = 0;

            foreach( char c in candidate) 
            {

                score += (uint)le.letterScore(c);
            }

            if (score > 0)
            {
                foreach(char c in candidate) 
                {
                    if(rack.Contains(c))
                    {
                        rack.Remove(c);
                    }
                }
                totalPoint += (uint)score;

                Random random = new Random();
                List<KeyValuePair<char, int>> rdmTile = new List<KeyValuePair<char, int>>();
                foreach (var c in bBag.tiles)
                {
                    if (c.Value > 0)
                    {
                        rdmTile.Add(c);
                    }
                }
                int x = random.Next(0, rdmTile.Count);
                char randomTile = rdmTile.ElementAt(x).Key;
                bBag.tiles[randomTile]--;

                while (rack.Count < 7 && bag.TileCount > 0)
                {
                    rack.Add(randomTile);
                }
                return true;

            }
            else
            {
                return false;
            }
                

        }


        //Tells the points of the word

        public uint TestWord(string candidate)
        {
            uint score = 0;
            List<char> chars= new(); 
            foreach(var letter in rack)
            {
                chars.Add(letter);
            }
            if(!wordApplication.CheckSpelling(candidate))
            {
                return 0;
            }

            foreach(char letter in candidate)
            {
                if(chars.Contains(letter))
                {
                    chars.Remove(letter);
                }
                else
                {
                    return 0;
                }
            }

            foreach (char c in candidate)
            {

                score += le.letterScore(c);
            }

            return score;
        }

        //returns the list of tiles.
        public override string ToString()
        {
            string stringOutput = "";
            
            foreach(char c in rack)
            {
                stringOutput += c;
            }

            return stringOutput;
        }
    }
}
