namespace Battleship.NPCs
{
    public class RandomNpcWithMemory: INpc
    {
        private readonly Random _rnd = new Random();
        private readonly List<(int col, int row)> _previousShoots = new();

        public (int col, int row) Fire()
        {
            var col = _rnd.Next(Board.BOARD_SIZE);
            var row = _rnd.Next(Board.BOARD_SIZE);

            if (_previousShoots.Contains((col, row)))
            {
                return Fire();
            }

            _previousShoots.Add((col, row));
            return (col, row);
        }
    }
}
