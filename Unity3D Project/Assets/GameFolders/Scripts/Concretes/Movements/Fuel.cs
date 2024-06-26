using System;
using System.Collections;
using System.Collections.Generic;
using Unity3DProject.Managers;
using UnityEngine;

namespace Unity3DProject.Movements
{
    public class Fuel : MonoBehaviour
    {

        [SerializeField] float _maxFuel = 100f;
        [SerializeField] float _currentFuel;
        [SerializeField] public ParticleSystem _particleSystem;

        public bool IsEmpty => _currentFuel < 0.1f;
        public float CurrentFuel => _currentFuel / _maxFuel;

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

            //SoundManager.Instance.StopSound(0);
        }

        public void FuelDecrease (float decrease)
        {
            _currentFuel -= decrease;
            _currentFuel = Mathf.Max(_currentFuel, 0f);

            if (_particleSystem.isStopped)
            {
                _particleSystem.Play();
            }

            //SoundManager.Instance.PlaySound(0);
        }
    }
}   
