using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource FxSource;

    [SerializeField] AudioClip _musicClip;
    [SerializeField] AudioClip _coinsSoundClip;
    [SerializeField] AudioClip _buttonClickClip;

    private void Start()
    {
        CarSensor.CoinsCollected += CoinsCollectedsound;
    }
    void CoinsCollectedsound()
    {
        FxSource.PlayOneShot(_coinsSoundClip);
    }
    public void OnButtonClick()
    {
        FxSource.PlayOneShot(_buttonClickClip);
    }
}
