using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource sfxSource;
    public AudioSource musicSource;

    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
    }

    public Sound[] sounds;  // Populate this in Inspector
    private Dictionary<string, AudioClip> soundDict;

    void Awake()
    {
        // Singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        soundDict = new Dictionary<string, AudioClip>();
        foreach (Sound s in sounds)
        {
            soundDict[s.name] = s.clip;
        }
    }

    public void PlaySFX(string name, float volume)
    {
        if (soundDict.ContainsKey(name))
        {
            sfxSource.PlayOneShot(soundDict[name], volume);
        }
        else
        {
            Debug.LogWarning("Sound not found: " + name);
        }
    }

    public void PlayMusic(string name)
    {
        if (soundDict.ContainsKey(name))
        {
            musicSource.clip = soundDict[name];
            musicSource.loop = true;
            musicSource.volume = 0.5f; // Set a default volume
            musicSource.Play();
        }
    }
}
