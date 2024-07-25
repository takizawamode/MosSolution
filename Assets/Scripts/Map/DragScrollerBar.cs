using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Добавленные using.
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Добавленные ивенты.
public class DragScrollerBar : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    // Вывод поля для выбора ScrollRect.
    public ScrollRect scrollBar;

    // Ивент на начало перетаскивания ScrollRect (ничего).
    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    // Ивент на конец перетаскивания ScrollRect.
    public void OnEndDrag(PointerEventData eventData)
    {
        // При позиции ScrollRect >= 0.45f (чуть меньше половины ScrollRect), переместить вниз 0f со скоростью 0.5f.
        if (scrollBar.verticalNormalizedPosition >= 0.45f)
        {
            LeanTween.value(gameObject, scrollBar.verticalNormalizedPosition, 0f, 0.5f)
            .setEaseInOutSine()
            .setOnUpdate((float val) => { scrollBar.verticalNormalizedPosition = val; });
        }
        // При позиции ScrollRect <= 0.45f (чуть больше половины ScrollRect), переместить вверх 1f со скоростью 0.5f.
        if (scrollBar.verticalNormalizedPosition <= 0.45f)
        {
            LeanTween.value(gameObject, scrollBar.verticalNormalizedPosition, 1f, 0.5f)
            .setEaseInOutSine()
            .setOnUpdate((float val) => { scrollBar.verticalNormalizedPosition = val; });
        }
    }
}
