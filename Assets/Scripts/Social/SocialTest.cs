using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SocialTest : MonoBehaviour
{
    public TMP_InputField adressObject;
    public TMP_InputField commentObject;

    public Toggle[] accesabilities;

    public GameObject notification;
    public GameObject notification1;

    public void resetTextboxes()
    {
        if (adressObject.text == "" || commentObject.text == "")
        {
            notification1.SetActive(true);
            return;
        }

        // ��������, ��� ���� �� ���� Toggle ������
        bool atLeastOneToggleSelected = false;
        foreach (Toggle toggle in accesabilities)
        {
            if (toggle.isOn)
            {
                atLeastOneToggleSelected = true;
                break;
            }
        }

        // ���� �� ������ �� ���� Toggle, ����� �� ������
        if (!atLeastOneToggleSelected)
        {
            notification1.SetActive(true);
            return;
        }

        adressObject.text = string.Empty;
        commentObject.text = string.Empty;

        foreach (Toggle toggle in accesabilities)
        {
            toggle.isOn = false;
        }

        notification.SetActive(true);
    }
}
