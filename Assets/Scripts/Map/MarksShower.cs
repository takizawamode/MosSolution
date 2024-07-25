using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Добавленные using.
using UnityEngine.UI;

public class MarksShower : MonoBehaviour
{
    // Вывод поля для Toggle (кнопки выборки) и создание массива меток (marks).
    public Toggle toggle;
    public GameObject[] marks;

    // Проверка активности Toggle при обновлении.
    void Update()
    {
        // Если выборка включена, активировать каждую метку из массива marks.
        if (toggle.isOn)
        {
            foreach (GameObject mark in marks)
            {
                mark.SetActive(true);
            }
        }
        // Если выборка вsключена, диактивировать каждую метку из массива marks.
        else
        {
            foreach (GameObject mark in marks)
            {
                mark.SetActive(false);
            }
        }
    }
}
