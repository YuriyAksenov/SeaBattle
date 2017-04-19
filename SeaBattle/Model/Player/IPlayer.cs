using SeaBattle.Model.Ship;

namespace SeaBattle.Model.Player
{
    public interface IPlayer
    {
        
        bool ShootCell(int shootedHorizontalCell, int shootedVerticalCell);
    }
}