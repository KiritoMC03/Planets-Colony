using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony
{
    public interface IAcceptShips
    {
        void AcceptShip(IAcceptCargo ship);
    }
}