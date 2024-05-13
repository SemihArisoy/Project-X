using System.Collections;
using System.Collections.Generic;
using Unity3DProject.Managers;
using Unity3DProject.Movements;
using UnityEngine;
using UnityEngine.UI;

namespace Unity3DProject.UIs
{
    public class GameOverObject : MonoBehaviour
    {
        [SerializeField] GameObject _gameOverPanel;
        [SerializeField] Button _pauseButton;
        [SerializeField] GameObject _gameOverObject;
        [SerializeField] GameObject _fuelUI;

        public GameObject GameOverPanel
        {
            get { return _gameOverPanel; }
            set { _gameOverPanel = value; }
        }

        private void Awake()
        {
            if(_gameOverPanel.activeSelf) 
            {
                _gameOverPanel.SetActive(false);
            }
        }

        private void OnEnable()
        {
            GameManager.Instance.OnGameOver += HandleOnGameOver;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnGameOver -= HandleOnGameOver;
        }

        private void HandleOnGameOver()
        {
            if (!_gameOverPanel.activeSelf)
            {
                _gameOverPanel.SetActive(true);
                _pauseButton.gameObject.SetActive(false);
                _fuelUI.SetActive(false);
                SoundManager.Instance.VolumeDown(1f);
            }
        }
    }
}
