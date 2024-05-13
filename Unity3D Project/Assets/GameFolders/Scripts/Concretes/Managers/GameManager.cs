using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity3DProject.Abstracts.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity3DProject.Managers
{
    public class GameManager : SingletonThisObject<GameManager>
    {
        public event System.Action OnGameOver;
        public event System.Action OnMissionSucced;

        private void Awake()
        {
            SingletonThisGameObject(this);
        }

        public void GameOver()
        {
            OnGameOver?.Invoke();
        }
        public void MissionSucced()
        {
            OnMissionSucced?.Invoke();
        }

        public void LoadLevelScene(int levelIndex = 0)
        {
            StartCoroutine(LoadLevelSceneAsync(levelIndex));

        }

        private IEnumerator LoadLevelSceneAsync(int levelIndex)
        {
            SoundManager.Instance.StopSound(0);
            //SoundManager.Instance.PlayNextSong();
            yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex +  levelIndex);
        }

        public void LoadMenuScene()
        {
            StartCoroutine(LoadMenuSceneAsync());
        }
        
        private IEnumerator LoadMenuSceneAsync()
        {
            SoundManager.Instance.PlaySound(0);
            yield return SceneManager.LoadSceneAsync("Menu");
            SoundManager.Instance.StopGameMusic();
        }
        public void Exit()
        {
            Debug.Log("Exit Process On Triggered");
            Application.Quit();
        }
    }
}
