
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace ScrabbleLibrary
{
    public class Bag : IBag
    {
        //DIctionary which contians the value of each Character.
        public Dictionary<char, int> tiles = new Dictionary<char, int>
        {
            {'A', 9}, {'B', 2},{'C', 2},{'D', 4},{'E', 12},{'F', 2},{'G', 3},{'H', 2},{'I', 9},{'J', 1},
            {'K', 1},{'L', 4},{'M', 2},{'N', 6},{'O', 8},{'P', 2},{'Q', 1},{'R', 6},{'S', 4},{'T', 6},
            {'U', 4},{'V', 2},{'W', 2},{'X', 1},{'Y', 2},{'Z', 1}
        };

        //Readonly propety of Author of the project
        public string Author
        {
            get {
                return "Srestha Bharadwaj";
                }
        }

        //Readonly property to count the number of tiles in the bag.
        public uint TileCount => (uint)tiles.Values.Sum();

        //This function returns the IRack object
        public IRack GenerateRack()
        {
            var rack = new Rack(this);
            return rack;
        }

        //Outputs the tiles from the bag
        public override string ToString()
        {
            var sb = new StringBuilder();   
            foreach(var tile in tiles.OrderBy(x=>x.Key))
            {
                sb.Append($"{tile.Key}({tile.Value})\t");
            }
            return sb.ToString();
        }

        
        

    }
}
