using System.Collections;
using System.Collections.Generic;
using Unity3DProject.Movements;
using UnityEngine;

namespace Unity3DProject.Controllers
{
    public class RefuelStationController : MonoBehaviour
    {
        [SerializeField] public bool _touch;

        Fuel _fuel;
        private void OnCollisionEnter(Collision other)
        {
            _touch = true;
        }

        private void OnCollisionExit(Collision other)
        {
            _touch = false;
        }

        private void LoadFuel()
        {
            _fuel.FuelIncrease(0.05f);
        }
    }
}
