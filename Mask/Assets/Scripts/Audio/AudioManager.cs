using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("SFX")]
    [SerializeField] public AudioClip shootSFX;
    [SerializeField] public AudioClip explosionSFX;
    [SerializeField] public AudioClip OxygenRefillSFX;
    [SerializeField] public AudioClip DashSFX;

    private AudioSource audioSource;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }


        instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }



    public void PlaySFX(AudioClip clip)
    {
        if (clip == null || audioSource == null) return;

        audioSource.PlayOneShot(clip);
    }

}
