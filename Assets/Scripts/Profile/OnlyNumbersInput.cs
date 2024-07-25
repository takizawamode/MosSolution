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
        // Проверяем, что символ является допустимым символом
        if (!IsValidChar(addedChar))
        {
            return '\0';
        }

        // Добавляем символ в inputfield
        return addedChar;
    }

    private bool IsValidChar(char c)
    {
        // Проверяем, что символ является допустимым символом
        return char.IsDigit(c);
    }

    private void OnEndEdit()
    {
        // Удаляем все нецифровые символы из текста
        inputField.text = Regex.Replace(inputField.text, @"\D", "");
    }
}
