using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity3DProject.Inputs;
using Unity3DProject.Movements;
using UnityEngine;

namespace Unity3DProject.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        DefaultInput _input;
        Mover _mover;

        bool _isForceUp;
        private void Awake()
        {
            _input = new DefaultInput();
            _mover = new Mover(GetComponent<Rigidbody>());
        }

        private void Update()
        {
            if (_input.IsForceUp) 
            {
                _isForceUp = true;
            }
            else
            {
                _isForceUp = false;
            }
        }

        private void FixedUpdate()
        {
            if (_isForceUp)
            {
                _mover.FixedTick();
            }
        }
    }
}

