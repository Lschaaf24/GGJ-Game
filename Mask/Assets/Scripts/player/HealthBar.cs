using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    [SerializeField]
    private float smoothSpeed = 10f;

    private float targetValue;

    private void Start()
    {
        targetValue = slider.value;
    }
    void Update()
    {
        slider.value = Mathf.Lerp(slider.value, targetValue, Time.deltaTime * smoothSpeed);
    }

    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        targetValue = health;
    }

    public void setHealth(int health)
    {
        targetValue = health;

    }
}
