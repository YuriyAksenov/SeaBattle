namespace SeaBattle.Model.Player
{
    public interface IPlayer
    {
        /// <summary>
        /// Defines the method that sets all ships in the player field
        /// </summary>
        void SetAllShips();

        /// <summary>
        /// Defines the method to shoot the cell
        /// </summary>
        bool ShootCell(int shootedHorizontalCell, int shootedVerticalCell);
    }
}