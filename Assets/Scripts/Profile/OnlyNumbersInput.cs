using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class OnlyNumbersInput : MonoBehaviour
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
        // ���������, ��� ������ �������� ���������� ��������
        if (!IsValidChar(addedChar))
        {
            return '\0';
        }

        // ��������� ������ � inputfield
        return addedChar;
    }

    private bool IsValidChar(char c)
    {
        // ���������, ��� ������ �������� ���������� ��������
        return char.IsDigit(c);
    }

    private void OnEndEdit()
    {
        // ������� ��� ���������� ������� �� ������
        inputField.text = Regex.Replace(inputField.text, @"\D", "");
    }
}
