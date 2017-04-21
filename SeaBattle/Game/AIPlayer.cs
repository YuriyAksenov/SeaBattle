using SeaBattle.Model.Player;
using SeaBattle.Model.Ship;
using System;

namespace SeaBattle.Model.Game
{
    /// <summary>
    /// Provides the instance of the AI player class.
    /// </summary>
    public class AIPlayer : BasePlayer
    {
        /// <summary>
        /// Initializes the instance of the human player class.
        /// </summary>
        public AIPlayer() : base() { }

        /// <summary>
        /// Sets all ships on the field.
        /// </summary>
        public void SetAllShips()
        {

            HomeField.SetPatternField();
           /* if (!IsShipSettedAndIterationsNotOverflow(ShipType.Four))
            {
                SetAllShips();
                return;
            }
            PrintHomeField();
            for (int i = 0; i < 2; i++)
            {
                if (!IsShipSettedAndIterationsNotOverflow(ShipType.Three))
                {
                    SetAllShips();
                    return;
                }
            }
            PrintHomeField();
            for (int i = 0; i < 3; i++)
            {
                if (!IsShipSettedAndIterationsNotOverflow(ShipType.Two))
                {
                    SetAllShips();
                    return;
                }
            }
            PrintHomeField();
            for (int i = 0; i < 2; i++)
            {
                if (!IsShipSettedAndIterationsNotOverflow(ShipType.Four))
                {
                    SetAllShips();
                    return;
                }
            }
            PrintHomeField();
            */
        }

        /// <summary>
        /// Returns a value of the indicating whether determine ship is setted and amount of iterations are limited and not overflow.
        /// </summary>
        /// <param name="shipType"></param>
        /// <param name="recommendedAmountIterations"></param>
        /// <returns>bool</returns>
        private bool IsShipSettedAndIterationsNotOverflow(ShipType shipType, int recommendedAmountIterations = 0)
        {
            int maxIterations = 0;
            int standartMaxIterations = 0;
            bool isSettedShip = false;

            switch (shipType)
            {
                case ShipType.One:
                    standartMaxIterations = 200;
                    break;
                case ShipType.Two:
                    standartMaxIterations = 200;
                    break;
                case ShipType.Three:
                    standartMaxIterations = 200;
                    break;
                case ShipType.Four:
                    standartMaxIterations = 200;
                    break;
            }

            switch (shipType)
            {
                case ShipType.One:
                    maxIterations = (recommendedAmountIterations > 50 ? recommendedAmountIterations : standartMaxIterations);
                    while (!isSettedShip)
                    {
                        isSettedShip = SetShip(ShipType.One);
                        if (maxIterations < 0)
                        {
                            HomeField.ClearField();
                            return false;
                        }
                        else maxIterations--;
                    }
                    break;

                case ShipType.Two:
                    maxIterations = (recommendedAmountIterations > 50 ? recommendedAmountIterations : standartMaxIterations);
                    while (!isSettedShip)
                    {
                        isSettedShip = SetShip(ShipType.Two);
                        if (maxIterations < 0)
                        {
                            HomeField.ClearField();
                            return false;
                        }
                        else maxIterations--;
                    }
                    break;

                case ShipType.Three:
                    maxIterations = (recommendedAmountIterations > 50 ? recommendedAmountIterations : standartMaxIterations);
                    while (!isSettedShip)
                    {
                        isSettedShip = SetShip(ShipType.Three);
                        if (maxIterations < 0)
                        {
                            HomeField.ClearField();
                            return false;
                        }
                        else maxIterations--;
                    }
                    break;

                case ShipType.Four:
                    maxIterations = (recommendedAmountIterations > 50 ? recommendedAmountIterations : standartMaxIterations);
                    while (!isSettedShip)
                    {
                        isSettedShip = SetShip(ShipType.Four);
                        if (maxIterations < 0)
                        {
                            HomeField.ClearField();
                            return false;
                        }
                        else maxIterations--;
                    }
                    break; 
            }
            return true;
        }

        /// <summary>
        /// Returns a value of indicating whether the AI set the ship.
        /// </summary>
        /// <param name="shipType"></param>
        /// <returns>bool</returns>
        private bool SetShip(ShipType shipType)
        {
            try
            {
                Direction shipDirection = Direction.Horizontal;
                int shipLength = 0;
                int horizontalCoordinateStartCell = 0;
                int verticalCoordinateStartCell = 0;

                switch (shipType)
                {

                    case ShipType.One:
                        shipLength = 1;
                        break;
                    case ShipType.Two:
                        shipLength = 2;
                        break;
                    case ShipType.Three:
                        shipLength = 3;
                        break;
                    case ShipType.Four:
                        shipLength = 4;
                        break;
                }
                var t = (new Random().Next(2));
                shipDirection = ((t == 1) ? Direction.Horizontal : Direction.Vertical);

                horizontalCoordinateStartCell = new Random().Next(10);
                verticalCoordinateStartCell = new Random().Next(10);

                BaseShip baseShip = new BaseShip(shipDirection, shipLength, verticalCoordinateStartCell, horizontalCoordinateStartCell);
                if (HomeField.IsPossibleToSetShip(baseShip))
                {
                    HomeField.SetShip(baseShip);

                    Ships.Add(baseShip);

                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
            }
            return false;
        }
        
    }
}
