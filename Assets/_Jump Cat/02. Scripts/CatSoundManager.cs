using UnityEngine;

public class CatSoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip[] bgmClips;
    public AudioClip[] eventClips;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        BGMSound(0); // 0: 인트로 배경음악, 1: 플레이 배경음악
    }

    public void BGMSound(int index)
    {
        audioSource.clip = bgmClips[index];
        audioSource.Play();
    }

    public void BGMSound(int index, float volume)
    {
        audioSource.clip = bgmClips[index];
        audioSource.volume = volume;
        audioSource.Play();
    }
    
    public void BGMSound(int index, float volume, bool isLoop)
    {
        audioSource.clip = bgmClips[index];
        audioSource.volume = volume;
        audioSource.loop = isLoop;
        audioSource.Play();
    }

    public void EventSound(int index) // 인덱스로 찾는 기능
    {
        audioSource.PlayOneShot(eventClips[index]);
    }

    public void EventSound(string clipName) // 이름으로 찾는 기능
    {
        foreach (AudioClip clip in eventClips)
        {
            if (clip.name == clipName)
            {
                audioSource.PlayOneShot(clip);
                break;
            }
        }
    }
}