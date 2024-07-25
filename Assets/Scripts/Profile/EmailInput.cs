using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class EmailInput : MonoBehaviour
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
        // ���������, ��� ������ �������� ���������� �������� � email-������
        if (!IsValidEmailChar(addedChar))
        {
            return '\0';
        }

        // ��������� ������ � inputfield
        return addedChar;
    }

    private bool IsValidEmailChar(char c)
    {
        // ���������, ��� ������ �������� ���������� �������� � email-������
        return char.IsLetterOrDigit(c) || c == '@' || c == '.' || c == '_' || c == '-';
    }

    private void OnEndEdit()
    {
        // ���������, ��� ����� � inputfield �������� �������������� email-�������
        if (!IsValidEmail(inputField.text))
        {
            // ���� ����� �� �������� �������������� email-�������, ������� inputfield
            inputField.text = "";
        }
    }

    private bool IsValidEmail(string email)
    {
        // ���������, ��� ����� �������� �������������� email-�������
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(email);
    }
}
