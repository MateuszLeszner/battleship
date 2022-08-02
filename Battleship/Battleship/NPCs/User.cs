namespace Battleship.NPCs
{
    public class User: INpc
    {
        public (int col, int row) Fire()
        {
            return ConsoleHelpers.AskForInput();
        }
    }
}
