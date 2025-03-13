using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonBlink : MonoBehaviour
{
    [SerializeField] private Color colorToBlink = Color.white;
    [SerializeField] private Image imageComponent;

    private Color colorDefault;
    private Color colorFade;

    private void Start()
    {
        colorDefault = imageComponent.color;
    }

    private void Update()
    {
        imageComponent.color = Color.Lerp(colorDefault, colorToBlink, Mathf.Sin(Time.time * 5.00f));
    }
}
