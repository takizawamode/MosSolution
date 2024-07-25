using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UnlockInput : MonoBehaviour
{
    public GameObject button; //���������� �������������
    public TMP_InputField[] inputFields; //���������� ������ inputfield



    public void ToggleClick()
    {
        button.SetActive(true);

        foreach (TMP_InputField inputField in inputFields)
        {   
            inputField.interactable = true; //������������� �������� interactable ��� ���� inputfields �� true
        }
    }
}