using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveScript : MonoBehaviour
{
    public GameObject button;
    public TMP_InputField[] inputFields;

    public void OnClick()
    {
       
        button.SetActive(false);
        
        foreach (TMP_InputField inputField in inputFields)
        {
            inputField.interactable = false; //устанавливаем значение interactable для всех inputfields на false
        }
        
    }

}
