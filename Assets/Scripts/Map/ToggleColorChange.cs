using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Добавленные using.
using UnityEngine.UI;
using TMPro;

public class ToggleColorChange : MonoBehaviour
{
    // Вывод поля для выбора цвета для Toggle, Image и TMP_text.
    public Color colorIsOff;
    public Color colorIsOn;

    public Color iconColorIsOff;
    public Color iconColorIsOn;

    public Color textColorIsOff;
    public Color textColorIsOn;

    // Вывод поля для объектов Toggle, Image и TMP_text.
    public Toggle toggle;
    public Image icon;
    public TMP_Text text;

    // Метод изменения цветов объектов.
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
            // Изменение цвета TMP_text.
            text.color = textColorIsOn;
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
            // Изменение цвета TMP_text.
            text.color = textColorIsOff;
        }
    }
}