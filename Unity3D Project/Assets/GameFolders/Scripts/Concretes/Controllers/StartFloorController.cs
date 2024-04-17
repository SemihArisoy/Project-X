using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity3DProject.Controllers
{
    public class StartFloorController : MonoBehaviour
    {
        private void OnCollisionExit(Collision other)
        {
            PlayerController player = other.collider.gameObject.GetComponent<PlayerController>();

            if (player != null )
            {
                Destroy(this.gameObject);
            }
        }
    }
}

