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
        // Проверяем, что символ является допустимым символом
        if (!IsValidChar(addedChar))
        {
            return '\0';
        }

        // Добавляем "-" после первых трех цифр, если его еще нет
        if (charIndex == 3 && addedChar != '-')
        {
            return (char)addedChar;
        }

        // Добавляем символ в inputfield
        return addedChar;
    }

    private bool IsValidChar(char c)
    {
        // Проверяем, что символ является допустимым символом
        return char.IsDigit(c) || c == '-';
    }

    private void OnEndEdit(string text)
    {
        // Проверяем, что текст в inputfield является действительным номером в формате "000-000"
        if (!IsValidFormat(text))
        {
            // Если текст не является действительным номером, очищаем inputfield
            inputField.text = "";
        }
    }

    private bool IsValidFormat(string text)
    {
        // Проверяем, что текст в inputfield является действительным номером в формате "000-000"
        string pattern = @"^\d{3}-\d{3}$";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(text);
    }
}
