using katacombs;
using NUnit.Framework;
using System;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void When_game_starts_player_is_at_origin()
        {
            var player = new Player();
            Assert.That(player.Position, 
                Is.EquivalentTo(new[]{0,0,0}));
        }

        [TestCase("GO N", 2, 1, 1)]
        [TestCase("GO S", 0, 1, 1)]
        [TestCase("GO E", 1, 2, 1)]
        [TestCase("GO W", 1, 0, 1)]
        [TestCase("GO UP", 1, 2, 1)]
        [TestCase("GO DOWN", 1, 0, 1)]
        public void When_Act_called_with_go(string action, int x, int y, int z)
        {
            var player = new Player();
            player.Position = new int[] { 1, 1, 1 };
            player.Act(action);

            Assert.That(player.Position, Is.EquivalentTo(new [] { x, y, z }));
        }

        [Test]
        public void When_game_starts_should_have_a_player()
        {
            var game = new Game();
            Assert.That(game.Player,
                Is.InstanceOf(typeof(Player)));
        }

        [Test]
        public void When_game_starts_should_have_a_map()
        {
            var game = new Game();
            Assert.That(game.GameMap,
                Is.InstanceOf(typeof(GameMap)));
        }

        [TestCase(0,0,0, "LOST IN SHOREDITCH.")]
        [TestCase(0,0,1, "title one")]
        public void When_getTitle_is_called_on_map_returns_title(int x, int y, int z, string expectedTitle)
        {
            var thisMap = new GameMap();
            Assert.That(thisMap.GetTitle(new [] {x, y, z}), 
                Is.EqualTo(expectedTitle));
        }


        [TestCase(0,0,0, "YOU ARE STANDING AT THE END OF BRICK LANE BEFORE A SMALL BRICK BUILDING CALLED THE OLD TRUMAN BREWERY. \nAROUND YOU IS A FOREST OF INDIAN RESTAURANTS. \nA SMALL STREAM OF CRAFTED BEER FLOWS OUT OF THE BUILDING AND DOWN A GULLY.")]
        [TestCase(0,0,1, "description 1")]
        public void When_getDescription_is_called_on_map_returns_description(int x, int y, int z, string expectedDescription)
        {
            var thisMap = new GameMap();
            Assert.That(thisMap.GetDescription(new [] {x,y,z}), 
                Is.EqualTo(expectedDescription));
        }

        [TestCase(0,0,0, false)]
        [TestCase(0,1,1, false)]
        public void When_isExit_is_called_returns_whether_is_exit(int x, int y, int z, bool expected)
        {
            var thisMap = new GameMap();
            var actual = thisMap.IsExit(new [] {x,y,z});

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}