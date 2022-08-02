namespace Battleship.NPCs
{
    public class RandomNpc: INpc
    {
        private readonly Random _rnd = new Random();

        public (int col, int row) Fire()
        {
            var col = _rnd.Next(Board.BOARD_SIZE);
            var row = _rnd.Next(Board.BOARD_SIZE);
            return (col, row);
        }
    }
}
