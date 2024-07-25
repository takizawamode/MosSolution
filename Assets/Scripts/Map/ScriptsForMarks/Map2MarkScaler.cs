using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Добавленные using.
using UnityEngine.UI;

public class Map2MarkScaler : MonoBehaviour
{
    // Вывод поля для выбора метки.
    public Button ScaleMark;

    // Вывод полей для выбора Map2, Map3.
    public GameObject Map2;
    public GameObject Map3;

    // Вывод поля для выбора контента RectTransform и scrollRect.
    public RectTransform Content;
    public ScrollRect scrollRect;

    // Вывод поля для выбора координат положения контента (карты).
    public Vector3 newPosition = new Vector3(-2626.67944f, 3101.07202f, 0f);

    // Метод увеличения масштаба карты по нажатию на метку.
    public void ScaleMarkClick()
    {
        // Если активна Map2, то отключить Map2, включить Map3 и изменить координаты и размер content под размеры карты.
        if (Map2.active == true)
        {
            Map2.SetActive(false);
            Map3.SetActive(true);

            if (Map3.active == true)
            {
                Content.sizeDelta = new Vector2(3970.7f, 5177.68f);
                scrollRect.content.localPosition = newPosition;
            }
        }
    }
}
