namespace ScrabbleLibrary
{
    public interface IBag
    {
        //Gives the author information
        string Author { get; }

        //gives the number of tiles
        uint TileCount { get; }
        //Cretaes the rack object
        public IRack GenerateRack();
        //Gdisplays the tiles in the  bag
        public string ToString();


    }
}