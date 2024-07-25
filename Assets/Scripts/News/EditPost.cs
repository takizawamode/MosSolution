using UnityEngine;
using UnityEngine.UI;

public class EditPost : MonoBehaviour
{
    public Color colorIsOff;
    public Color colorIsOn;

    public Color iconColorIsOff;
    public Color iconColorIsOn;

    public Toggle toggle;
    public Image icon;

    public GameObject CreatePost;

    public void ChangeToggleColor()
    {
        // Если Toggle = On.
        if (toggle.isOn)
        {
            // Изменение цветов Toggle.
            ColorBlock cb = toggle.colors;
            cb.normalColor = colorIsOn;
            cb.highlightedColor = colorIsOn;
            cb.pressedColor = colorIsOn;
            cb.selectedColor = colorIsOn;
            toggle.colors = cb;

            // Изменение цвета Image.
            icon.color = iconColorIsOn;

            CreatePost.SetActive(true);
        }
        // Если Toggle = Off.
        else
        {
            // Изменение цветов Toggle.
            ColorBlock cb = toggle.colors;
            cb.normalColor = colorIsOff;
            cb.highlightedColor = colorIsOff;
            cb.pressedColor = colorIsOff;
            cb.selectedColor = colorIsOff;
            toggle.colors = cb;

            // Изменение цвета Image.
            icon.color = iconColorIsOff;

            CreatePost.SetActive(false);
        }
    }
}
