using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class KodInput : MonoBehaviour
{
    TMP_InputField inputField;

    private void Awake()
    {
        inputField = GetComponent<TMP_InputField>();
    }

    private void OnEnable()
    {
        inputField.onValidateInput += ValidateChar;
        inputField.onEndEdit.AddListener(OnEndEdit);
    }

    private void OnDisable()
    {
        inputField.onValidateInput -= ValidateChar;
        inputField.onEndEdit.RemoveListener(OnEndEdit);
    }

    private char ValidateChar(string text, int charIndex, char addedChar)
    {
        // ���������, ��� ������ �������� ���������� ��������
        if (!IsValidChar(addedChar))
        {
            return '\0';
        }

        // ��������� "-" ����� ������ ���� ����, ���� ��� ��� ���
        if (charIndex == 3 && addedChar != '-')
        {
            return (char)addedChar;
        }

        // ��������� ������ � inputfield
        return addedChar;
    }

    private bool IsValidChar(char c)
    {
        // ���������, ��� ������ �������� ���������� ��������
        return char.IsDigit(c) || c == '-';
    }

    private void OnEndEdit(string text)
    {
        // ���������, ��� ����� � inputfield �������� �������������� ������� � ������� "000-000"
        if (!IsValidFormat(text))
        {
            // ���� ����� �� �������� �������������� �������, ������� inputfield
            inputField.text = "";
        }
    }

    private bool IsValidFormat(string text)
    {
        // ���������, ��� ����� � inputfield �������� �������������� ������� � ������� "000-000"
        string pattern = @"^\d{3}-\d{3}$";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(text);
    }
}
