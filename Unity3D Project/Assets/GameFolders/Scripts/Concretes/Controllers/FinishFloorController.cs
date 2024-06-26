using System.Collections;
using System.Collections.Generic;
using Unity3DProject.Managers;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Unity3DProject.Controllers
{
    public class FinishFloorController : MonoBehaviour
    {
        [SerializeField] GameObject _finishFireWork;
        [SerializeField] GameObject _finishLight;

        private void OnCollisionEnter(Collision other)
        {
            PlayerController player = other.collider.GetComponent<PlayerController>();

            if (player == null || !player.CanMove) return;

            if(other.GetContact(0).normal.y == -1)
            {
                _finishFireWork.gameObject.SetActive(true);
                _finishLight.gameObject.SetActive(true);
                GameManager.Instance.MissionSucced();
            }
            else
            {
                //Game Over
                GameManager.Instance.GameOver();
            }
        }
    }
}

