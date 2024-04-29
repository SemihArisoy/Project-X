using System.Collections;
using System.Collections.Generic;
using Unity3DProject.Managers;
using UnityEngine;

namespace Unity3DProject.UIs
{
    public class WinConditionPanel : MonoBehaviour
    {
        public void YesClicked()
        {
            GameManager.Instance.LoadLevelScene(1);
        }

        public void BackMenuClicked() 
        {
            GameManager.Instance.LoadMenuScene();
        }
    }
}
