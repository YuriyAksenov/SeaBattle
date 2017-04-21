namespace SeaBattle.Model.Field
{
    public interface IEnemyField : IBaseField
    {
        /// <summary>
        /// Defines the method to that determines is that shooted coordinates afford to shoot the cell
        /// </summary>
        bool IsHittedCell(int shootedHorizontalCell, int shootedVerticalCell);

        /// <summary>
        /// Defines the method to returns a string representations in enemy way view of this field.
        /// </summary>
        /// <returns>string</returns>
        string PrintEnemyField();
    }
}
