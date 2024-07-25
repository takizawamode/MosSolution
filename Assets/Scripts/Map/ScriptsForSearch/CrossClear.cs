using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Добавленные using.
using TMPro;

public class CrossClear : MonoBehaviour
{
    // Вывод поля для выбора поля для ввода текста.
    public TMP_InputField search;

    // Метод на очищение поля для ввода текста.
    public void ClearField()
    {
        search.text = string.Empty;
    }
}
