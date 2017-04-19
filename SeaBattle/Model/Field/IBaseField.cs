namespace SeaBattle.Model.Field
{
    public interface IBaseField
    {
        Cell[,] Cells { get; set; }
        string PrintField();
        string ToString();
    }
}