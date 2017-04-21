using SeaBattle.Model.Ship;

namespace SeaBattle.Model.Field
{
    public interface IHomeField : IBaseField
    {
        /// <summary>
        /// Defines the method that determines whether setting the ship on coordinates which determines in the instance ship class.
        /// </summary>
        bool IsPossibleToSetShip(BaseShip baseShip);

        /// <summary>
        /// Defines the method to set ship on the scpecified cells. Returns the value indicating whether the ship is setted.
        /// </summary>
        /// <param name="ship"></param>
        /// <returns>bool</returns>
        bool SetShip(BaseShip ship);

        /// <summary>
        /// Defines the method to sets the specified patterned field that is transmitted into method or determined in the method.
        /// </summary>
        /// <param name="patternField"></param>
        void SetPatternField(int[,] patternField = null);

        /// <summary>
        /// Defines the method to returns a string representations as home field view of this field;
        /// </summary>
        /// <returns></returns>
        string PrintHomeField();
    }
}