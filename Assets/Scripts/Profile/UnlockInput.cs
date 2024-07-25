using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UnlockInput : MonoBehaviour
{
    public GameObject button; //определяем переключатель
    public TMP_InputField[] inputFields; //определяем массив inputfield



    public void ToggleClick()
    {
        button.SetActive(true);

        foreach (TMP_InputField inputField in inputFields)
        {   
            inputField.interactable = true; //устанавливаем значение interactable для всех inputfields на true
        }
    }
}