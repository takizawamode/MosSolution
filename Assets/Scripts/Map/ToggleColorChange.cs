using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ����������� using.
using UnityEngine.UI;
using TMPro;

public class ToggleColorChange : MonoBehaviour
{
    // ����� ���� ��� ������ ����� ��� Toggle, Image � TMP_text.
    public Color colorIsOff;
    public Color colorIsOn;

    public Color iconColorIsOff;
    public Color iconColorIsOn;

    public Color textColorIsOff;
    public Color textColorIsOn;

    // ����� ���� ��� �������� Toggle, Image � TMP_text.
    public Toggle toggle;
    public Image icon;
    public TMP_Text text;

    // ����� ��������� ������ ��������.
    public void ChangeToggleColor()
    {
        // ���� Toggle = On.
        if (toggle.isOn)
        {
            // ��������� ������ Toggle.
            ColorBlock cb = toggle.colors;
            cb.normalColor = colorIsOn;
            cb.highlightedColor = colorIsOn;
            cb.pressedColor = colorIsOn;
            cb.selectedColor = colorIsOn;
            toggle.colors = cb;

            // ��������� ����� Image.
            icon.color = iconColorIsOn;
            // ��������� ����� TMP_text.
            text.color = textColorIsOn;
        }
        // ���� Toggle = Off.
        else
        {
            // ��������� ������ Toggle.
            ColorBlock cb = toggle.colors;
            cb.normalColor = colorIsOff;
            cb.highlightedColor = colorIsOff;
            cb.pressedColor = colorIsOff;
            cb.selectedColor = colorIsOff;
            toggle.colors = cb;

            // ��������� ����� Image.
            icon.color = iconColorIsOff;
            // ��������� ����� TMP_text.
            text.color = textColorIsOff;
        }
    }
}