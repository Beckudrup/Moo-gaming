using UnityEngine;

public class DayCycle : MonoBehaviour
{
    // Inspiration from Unity Documentation

    [SerializeField] private float duration;
    private float hueColor, saturationColor, valueColor;
    private float redValue, greenValue, blueValue, alphaValue;
    
    private Color color0 = Color.white;
    private Color color1 = Color.black;
    
    private Light lt;

    void Start()
    {
        lt = GetComponent<Light>(); // Getting the component
    }

    public void Update()
    { 
        Color.RGBToHSV(new Color(redValue,greenValue,blueValue,alphaValue),
            out float hueColor, out float saturationColor, out float valueColor);
      
        valueColor = Mathf.PingPong(Time.time, duration) / duration;
        lt.color = Color.Lerp(color0, color1, valueColor);
    }
}
