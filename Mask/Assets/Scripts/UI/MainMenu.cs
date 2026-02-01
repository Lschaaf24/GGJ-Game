using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class MainMenu : MonoBehaviour
{

    public bool musicMute;


    public void PlayGame()
    {
        SceneManager.LoadScene("Main Scene");
        
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
