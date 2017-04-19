namespace SeaBattle.Model.Field
{
    public interface IEnemyField :IBaseField
    {
        bool IsHittedCell(int shootedHorizontalCell, int shootedVerticalCell);
    }
}
