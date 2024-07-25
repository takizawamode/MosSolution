using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Добавленные using.
using UnityEngine.UI;
using TMPro;

public class EditChange : MonoBehaviour
{
    // Вывод поля для выбора цвета для Toggle, Image и TMP_text.
    public Color colorIsOff;
    public Color colorIsOn;

    public Color iconColorIsOff;
    public Color iconColorIsOn;

    // Вывод поля для объектов Toggle, Image и TMP_text.
    public Toggle toggle;
    public Image icon;
    public GameObject SaveButton;

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

            SaveButton.SetActive(true);
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

            SaveButton.SetActive(false);
        }
    }
}