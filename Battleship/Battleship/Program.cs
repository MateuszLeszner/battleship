// See https://aka.ms/new-console-template for more information
using Battleship;
using Battleship.FieldType;
using Battleship.NPCs;

#region Main
//INpc player1 = new RandomNpcWithMemory();
INpc player1 = new User(); // uncomment to play as user, not automatic
//INpc player2 = new RandomNpc();
INpc player2 = new User();

var player1Board = new Board("Player 1 board");
var player2Board = new Board("Player 2 board");
var shipFactory = new ShipFactory();

GameSetup();
GameLoop();
player1Board.Draw();
player2Board.Draw();
ConsoleHelpers.ResetColors();
#endregion

#region Methods

void GameSetup()
{
    ConsoleHelpers.ResetColors();
    ConsoleHelpers.ShowHeader();
    CreateFleet();
}

void GameLoop()
{
    var player1Points = 0;
    var player2Points = 0;

    do
    {
        player1Board.Draw();
        player2Board.Draw();

        // player 1 turn
        var p1Target = player1.Fire();
        Console.Write($"PLAYER 1 shoots to {(char)(p1Target.col + 65)}{p1Target.row + 1}.\t");
        var p1Hit = CheckHit(p1Target, player2Board);
        if (p1Hit)
        {
            player1Points++;
        }

        // player 2 turn
        var p2Target = player2.Fire();
        Console.Write($"NPC shoots to {(char)(p2Target.col + 65)}{p2Target.row + 1}.\t");
        var p2Hit = CheckHit(p2Target, player1Board);
        if (p2Hit)
        {
            player2Points++;
        }

        if (player1 is not User)
        {
            Thread.Sleep(250);
            //slow down the automatic game
        }

        switch (player1Points)
        {
            case 13 when player2Points == 13:
                Console.WriteLine("DRAW");
                return;
            case 13:
                Console.WriteLine("PLAYER 1 WINS!");
                return;
            case <13 when player2Points == 13:
                Console.WriteLine("PLAYER 2 WINS!");
                return;
        }
    } while (true);
}

void CreateFleet()
{
    shipFactory.Create(player1Board.GetBoard(), 4);
    shipFactory.Create(player1Board.GetBoard(), 4);
    shipFactory.Create(player1Board.GetBoard(), 5);
    shipFactory.Create(player2Board.GetBoard(), 4);
    shipFactory.Create(player2Board.GetBoard(), 4);
    shipFactory.Create(player2Board.GetBoard(), 5);
}

bool CheckHit((int col, int row) position, Board board)
{
    switch (board.GetField(position))
    {
        case Water _:
            Console.WriteLine("Missed!");
            board.SetField(position, new Miss());
            return false;
        case Ship _:
            Console.WriteLine("It's a hit!!!");
            board.SetField(position, new Hit());
            return true;
        case Hit _:
            Console.WriteLine("You've hit here earlier!");
            return false;
        case Miss _:
            Console.WriteLine("You've missed here earlier!");
            return false;
        default:
            return false;
    }
}

#endregion