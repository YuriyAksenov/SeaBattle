namespace SeaBattle.Model
{
    public interface IPlayer
    {
        void SetShip(Ship ship, int settedHorizontalStartCell, int settedVerticalStartCell);
        bool ShootCell(int shootedHorizontalCell, int shootedVerticalCell);
    }
}