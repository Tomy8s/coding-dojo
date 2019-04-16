using System;
using System.Collections.Generic;

namespace katacombs
{
    public static class Class1
    {
        static void Main()
        {
            new Game();
        }
    }

    public class Player
    {
        public Player()
        {
            Position = new int[]{0,0,0};
        }

        public int[] Position { get; set; }

        public void Act(string rawAction)
        {
            string action = rawAction.ToUpper();
            if(action.StartsWith("GO "))
            {
                switch(action.Substring(3, 1)) {
                    case "W":
                        Position[0] --;
                        break;
                    case "E":
                        Position[0] ++;
                        break;
                    case "S":
                        Position[1] --;
                        break;
                    case "N":
                        Position[1] ++;
                        break;
                    case "D":
                        Position[2] --;;
                        break;
                    case "U":
                        Position[2] ++;
                        break;
                    default:
                        return;
                }
            }
        }
    }

    public class Game
    {
        public Player Player { get; set; }
        public GameMap GameMap { get; set; }
        public Game()
        {
            Player = new Player();
            GameMap = new GameMap();
            
            
            Console.WriteLine("Let the game begin!");


            while(true)
            {
                PlayGame();
                if (GameMap.IsExit(Player.Position))
                {
                    Console.WriteLine(GameMap.GetTitle(Player.Position));
                    Console.WriteLine(GameMap.GetDescription(Player.Position));
                    return;
                }
            }
        }
        private void PlayGame()
        {
            Console.WriteLine(String.Join("", Player.Position));
            Console.WriteLine(GameMap.GetTitle(Player.Position));
            Console.WriteLine(GameMap.GetDescription(Player.Position));
            Console.WriteLine("What would you like to do?");

            var action = Console.ReadLine();

            Player.Act(action);
        }
    }

    public class GameMap
    {
        public string GetTitle(int[] coordinates)
        {
            return Field[coordinates[0], coordinates[1], coordinates[2]].Title;
        }
        public string GetDescription(int[] coordinates)
        {
            return Field[coordinates[0], coordinates[1], coordinates[2]].Description;
        }

        public bool IsExit(int[] coordinates)
        {
            return Field[coordinates[0], coordinates[1], coordinates[2]].IsExit;
        }

        Location[,,] Field = {
            {
                {
                    new Location("LOST IN SHOREDITCH.", "YOU ARE STANDING AT THE END OF BRICK LANE BEFORE A SMALL BRICK BUILDING CALLED THE OLD TRUMAN BREWERY. \nAROUND YOU IS A FOREST OF INDIAN RESTAURANTS. \nA SMALL STREAM OF CRAFTED BEER FLOWS OUT OF THE BUILDING AND DOWN A GULLY."),
                    new Location("title one", "description 1")
                },
                {
                    new Location("LOST IN SHOREDITCH.", "YOU ARE STANDING AT THE END OF BRICK LANE BEFORE A SMALL BRICK BUILDING CALLED THE OLD TRUMAN BREWERY. \nAROUND YOU IS A FOREST OF INDIAN RESTAURANTS. \nA SMALL STREAM OF CRAFTED BEER FLOWS OUT OF THE BUILDING AND DOWN A GULLY."),
                    new Location("title one", "description 1")
                }
            },
            {
                {
                    new Location("LOST IN SHOREDITCH.", "YOU ARE STANDING AT THE END OF BRICK LANE BEFORE A SMALL BRICK BUILDING CALLED THE OLD TRUMAN BREWERY. \nAROUND YOU IS A FOREST OF INDIAN RESTAURANTS. \nA SMALL STREAM OF CRAFTED BEER FLOWS OUT OF THE BUILDING AND DOWN A GULLY."),
                    new Location("title one", "description 1")
                },
                {
                    new Location("LOST IN SHOREDITCH.", "YOU ARE STANDING AT THE END OF BRICK LANE BEFORE A SMALL BRICK BUILDING CALLED THE OLD TRUMAN BREWERY. \nAROUND YOU IS A FOREST OF INDIAN RESTAURANTS. \nA SMALL STREAM OF CRAFTED BEER FLOWS OUT OF THE BUILDING AND DOWN A GULLY."),
                    new Location("EXIT", "Well done! You have escaped!", true)
                }
            }
        };
    }

    public class Location
    {
        public string Title { get; }
        public string Description { get; }
        public bool IsExit { get; }

        public Location(string title, string description, bool isExit)
        {
            Title = title;
            Description = description;
            IsExit = isExit;
        }
        public Location(string title, string description)
        {
            Title = title;
            Description = description;
            IsExit = false;
        }
    }
}
