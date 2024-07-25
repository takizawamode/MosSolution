using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ����������� using.
using TMPro;
using UnityEngine.UI;

public class SearchBox : MonoBehaviour
{
    // ����� ���� ��� ������ ���� ��� ����� ������.
    public TMP_InputField inputField;

    // ����� ���� ��� ������ �������� � ������ buttons.
    public Button[] buttons;

    // ����� ���� ��� ������ Image.
    public Image ShowHideObject;

    // ����� ���������� � ������� onValueChanged ��� ���� ��� ����� ������ ������ OnInputChange ��� �������� �����.
    private void Start()
    {
        inputField.onValueChanged.AddListener(delegate { OnInputChange(); });
        OnInputChange();
    }

    // ����� �� ����������� ����������� ������ ��� �����.
    private void OnInputChange()
    {
        // ���� ���� ��� ����� ������ - ���������� Image, ���� ��� - ������.
        if (string.IsNullOrEmpty(inputField.text))
        {
            ShowHideObject.gameObject.SetActive(true);
        }
        else
        {
            ShowHideObject.gameObject.SetActive(false);
        }

        // ��� ������ ������ �������� ���������� ���� � ������ � � ������ ������ ��� �������� �������. ���� ���� ���������� - ���������� ������, ���� ��� - �� ����������.
        foreach (Button button in buttons)
        {
            if (button.GetComponentInChildren<TMP_Text>().text.ToLower().Contains(inputField.text.ToLower()) || button.name.ToLower().Contains(inputField.text.ToLower()))
            {
                button.gameObject.SetActive(true);
            }
            else
            {
                button.gameObject.SetActive(false);
            }
        }
    }
}
