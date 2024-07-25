using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class OnlyRussianSymbols : MonoBehaviour
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
        if (!char.IsLetter(addedChar))
        {
            return '\0';
        }

        if (!IsCyrillic(addedChar))
        {
            return '\0';
        }

        return addedChar;
    }

    private bool IsCyrillic(char c)
    {
        return ((int)c >= 0x0400 && (int)c <= 0x04FF) || ((int)c >= 0x0500 && (int)c <= 0x052F);
    }
}