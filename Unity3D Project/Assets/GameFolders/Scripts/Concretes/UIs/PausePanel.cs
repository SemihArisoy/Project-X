using System.Collections;
using System.Collections.Generic;
using Unity3DProject.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Unity3DProject.UIs
{
    public class PausePanel : MonoBehaviour
    {
        [SerializeField] GameObject _pauseObjectPanel;
        [SerializeField] Button _pauseButton;
        public void PauseButtonClicked()
        {
            _pauseButton.interactable = true;
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0; 
                _pauseObjectPanel.SetActive(true);
                SoundManager.Instance.VolumeDown(1f);
                _pauseButton.gameObject.SetActive(false);
            }
            else if(Time.timeScale == 0)
            {
                Time.timeScale = 1; 
                _pauseObjectPanel.SetActive(false);
                SoundManager.Instance.VolumeUp(1f);
            }
        }
        public void ResumeClicked()
        {
            Time.timeScale = 1;
            _pauseObjectPanel.SetActive(false);
            SoundManager.Instance.VolumeUp(1f);
            _pauseButton.gameObject.SetActive(true);
        }
        public void RestartClicked()
        {
            GameManager.Instance.LoadLevelScene();
            _pauseObjectPanel.SetActive(false);
            Time.timeScale = 1;
            SoundManager.Instance.VolumeUp(1f);
        }
        public void BackMenuClicked()
        {
            GameManager.Instance.LoadMenuScene();
            SoundManager.Instance.StopGameMusic();
            SoundManager.Instance.VolumeUp(1f);
        }
    }
}
