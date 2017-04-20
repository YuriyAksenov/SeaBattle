using SeaBattle.Model.Ship;

namespace SeaBattle.Model.Field
{
    public interface IHomeField :IBaseField
    {
       bool IsPossibleToSetShip(BaseShip baseShip);
       bool SetShip(BaseShip ship);
       void SetPatternField(int[,] patternField = null);
    }
}