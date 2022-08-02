namespace Battleship.NPCs
{
    public interface INpc
    {
        (int col, int row) Fire();
    }
}
