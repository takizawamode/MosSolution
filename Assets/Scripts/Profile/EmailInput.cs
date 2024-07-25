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
        // Проверяем, что символ является допустимым символом в email-адресе
        if (!IsValidEmailChar(addedChar))
        {
            return '\0';
        }

        // Добавляем символ в inputfield
        return addedChar;
    }

    private bool IsValidEmailChar(char c)
    {
        // Проверяем, что символ является допустимым символом в email-адресе
        return char.IsLetterOrDigit(c) || c == '@' || c == '.' || c == '_' || c == '-';
    }

    private void OnEndEdit()
    {
        // Проверяем, что текст в inputfield является действительным email-адресом
        if (!IsValidEmail(inputField.text))
        {
            // Если текст не является действительным email-адресом, очищаем inputfield
            inputField.text = "";
        }
    }

    private bool IsValidEmail(string email)
    {
        // Проверяем, что текст является действительным email-адресом
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(email);
    }
}
