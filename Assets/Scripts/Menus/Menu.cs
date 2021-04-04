using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

namespace PlanetsColony
{
    public class Menu : MonoBehaviour
    {
        public virtual void GenerateList(List<ResourcesSystem.ResourceInfo> resourceInfo) {}
    }
}