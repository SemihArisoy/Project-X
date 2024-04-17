using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity3DProject.Movements
{
    public class Fuel : MonoBehaviour
    {

        [SerializeField] float _maxFuel = 100f;
        [SerializeField] float _currentFuel;
        [SerializeField] ParticleSystem _particleSystem;

        public bool IsEmpty => _currentFuel < 0.1f;

        private void Awake()
        {
            _currentFuel = _maxFuel;
        }

        public void FuelIncrease (float increase)
        {
            _currentFuel += increase;
            _currentFuel = Mathf.Min(_currentFuel, _maxFuel);

            if(_particleSystem.isPlaying)
            {
                _particleSystem.Stop();
            }
        }

        public void FuelDecrease (float decrease)
        {
            _currentFuel -= decrease;
            _currentFuel = Mathf.Max(_currentFuel, 0f);

            if (_particleSystem.isStopped)
            {
                _particleSystem.Play();
            }
        }
    }
}   