using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrabbleLibrary
{
    public interface IRack
    {
        //represents the total points scored with the current Rack
        
        uint TotalPoints { get; }

        //Add the number of tiles
        public uint AddTiles();

        // test the word
        public uint TestWord(string candidate);


        public bool PlayWord(string candidate);

        //returns the list of tiles
        public  string ToString();
    }
}
