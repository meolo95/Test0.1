using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    GameObject draw;

    [SerializeField] AudioClip[] clips;
    [SerializeField] Sound[] sounds = null;

    [SerializeField] AudioSource[] sources = null;
    [SerializeField] AudioSource[] spatial = null;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update

    public void SummonPlay(string sfxName, Vector3 pos)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == sfxName)
            {
                for (int j = 0; j < spatial.Length; j++)
                {
                    if (!spatial[j].isPlaying)
                    {
                        spatial[j].clip = sounds[i].clip;
                        AudioSource.PlayClipAtPoint(spatial[j].clip, pos);
                        return;
                    }
                }
            }
        }
    }

    public void Play(string sfxName)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == sfxName)
            {
                for (int j = 0; j < sources.Length; j++)
                {
                    if (!sources[j].isPlaying)
                    {
                        sources[j].clip = sounds[i].clip;
                        sources[j].Play();
                        return;
                    }
                }
            }
        }
    }

    public void Stop(string sfxName)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == sfxName)
            {
                for (int j = 0; j < sources.Length; j++)
                {
                    if (sources[j].isPlaying)
                    {
                        if (sources[j].clip.name == sounds[i].clip.name)
                        {
                            sources[j].Stop();
                        }
                    }
                }
            }
        }
    }

    public void OnlyPlay(string sfxName)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == sfxName)
            {
                for (int j = 0; j < sources.Length; j++)
                {
                    if (sources[j].isPlaying)
                    {
                        if (sources[j].clip.name == sounds[i].clip.name)
                        {
                            return;
                        }
                    }
                }
                for (int j = 0; j < sources.Length; j++)
                {
                    if (!sources[j].isPlaying)
                    {
                        sources[j].clip = sounds[i].clip;
                        sources[j].Play();
                        return;
                    }
                }
            }
        }
    }

    public void SFXPlay(string sfxName, AudioClip clip, float volume)
    {
        GameObject go = new GameObject(sfxName + "Sound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.Play();

        Destroy(go, clip.length);
    }

    public void SFXDrawPlay(string sfxName, AudioClip clip, float volume)
    {
        draw = new GameObject(sfxName + "Sound");
        AudioSource audioSource = draw.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.Play();

        Destroy(draw, clip.length);
    }

    public void StopPlay()
    {
        Destroy(draw);
    }

    public void SFXHitPlay(string sfxName, Vector3 pos, float volume, float distance)
    {
        GameObject Hit = new GameObject(sfxName + "Sound");
        Hit.transform.position = pos;
        AudioSource audioSource = Hit.AddComponent<AudioSource>();
        audioSource.clip = clips[0];
        audioSource.spatialBlend = 1f;
        audioSource.volume = volume;
        audioSource.maxDistance = distance;
        audioSource.Play();

        Destroy(draw, clips[0].length);
    }
}
