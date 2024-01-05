using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    GameObject draw;

    [SerializeField] AudioClip[] clips;


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
