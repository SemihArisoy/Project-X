using Unity3DProject.Movements;
using UnityEngine;
using UnityEngine.UI;

namespace Unity3DProject.UIs
{
    public class FuelSlider : MonoBehaviour
    {
        Slider _slider;
        Fuel _fuel;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _fuel = FindObjectOfType<Fuel>();
        }

        private void Update()
        {
            _slider.value = _fuel.CurrentFuel;
        }
    }
}

