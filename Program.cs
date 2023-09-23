using System;
using System.Collections.Generic;
using ScrabbleLibrary;
using static System.Formats.Asn1.AsnWriter;

namespace ScrabbleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create the bag object
            IBag bag = new Bag();

            //Display the author name 
            Console.WriteLine("Testing ScrabbleLibrary [Author: " + bag.Author + " - February 06, 2023]\n");

            //Total number of Tiles in the bag
            Console.WriteLine("Bag initialized with the following " + bag.TileCount + "...");

            //Displays the tiles in the bag
            Console.WriteLine(bag.ToString());

            
            Console.Write("\nEnter the numbers of players (1-8): ");

            int player = -1;

            while(player < 0 || player > 8)
            {
                try
                {
                    player = Convert.ToInt32(Console.ReadLine());
                }
                catch 
                {
                    Console.WriteLine("The players should not be more than 8.");
                }
            }

            //the Irack class instance
            List<IRack> racks = new List<IRack>();

            
            for(int i = 0; i < player; i++)
            {
                racks.Add(bag.GenerateRack());
            }

            bool flag = true;
            

            while(flag)
            {
                Console.WriteLine("Racks for " + player + " players were populated.\n");
                Console.WriteLine("Bag now containes the "+ bag.TileCount + " tiles...");
                Console.WriteLine(bag.ToString());

                int x;

                for(x = 0; x < player;x++)
                {
                    string user;

                    //Number of players
                    Console.WriteLine("\n---------------------------------------------------------------");
                    Console.WriteLine("Player " + (x + 1));
                    Console.WriteLine("---------------------------------------------------------------");
                    bool flag1 = true;
                    while (flag1)
                    {
                        //Asks the questions to the players
                        var value = racks[x];
                        Console.WriteLine("Your rack contains [" + value + "]");
                        Console.Write("Test a word for its points value? (y/n): ");
                        user = Console.ReadLine();

                        switch(user.ToLower()) 
                        {
                            case "y":
                                Console.Write("Enter a word using the letters [" + value + "]:  ");
                                string letter = Console.ReadLine();

                                uint point = racks[x].TestWord(letter.ToUpper());

                                if(point > 0)
                                {
                                    Console.WriteLine("The word [" + letter.ToUpper() + "] is worth " + point + " points.");
                                    Console.Write("Do you want to play the word [ " + letter.ToUpper() + "]? (y/n): ");
                                    user= Console.ReadLine();
                                    if(user == "y" || user == "Y")
                                    {
                                        racks[x].PlayWord(letter.ToUpper());

                                        Console.WriteLine("\t\t------------------------------");
                                        Console.WriteLine("\t\tWord Played: " +  letter.ToUpper());
                                        Console.WriteLine("\t\tTotal Points: " + point);
                                        Console.WriteLine("\t\tRack now contains: [" + racks[x] + "]");
                                        Console.WriteLine("\t\t------------------------------\n");

                                        flag1= false;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("The Word [" + letter.ToUpper() + "] is worth 0 points.");
                                }
                                break;
                            case "n":

                                Console.Write("Are you sure, you want to quit? (y/n): ");
                                user= Console.ReadLine();

                                if(user == "y")
                                {
                                    flag = false;
                                }
                                else if (user == "n")
                                {
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter y or n only.");
                                }
                                break;
                            default: Console.WriteLine("Please enter y or n only.");
                                break;
                        }
                    }

                    if (!flag)
                    {
                        break;
                    }
                }

                if(x == player)
                {
                    while (true)
                    {
                        Console.WriteLine("Do you wish to go for another round? (y/n): ");
                        string user = Console.ReadLine();
                        if(user == "y")
                        {
                            break;
                        }
                        else if(user == "n"){
                            flag = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter y or n only.");
                            continue;
                        }
                    }
                }
            }

            //Displays the final result
            Console.WriteLine("\nRetiring the game.");
            Console.WriteLine("\nThe final scores are");
            Console.WriteLine("---------------------------------------------------------------");
            for (int i = 0; i < racks.Count; i++)
            {
                Console.WriteLine("Player " + (i + 1) + ": "+ racks[i].TotalPoints + " points");
            }
            Console.WriteLine("---------------------------------------------------------------");


            return;
            
        }
    }
}
