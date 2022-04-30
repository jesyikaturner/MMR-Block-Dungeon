using UnityEngine;
using UnityEngine.Audio;

public class AudioManager
{
    public AudioSource sfxSource;
    public AudioSource musicSource;

    public AudioMixer mixer;

    public void PlaySound()
    {
        if (!sfxSource.isPlaying)
            sfxSource.Play();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="maxValue"></param>
    /// <param name="currValue"></param>
    public void SetVolume(string name, float maxValue, float currValue)
    {
        mixer.SetFloat(name, ConvertToDecibel(currValue / maxValue));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private float ConvertToDecibel(float value)
    {
        return Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20f;
    }
}
