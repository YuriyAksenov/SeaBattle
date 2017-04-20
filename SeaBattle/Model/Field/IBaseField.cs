namespace SeaBattle.Model.Field
{
    public interface IBaseField
    {
        Cell[,] Cells { get; set; }
        void ClearField();
        string PrintField();
        string ToString();
    }
}