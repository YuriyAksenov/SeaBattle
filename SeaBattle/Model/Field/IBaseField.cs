namespace SeaBattle.Model
{
    public interface IBaseField
    {
        Cell[,] Cells { get; set; }
        string PrintField();
        string ToString();
    }
}