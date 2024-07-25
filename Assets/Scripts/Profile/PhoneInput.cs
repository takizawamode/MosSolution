using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class PhoneInput : MonoBehaviour
{
    TMP_InputField inputField;

    private void Awake()
    {
        inputField = GetComponent<TMP_InputField>();
    }

    private void OnEnable()
    {
        inputField.onValidateInput += ValidateChar;
    }

    private void OnDisable()
    {
        inputField.onValidateInput -= ValidateChar;
    }

    private char ValidateChar(string text, int charIndex, char addedChar)
    {
        // ���������, ��� ������ �������� ���������� �������� � ���������� ������
        if (!IsValidPhoneChar(addedChar))
        {
            return '\0';
        }

        // ���������, ��� ����� ���������� � +7
        if (charIndex == 0 && addedChar != '+')
        {
            return '\0';
        }
        else if (charIndex == 1 && addedChar != '7')
        {
            return '\0';
        }

        // ��������� ������ � inputfield
        return addedChar;
    }

    private bool IsValidPhoneChar(char c)
    {
        // ���������, ��� ������ �������� ���������� �������� � ���������� ������
        return char.IsDigit(c) || c == '+' || c == '-' || c == '(' || c == ')';
    }

    private void OnEndEdit()
    {
        // ���������, ��� ����� � inputfield �������� �������������� ���������� �������
        if (!IsValidPhone(inputField.text))
        {
            // ���� ����� �� �������� �������������� ���������� �������, ������� inputfield
            inputField.text = "";
        }
    }

    private bool IsValidPhone(string phone)
    {
        // ���������, ��� ����� �������� �������������� ���������� �������
        string pattern = @"^\+7\d{10}$";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(phone);
    }
}
