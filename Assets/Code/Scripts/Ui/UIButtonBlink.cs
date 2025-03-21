using UnityEngine;
using UnityEngine.UI;

namespace Code.Scripts.Ui
{
    public class UIButtonBlink : MonoBehaviour
    {
        [SerializeField] private Color colorToBlink = Color.white;
        [SerializeField] private Image imageComponent;

        private Color _colorDefault;

        private void Start()
        {
            _colorDefault = imageComponent.color;
        }

        private void Update()
        {
            imageComponent.color = Color.Lerp(_colorDefault, colorToBlink, Mathf.Sin(Time.time * 5.00f));
        }
    }
}
