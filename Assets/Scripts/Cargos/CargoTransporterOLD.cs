using UnityEngine;
using System.Collections;

namespace PlanetsColony
{
    [RequireComponent(typeof(Spaceship), typeof(CargoHandler))]
    public class CargoTransporterOLD : MonoBehaviour
    {
        private Spaceship _spaceship = null;
        private CargoHandler _cargoHandler = null;

        private void Awake()
        {
            _spaceship = GetComponent<Spaceship>();
            _cargoHandler = GetComponent<CargoHandler>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var tempTarget = _spaceship.GetTarget();

            if (collision.transform == tempTarget)
            {
                var tempShipReceiver = tempTarget.GetComponent<CargoLoaderForShips>();
                if (tempShipReceiver != null)
                {
                    tempShipReceiver.AcceptShip(_cargoHandler);
                }
            }
        }
    }
}