
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;


public class MainMenu : MonoBehaviour
{

    public bool musicMute;


    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
        
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }

    public void muteSfx()
    {
        if (AudioManager.instance == null)
        {
            Debug.LogError("AudioManager instance is NULL");
            return;
        }

        AudioManager.instance.ToggleSFXMute();
        Debug.Log("Mute toggled");
    }

    



    

}
