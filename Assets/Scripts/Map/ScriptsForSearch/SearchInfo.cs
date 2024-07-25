using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Добавленные using.
using UnityEngine.UI;

public class SearchInfo : MonoBehaviour
{
    // Вывод массива для выбора объектов toggles, поля для выбора search, cross и массива OtherInfo.
    public GameObject[] toggles;
    public GameObject search;
    public GameObject cross;

    /*
    public GameObject Map0;
    public GameObject Map1;
    public GameObject Map2;
    public GameObject Map3;

    public RectTransform Content;

    public ScrollRect scrollRect;
    public Vector3 newPosition = new Vector3(-2626.67944f, 3101.07202f, 0f);
    */

    // Вывод поля для выбора объекта информации.
    public GameObject info;

    // Метод на вывод информации по нажатию на кнопку.
    public void InfoShow()
    {
        // Скрыть объекты (выборки) каждого элемента массива toggles.
        foreach (GameObject toggle in toggles)
        {
            toggle.SetActive(false);
        }

        // Скрыть объекты search, cross.
        search.SetActive(false);
        cross.SetActive(false);

        // Показать информацию метки.
        info.SetActive(true);

        /*
        if (Map0.active == true || Map1.active == true || Map2.active == true || Map3.active == true)
        {
            Map0.SetActive(false);
            Map1.SetActive(false);
            Map2.SetActive(false);

            Map3.SetActive(true);

            Content.sizeDelta = new Vector2(3970.7f, 5177.68f);
            scrollRect.content.localPosition = newPosition;
        }
        */
    }
}
