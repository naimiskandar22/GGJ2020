using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static SoundManagerScript instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    public AudioSource bgmAudioSource;
    public AudioSource sfxAudioSource;

    public FloatVariable masterVolume;
    public FloatVariable bgmVolume;
    public FloatVariable sfxVolume;

    public MixerModifierScript mixModifier;

    // Start is called before the first frame update
    void Start()
    {
        SetMasterVolume(masterVolume.value);
        SetBGMVolume(bgmVolume.value);
        SetSFXVolume(sfxVolume.value);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //bgmAudioSource.time += 0.25f;
        }
    }

    public void SetMasterVolume(float value)
    {
        if (mixModifier == null)
            return;

        MixerModifierGroup modify = new MixerModifierGroup("masterVolume", value);

        mixModifier.RunModifierSet(modify);
    }

    public void SetBGMVolume(float value)
    {
        if (bgmAudioSource == null)
            return;

        bgmVolume.value = value;
        bgmAudioSource.volume = bgmVolume.value;
    }

    public void SetSFXVolume(float value)
    {
        if (sfxAudioSource == null)
            return;

        sfxVolume.value = value;
        sfxAudioSource.volume = sfxVolume.value;
    }

    public void PlayBGM(AudioClip clip, bool looping)
    {
        if (bgmAudioSource == null)
            return;

        bgmAudioSource.loop = looping;
        bgmAudioSource.clip = clip;
        bgmAudioSource.Play();
    }

    public void PlaySFXOnce(AudioClip clip)
    {
        if (sfxAudioSource == null)
            return;

        bgmAudioSource.PlayOneShot(clip);
    }

    public void PlaySFXLoop(AudioClip clip)
    {
        if (sfxAudioSource == null)
            return;

        sfxAudioSource.loop = true;
        sfxAudioSource.clip = clip;
        sfxAudioSource.Play();
    }
}
