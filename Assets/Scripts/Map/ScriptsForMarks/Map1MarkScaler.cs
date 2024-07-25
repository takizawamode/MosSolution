using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Добавленные using.
using UnityEngine.UI;

public class Map1MarkScaler : MonoBehaviour
{
    // Вывод поля для выбора метки.
    public Button ScaleMark;

    // Вывод полей для выбора Map1, Map2.
    public GameObject Map1;
    public GameObject Map2;

    // Вывод поля для выбора контента RectTransform и scrollRect.
    public RectTransform Content;
    public ScrollRect scrollRect;

    // Вывод поля для выбора координат положения контента (карты).
    public Vector3 newPosition = new Vector3(-2626.67944f, 3101.07202f, 0f);

    // Метод увеличения масштаба карты по нажатию на метку.
    public void ScaleMarkClick()
    {
        // Если активна Map1, то отключить Map1, включить Map2 и изменить координаты и размер content под размеры карты.
        if (Map1.active == true)
        {
            Map1.SetActive(false);
            Map2.SetActive(true);

            if (Map2.active == true)
            {
                Content.sizeDelta = new Vector2(2330.08f, 2980.9f);
                scrollRect.content.localPosition = newPosition;
            }
        }
    }
}
