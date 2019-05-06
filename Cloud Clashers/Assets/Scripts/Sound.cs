using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]

public class Sound
{
    internal readonly bool Mute;
    public string name;

    public AudioClip clip;

    [Range(0f, 2f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;

    public bool loop;
    public bool PlayOnAwake;
    public bool mute;
    public bool pause;

    [HideInInspector]
    public AudioSource source;

}
