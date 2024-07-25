using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ����������� using.
using UnityEngine.UI;
using UnityEngine.EventSystems;

// ����������� ������.
public class DragScrollerBar : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    // ����� ���� ��� ������ ScrollRect.
    public ScrollRect scrollBar;

    // ����� �� ������ �������������� ScrollRect (������).
    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    // ����� �� ����� �������������� ScrollRect.
    public void OnEndDrag(PointerEventData eventData)
    {
        // ��� ������� ScrollRect >= 0.45f (���� ������ �������� ScrollRect), ����������� ���� 0f �� ��������� 0.5f.
        if (scrollBar.verticalNormalizedPosition >= 0.45f)
        {
            LeanTween.value(gameObject, scrollBar.verticalNormalizedPosition, 0f, 0.5f)
            .setEaseInOutSine()
            .setOnUpdate((float val) => { scrollBar.verticalNormalizedPosition = val; });
        }
        // ��� ������� ScrollRect <= 0.45f (���� ������ �������� ScrollRect), ����������� ����� 1f �� ��������� 0.5f.
        if (scrollBar.verticalNormalizedPosition <= 0.45f)
        {
            LeanTween.value(gameObject, scrollBar.verticalNormalizedPosition, 1f, 0.5f)
            .setEaseInOutSine()
            .setOnUpdate((float val) => { scrollBar.verticalNormalizedPosition = val; });
        }
    }
}
