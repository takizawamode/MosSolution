using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Добавленные using.
using TMPro;
using UnityEngine.UI;

public class SearchBox : MonoBehaviour
{
    // Вывод поля для выбора поля для ввода текста.
    public TMP_InputField inputField;

    // Вывод поля для выбора объектов в массив buttons.
    public Button[] buttons;

    // Вывод поля для выбора Image.
    public Image ShowHideObject;

    // Метод добавления в функцию onValueChanged для поля для ввода текста метода OnInputChange при загрузке сцены.
    private void Start()
    {
        inputField.onValueChanged.AddListener(delegate { OnInputChange(); });
        OnInputChange();
    }

    // Метод на отоброжение результатов поиска при вводе.
    private void OnInputChange()
    {
        // Если поле для ввода пустое - отображать Image, если нет - скрыть.
        if (string.IsNullOrEmpty(inputField.text))
        {
            ShowHideObject.gameObject.SetActive(true);
        }
        else
        {
            ShowHideObject.gameObject.SetActive(false);
        }

        // Для каждой кнопки сравнить содержание букв в поиске и в тексте кнопки или названии объекта. Если есть совпадение - отобразить кнопки, если нет - не отображать.
        foreach (Button button in buttons)
        {
            if (button.GetComponentInChildren<TMP_Text>().text.ToLower().Contains(inputField.text.ToLower()) || button.name.ToLower().Contains(inputField.text.ToLower()))
            {
                button.gameObject.SetActive(true);
            }
            else
            {
                button.gameObject.SetActive(false);
            }
        }
    }
}
