using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ����������� using.
using UnityEngine.UI;
using TMPro;

public class EditChange : MonoBehaviour
{
    // ����� ���� ��� ������ ����� ��� Toggle, Image � TMP_text.
    public Color colorIsOff;
    public Color colorIsOn;

    public Color iconColorIsOff;
    public Color iconColorIsOn;

    // ����� ���� ��� �������� Toggle, Image � TMP_text.
    public Toggle toggle;
    public Image icon;
    public GameObject SaveButton;

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

            SaveButton.SetActive(true);
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

            SaveButton.SetActive(false);
        }
    }
}