using System.Collections;
using System.Collections.Generic;
using Unity3DProject.Managers;
using UnityEngine;

namespace Unity3DProject.UIs
{
    public class GameOverPanel : MonoBehaviour
    {
        public void YesClicked()
        {
            GameManager.Instance.LoadLevelScene();
            SoundManager.Instance.VolumeUp(1f);
        }

        public void NoClicked()
        {
            GameManager.Instance.LoadMenuScene();
            SoundManager.Instance.VolumeUp(1f);
        }
    }
}

