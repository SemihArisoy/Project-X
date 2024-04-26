using System.Collections;
using System.Collections.Generic;
using Unity3DProject.Managers;
using UnityEngine;

namespace Unity3DProject.UIs
{
    public class MenuPanel : MonoBehaviour
    {
        public void StartClicked()
        {
            GameManager.Instance.LoadLevelScene(1);
        }

        public void ExitClicked()
        {
            GameManager.Instance.Exit();
        }
    }
}

