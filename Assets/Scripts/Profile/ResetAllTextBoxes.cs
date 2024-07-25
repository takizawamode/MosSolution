using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResetAllTextBoxes : MonoBehaviour
{
    public TMP_InputField nameObject;
    public TMP_InputField adressObject;
    public TMP_InputField commentObject;

    public Toggle[] accesabilities;

    public GameObject notification;
    public GameObject notification1;

    public void resetTextboxes()
    {
        if (nameObject.text == "" || adressObject.text == "" || commentObject.text == "")
        {
            notification1.SetActive(true);
            return;
        }

        // Проверка, что хотя бы один Toggle выбран
        bool atLeastOneToggleSelected = false;
        foreach (Toggle toggle in accesabilities)
        {
            if (toggle.isOn)
            {
                atLeastOneToggleSelected = true;
                break;
            }
        }

        // Если не выбран ни один Toggle, выход из метода
        if (!atLeastOneToggleSelected)
        {
            notification1.SetActive(true);
            return;
        }

        nameObject.text = string.Empty;
        adressObject.text = string.Empty;
        commentObject.text = string.Empty;  

        foreach (Toggle toggle in accesabilities) 
        {
            toggle.isOn = false;
        }

        notification.SetActive(true);
    }    
}
