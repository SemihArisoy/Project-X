using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity3DProject.Abstracts.Utilities;
using Unity3DProject.UIs;
using UnityEngine;

namespace Unity3DProject.Managers
{
    public class SoundManager : SingletonThisObject<SoundManager>
    {
        AudioSource[] _audioSource;
        [SerializeField] AudioSource[] _songs; // �ark�lar� tutacak dizi
        float _currentSongPosition;
        GameOverObject gameOverObject;
        private void Awake()
        {
            SingletonThisGameObject(this);

            _audioSource = GetComponentsInChildren<AudioSource>();

            gameOverObject = FindObjectOfType<GameOverObject>();
        }

        public void PlayNextSong()
        {
            StartCoroutine(PlayNextSongCoroutine());
        }

        public void StopGameMusic()
        {
            StopSound(2);
            StopSound(3);
            StopSound(4);
            StopSound(5);
            StopCoroutine(PlayNextSongCoroutine());
        }

        public void PauseGameMusic()
        {
            PauseSound(0);
            PauseSound(1);
            PauseSound(2);
            PauseSound(3);
        }
        public void UnPauseGameMusic()
        {
            UnPauseSound(0);
            UnPauseSound(1);
            UnPauseSound(2);
            UnPauseSound(3);
        }
        public IEnumerator PlayNextSongCoroutine()
        {
            while (true)
            {
                for (int i = 0; i < _songs.Length; i++)
                {
                    var song = _songs[i];

                    // E�er �ark� devam ediyorsa, kald��� yerden devam et
                    if (song.isPlaying)
                    {
                        song.time = _currentSongPosition;
                    }
                    else
                    {
                        song.Play(); // �ark�y� �al
                        Debug.Log(_songs[i] + "�ark� �al�nd�");
                    }

                    yield return new WaitForSeconds(song.clip.length - _currentSongPosition); // �ark�n�n kalan s�resi kadar bekle
                    _currentSongPosition = 0f; // �ark� bitti�inde konumu s�f�rla
                }
            }
        }
        public void PlaySound(int index)
        {
            if (!_audioSource[index].isPlaying)
            {
                _audioSource[index].Play();
            }
        }
        public void StopSound(int index)
        {
            if (_audioSource[index].isPlaying)
            {
                _audioSource[index].Stop();
            }
        }
        public void PauseSound(int index)
        {
            if (_songs[index].isPlaying)
            {
                _songs[index].Pause();
            }
        }
        public void UnPauseSound(int index)
        {
            if (_songs[index].isPlaying)
            {
                _songs[index].UnPause();
            }
        }
        public void VolumeDown(float decreaseAmount)
        {
            if (gameOverObject != null && gameOverObject.GameOverPanel.activeSelf)
            {
                foreach (var audioSource in _audioSource)
                {
                    audioSource.volume -= decreaseAmount;
                    audioSource.volume = Mathf.Max(0.2f, audioSource.volume);
                    Debug.Log("Volume after decrease: " + audioSource.volume);
                }
            }
            else //gameOverObject oyun basladiktan sonra null d�nd�g� icin else'de de ayn� kod yazildi. NullReferenceException.
            {
                foreach (var audioSource in _audioSource)
                {
                    audioSource.volume -= decreaseAmount;
                    audioSource.volume = Mathf.Max(0.2f, audioSource.volume);
                    Debug.Log("Volume after decrease: " + audioSource.volume);
                }
            }
        }
        public void VolumeUp(float decreaseAmount)
        {
            if (gameOverObject != null && gameOverObject.GameOverPanel.activeSelf)
            {
                foreach (var audioSource in _audioSource)
                {
                    audioSource.volume += decreaseAmount;
                    audioSource.volume = Mathf.Min(0.5f, audioSource.volume); 
                    Debug.Log("Volume after increase: " + audioSource.volume);
                }
            }
            else //gameOverObject oyun basladiktan sonra null d�nd�g� icin else'de de ayn� kod yazildi. NullReferenceException.
            {
                foreach (var audioSource in _audioSource)
                {
                    audioSource.volume += decreaseAmount;
                    audioSource.volume = Mathf.Min(0.5f, audioSource.volume); 
                    Debug.Log("Volume after increase: " + audioSource.volume);
                }
            }
        }
    }
}

