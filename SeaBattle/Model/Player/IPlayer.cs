using SeaBattle.Model.Ship;

namespace SeaBattle.Model.Player
{
    public interface IPlayer
    {
        void SetAllShips();
        bool ShootCell(int shootedHorizontalCell, int shootedVerticalCell);
    }
}