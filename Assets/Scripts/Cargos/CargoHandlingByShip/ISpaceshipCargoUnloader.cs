﻿using System.Collections.Generic;

namespace PlanetsColony.Cargos.CargoHandlingByShip
{
    public interface ISpaceshipCargoUnloader
    {
        List<ICargo> Extract();
    }
}