using UnityEngine;

public class audioManager : MonoBehaviour
{

    public static audioManager Instance;

    [SerializeField] private AudioSource SFXobject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance == null) 
        {
            Instance = this; 
        }
    }

    public void PlaySFX(AudioClip audioClip, Transform spawnTransform, float volume, bool audioShift, float shiftRange)
    {
        if (audioShift)
        {
            AudioSource audioSource = Instantiate(SFXobject, spawnTransform.position, Quaternion.identity);

            audioSource.clip = audioClip;

            audioSource.volume = volume;

            audioSource.pitch = Random.Range(1-shiftRange, 1+shiftRange);
            

            audioSource.Play();

            float clipLength = audioSource.clip.length;

            Destroy(audioSource.gameObject, clipLength);
        }
        else
        {
            AudioSource audioSource = Instantiate(SFXobject, spawnTransform.position, Quaternion.identity);

            audioSource.clip = audioClip;

            audioSource.volume = volume;

            audioSource.Play();

            float clipLength = audioSource.clip.length;

            Destroy(audioSource.gameObject, clipLength);
        }
    }



}
