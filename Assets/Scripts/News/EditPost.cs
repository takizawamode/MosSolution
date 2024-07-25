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

            CreatePost.SetActive(true);
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

            CreatePost.SetActive(false);
        }
    }
}
