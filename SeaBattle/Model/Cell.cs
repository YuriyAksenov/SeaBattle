namespace SeaBattle.Model
{
    /// <summary>
    /// Provides base class for cell of the field.
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// Initializes a new instance of the Cell class.
        /// </summary>
        public Cell() { }

        /// <summary>
        /// Gets a value indicating whether that tell is empty.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return CellType == ShipType.Empty ? true : false;
            }
        }

        /// <summary>
        /// Gets ans Sets a value indicating whether that tell is hitted.
        /// </summary>
        public bool IsHitted { get; set; } = false;

        /// <summary>
        /// Gets and Sets a value indicating type of the cell.
        /// </summary>
        public ShipType CellType { get; set; } = ShipType.Empty;
        
        /// <summary>
        /// Returns a string that represents the current type of Cell.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            switch (CellType)
            {
                case ShipType.Empty:
                    return "0";
                case ShipType.One:
                    return "1";
                case ShipType.Two:
                    return "2";
                case ShipType.Three:
                    return "3";
                case ShipType.Four:
                    return "4";
                default:
                    return "0";
            }
        }
    }

    
}
