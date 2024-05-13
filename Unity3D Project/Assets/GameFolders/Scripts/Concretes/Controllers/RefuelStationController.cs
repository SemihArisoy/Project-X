using UnityEngine;

namespace Unity3DProject.Controllers
{
    public class RefuelStationController : MonoBehaviour
    {
        public bool _touch;
        private void OnCollisionEnter(Collision other)
        {
            _touch = true;
        }

        private void OnCollisionExit(Collision other)
        {
            _touch = false;
        }
    }
}
