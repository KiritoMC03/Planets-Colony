using System;
using System.Collections.Generic;

namespace PlanetsColony
{
    public interface ICargo
    {
        float GetValue();
        float GetPrice();
        Resource.Type GetResourceType();
    }
}