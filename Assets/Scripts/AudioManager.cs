using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Button pauseButton;
    public Sprite pauseSprite;
    public Sprite unPauseSprite;

    private AudioSource audioSource;
    private bool isPause = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        audioSource.Play();
    }

    public void PauseMusic()
    {
        if (!isPause)
        {
            pauseButton.image.sprite = pauseSprite;
            audioSource.Pause();
            isPause = true;
        }
        else
        {
            pauseButton.image.sprite = unPauseSprite;
            audioSource.UnPause();
            isPause = false;
        }
    }
}
