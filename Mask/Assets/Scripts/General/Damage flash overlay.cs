
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Damageflashoverlay : MonoBehaviour
{

    [SerializeField] private Image topEdgeImage;      // Image for the top edge
    [SerializeField] private Image bottomEdgeImage;   // Image for the bottom edge
    [SerializeField] private Image leftEdgeImage;     // Image for the left edge
    [SerializeField] private Image rightEdgeImage;

   // [SerializeField] private Image flashImage;  // Reference to the UI Image
    [SerializeField] private float flashDuration = 0.05f;  // Duration of the flash
    [SerializeField] private Color flashColor = Color.red;  // The color of the flash

    private void Start()
    {
        // Make sure the Image is initially transparent
        // flashImage.color = new Color(flashColor.r, flashColor.g, flashColor.b, 0);
        SetEdgeTransparency(0f);
    }

    public void OnDamageTaken()
    {
        // Start the flash coroutine when the player takes damage
        StartCoroutine(FlashRed());
    }

    private IEnumerator FlashRed()
    {
        Debug.Log("Flashing");
        SetEdgeTransparency(0.1f);

        yield return new WaitForSeconds(flashDuration);

        SetEdgeTransparency(0f);
        
       
    }

    private void SetEdgeTransparency(float alpha)
    {
        topEdgeImage.color = new Color(flashColor.r, flashColor.g, flashColor.b, alpha);
        bottomEdgeImage.color = new Color(flashColor.r, flashColor.g, flashColor.b, alpha);
        leftEdgeImage.color = new Color(flashColor.r, flashColor.g, flashColor.b, alpha);
        rightEdgeImage.color = new Color(flashColor.r, flashColor.g, flashColor.b, alpha);
    }
}


