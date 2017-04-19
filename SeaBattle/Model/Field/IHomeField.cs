namespace SeaBattle.Model
{
    public interface IHomeField :IBaseField
    {
       bool IsPossibleToSetShip(Ship ship, int horizontalSettedCell, int verticalSettedCell);
    }
}