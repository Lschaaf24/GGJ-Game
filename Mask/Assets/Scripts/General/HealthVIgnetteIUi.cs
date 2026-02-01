using UnityEngine;
using UnityEngine.UI;

public class HealthVIgnetteIUi : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Image vignetteImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth != null && vignetteImage != null)
        {
            float healthPercent = playerHealth.currentHealth / (float) playerHealth.maxHealth;

            Color vignetteColor = vignetteImage.color;
            vignetteColor.a = Mathf.Lerp(0f, 0.5f, 1 - healthPercent);
            vignetteImage.color = vignetteColor;

        }
    }
}
