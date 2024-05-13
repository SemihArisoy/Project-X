using Unity3DProject.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Unity3DProject.UIs
{
    public class MuteButton : MonoBehaviour
    {
        public Image imageToChange; // Deðiþecek resmi tutacak Image bileþeni

        public Sprite newSprite; // Butona týklandýðýnda atayacaðýmýz yeni resim
        public Sprite oldSprite; // Eski resim

        private bool isMuted = false; // Butonun durumu (sessiz mi deðil mi)

        public void OnButtonClick()
        {
            // Butonun durumunu tersine çevir
            isMuted = !isMuted;

            // Butona týklandýðýnda yeni resmi veya eski resmi Image bileþenine atayýn
            if (imageToChange != null)
            {
                if (isMuted)
                {
                    imageToChange.sprite = newSprite; // Yeni resim
                }
                else
                {
                    imageToChange.sprite = oldSprite; // Eski resim
                }
            }
        }

        public void MuteClick()
        {
           if (isMuted)
           {
               SoundManager.Instance.PauseGameMusic();
               Debug.Log("Müzik durduruldu");
           }
           else
           {
               SoundManager.Instance.UnPauseGameMusic();
               SoundManager.Instance.PlayNextSong();
               Debug.Log("Müzik devam ediyor");
           }
        }
    }
}
