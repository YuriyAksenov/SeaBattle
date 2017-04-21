namespace SeaBattle.Model.Field
{
    public interface IBaseField
    {
        /// <summary>
        /// Defines the property that gets and sets the array of the field cells.
        /// </summary>
        Cell[,] Cells { get; set; }

        /// <summary>
        /// Defines the method to clears the cells of the instance field. Makes them empty type and unhitted.
        /// </summary>
        void ClearField();

        /// <summary>
        /// Defines the method to returns a string representations in base way view of this field;
        /// </summary>
        /// <returns></returns>
        string PrintField();
    }
}