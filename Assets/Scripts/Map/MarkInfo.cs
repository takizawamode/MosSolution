using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Добавленные using.
using UnityEngine.UI;

public class MarkInfo : MonoBehaviour
{
    // Вывод поля для выбора кнопки (метки) mark, ScrollRect scrollBar.
    public Button mark;
    public ScrollRect scrollBar;

    // Вывод массива для выбора объектов toggles, поля для выбора search, cross и массива OtherInfo.
    public GameObject[] toggles;
    public GameObject search;
    public GameObject cross;
    public GameObject[] OtherInfo;
    public GameObject showHide;

    // Вывод поля для выбора объекта информации.
    public GameObject info;

    // Метод для вывода информации метки.
    public void OnMarkClick()
    {
        // Скрыть объекты (выборки) каждого элемента массива toggles.
        foreach (GameObject toggle in toggles)
        {
            toggle.SetActive(false);
        }
        // Скрыть объекты (информацию других меток) каждого элемента массива OtherInfo.
        foreach (GameObject otherInfo in OtherInfo)
        {
            otherInfo.SetActive(false);
        }

        // Скрыть объекты search, cross.
        search.SetActive(false);
        cross.SetActive(false);

        showHide.SetActive(false);

        // Показать информацию метки.
        info.SetActive(true);

        // Если положение ScrollRect >= 0.8f (снизу), то переместить на 0f (наверх) со скоростью 0.5f.
        if (scrollBar.verticalNormalizedPosition >= 0.8f)
        {
            LeanTween.value(gameObject, scrollBar.verticalNormalizedPosition, 0f, 0.5f)
            .setEaseInOutSine()
            .setOnUpdate((float val) => { scrollBar.verticalNormalizedPosition = val; });
        }
    }
}
