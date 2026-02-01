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
    [SerializeField] public AudioClip ShotgunSFX;
    [SerializeField] public AudioClip PlayerDamage_1SFX;
    [SerializeField] public AudioClip Music_1BGM;



    public bool sfxMute;

    private AudioSource audioSource_sfx;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }


        instance = this;
        DontDestroyOnLoad(gameObject);
        audioSource_sfx = GetComponent<AudioSource>();
    }

    public void ToggleSFXMute()
    {
        sfxMute = !sfxMute;
    }


    public void PlaySFX(AudioClip clip)
    {
        if (clip == null || audioSource_sfx == null || sfxMute) return;

        audioSource_sfx.PlayOneShot(clip);
    }



}
