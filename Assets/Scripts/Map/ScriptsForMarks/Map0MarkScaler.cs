using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Добавленные using.
using UnityEngine.UI;

public class Map0MarkScaler : MonoBehaviour
{
    // Вывод поля для выбора метки.
    public Button ScaleMark;

    // Вывод полей для выбора Map0, Map1.
    public GameObject Map0;
    public GameObject Map1;

    // Вывод поля для выбора контента RectTransform и scrollRect.
    public RectTransform Content;
    public ScrollRect scrollRect;

    // Вывод поля для выбора координат положения контента (карты).
    public Vector3 newPosition = new Vector3(-2626.67944f, 3101.07202f, 0f);

    // Метод увеличения масштаба карты по нажатию на метку.
    public void ScaleMarkClick()
    {
        // Если активна Map0, то отключить Map0, включить Map1 и изменить координаты и размер content под размеры карты.
        if (Map0.active == true)
        {
            Map0.SetActive(false);
            Map1.SetActive(true);

            if (Map1.active == true)
            {
                Content.sizeDelta = new Vector2(1140.63f, 1583.34f);
                scrollRect.content.localPosition = newPosition;
            }
        }
    }
}
