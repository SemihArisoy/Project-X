using Unity3DProject.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Unity3DProject.UIs
{
    public class MuteButton : MonoBehaviour
    {
        public Image imageToChange; // De�i�ecek resmi tutacak Image bile�eni

        public Sprite newSprite; // Butona t�kland���nda atayaca��m�z yeni resim
        public Sprite oldSprite; // Eski resim

        private bool isMuted = false; // Butonun durumu (sessiz mi de�il mi)

        public void OnButtonClick()
        {
            // Butonun durumunu tersine �evir
            isMuted = !isMuted;

            // Butona t�kland���nda yeni resmi veya eski resmi Image bile�enine atay�n
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
               Debug.Log("M�zik durduruldu");
           }
           else
           {
               SoundManager.Instance.UnPauseGameMusic();
               SoundManager.Instance.PlayNextSong();
               Debug.Log("M�zik devam ediyor");
           }
        }
    }
}
