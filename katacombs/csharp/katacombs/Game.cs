using System.Linq;

namespace katacombs
{
    public class Game
    {
        public Player Player { get; set; }
        public GameMap GameMap { get; set; }
        private IPrintThings printer;

        public Game(IPrintThings printer = null, GameMap gameMap = null)
        {
            this.printer = printer;
            Player = new Player();
            GameMap = gameMap ?? new GameMap();
        }

        public void Act(string command)
        {
            var commandItems = command.Split(' ');

            if (command.StartsWith("BAG")) {
                Bag();
                return;
            }

            if (commandItems.Length != 2)
            {
                this.printer.PrintError($"I don't know how to {command}");
                return;
            }

            var direction = commandItems[1];
            if (!ValidateDirecton(direction))
            {
                this.printer.PrintError($"I don't know how to {command}");
                return;
            }

            if (command.StartsWith("GO")) {
                Move(direction);
            }
            else if (command.StartsWith("LOOK")) {
                Look(direction);
            }
            else {
                this.printer.PrintError($"I don't know how to {command}");
            }       
        }

        private bool ValidateDirecton(string direction)
        {
            string[] validDirections = new []{ "N", "S", "E", "W", "UP", "DOWN" };
            return validDirections.Contains(direction);
        }

        private void Bag() {
            var bag = Player.ViewBag();
            this.printer.Print(bag.ToString());
        }

        private void Move(string direction) {
            Player.Move(direction);
        }

        private void Look(string direction)
        {
            var lookingAtCoordinates = Coordinates.Calculate(this.Player.Coordinates, direction);

            var obstacleLocation = this.GameMap.GetObstacle(this.Player.Coordinates, lookingAtCoordinates);
            
            try
            {
                if(obstacleLocation == null){
                    var title = this.GameMap.GetTitle(lookingAtCoordinates);
                    var description = this.GameMap.GetDescription(lookingAtCoordinates);
                    printer.Print(new Location(title, description).ToString());
                }else{
                    printer.Print(obstacleLocation.ToString());
                }   
            }
            catch
            {
                printer.Print(new Location("Not found location", "Nothing interesting to look at here").ToString());
            }
        }
    }
}