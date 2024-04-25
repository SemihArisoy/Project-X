using System.Collections;
using System.Collections.Generic;
using Unity3DProject.Managers;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Unity3DProject.Controllers
{
    public class WallController : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            PlayerController player = other.collider.GetComponent<PlayerController>();

            if (player != null )
            {
                GameManager.Instance.GameOver();
            }
        }


    }
}

