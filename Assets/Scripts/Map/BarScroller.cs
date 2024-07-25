using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Добавленные using.
using UnityEngine.UI;

public class BarScroller : MonoBehaviour
{
    // Вывод поля для выбора ScrollRect.
    public ScrollRect scrollBar;

    // Метод для плавного перемещения ScrollRect при помощи ассета LeanTween.
    public void OnButtonPress()
    {
        // Если положение ScrollRect <= 0.8f (сверху), то переместить на 1f (вниз) со скоростью 0.5f.
        if (scrollBar.verticalNormalizedPosition <= 0.8f)
        {
            LeanTween.value(gameObject, scrollBar.verticalNormalizedPosition, 1f, 0.5f)
            .setEaseInOutSine()
            .setOnUpdate((float val) => { scrollBar.verticalNormalizedPosition = val; });
        }

        // Если положение ScrollRect >= 0.8f (снизу), то переместить на 0f (наверх) со скоростью 0.5f.
        if (scrollBar.verticalNormalizedPosition >=0.8f)
        {
            LeanTween.value(gameObject, scrollBar.verticalNormalizedPosition, 0f, 0.5f)
            .setEaseInOutSine()
            .setOnUpdate((float val) => { scrollBar.verticalNormalizedPosition = val; });
        }
    }
}
