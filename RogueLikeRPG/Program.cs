using RogueLikeRPG;

// Atleast 10 levels 

Map map = new Map(20, 10); // create a 20x10 map
Player player = new Player(1, 1); // place player at (1,1)
Level level = new Level(map, player.X, player.Y, 0, 0); // Create Level

map.PlacePlayer(player.Y, player.X); // place player on the map

while (true)
{
    map.DisplayMap(); // show the current state of the map
    char input = Console.ReadKey(true).KeyChar; // get player input
    player.MovePlayer(level, input); // Move the player
}

