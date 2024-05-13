using System.Collections;
using System.Collections.Generic;
using Unity3DProject.Managers;
using UnityEngine;

namespace Unity3DProject.UIs
{
    public class MenuPanel : MonoBehaviour
    {
        private void Awake()
        {
            SoundManager.Instance.PlaySound(0);
        }
        public void StartClicked()
        {
            GameManager.Instance.LoadLevelScene(1);
            SoundManager.Instance.PlayNextSong();
            Time.timeScale = 1;
        }

        public void ExitClicked()
        {
            GameManager.Instance.Exit();
        }
    }
}

