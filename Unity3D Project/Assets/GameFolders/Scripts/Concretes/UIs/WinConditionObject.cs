using System.Collections;
using System.Collections.Generic;
using Unity3DProject.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Unity3DProject.UIs
{
    public class WinConditionObject : MonoBehaviour
    {
        [SerializeField] GameObject _winConditionPanel;
        [SerializeField] Button _pauseButton;
        [SerializeField] GameObject _fuelUI;

        private void Awake()
        {
            if (_winConditionPanel.activeSelf)
            {
                _winConditionPanel.SetActive(false);
            }
        }

        private void OnEnable()
        {
            GameManager.Instance.OnMissionSucced += HandleOnMissionSucced;
        }

        private void OnDisable()
        {
             GameManager.Instance.OnMissionSucced -= HandleOnMissionSucced;
        }
        private void HandleOnMissionSucced()
        {
            if (!_winConditionPanel.activeSelf)
            {
                _winConditionPanel.SetActive(true);
                _pauseButton.gameObject.SetActive(false);
                _fuelUI.SetActive(false);
            }
        }
    }
}