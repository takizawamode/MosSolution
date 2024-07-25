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
        // Проверяем, что символ является допустимым символом в телефонном номере
        if (!IsValidPhoneChar(addedChar))
        {
            return '\0';
        }

        // Проверяем, что номер начинается с +7
        if (charIndex == 0 && addedChar != '+')
        {
            return '\0';
        }
        else if (charIndex == 1 && addedChar != '7')
        {
            return '\0';
        }

        // Добавляем символ в inputfield
        return addedChar;
    }

    private bool IsValidPhoneChar(char c)
    {
        // Проверяем, что символ является допустимым символом в телефонном номере
        return char.IsDigit(c) || c == '+' || c == '-' || c == '(' || c == ')';
    }

    private void OnEndEdit()
    {
        // Проверяем, что текст в inputfield является действительным телефонным номером
        if (!IsValidPhone(inputField.text))
        {
            // Если текст не является действительным телефонным номером, очищаем inputfield
            inputField.text = "";
        }
    }

    private bool IsValidPhone(string phone)
    {
        // Проверяем, что текст является действительным телефонным номером
        string pattern = @"^\+7\d{10}$";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(phone);
    }
}
