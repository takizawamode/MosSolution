using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ����������� using.
using UnityEngine.UI;

public class BarScroller : MonoBehaviour
{
    // ����� ���� ��� ������ ScrollRect.
    public ScrollRect scrollBar;

    // ����� ��� �������� ����������� ScrollRect ��� ������ ������ LeanTween.
    public void OnButtonPress()
    {
        // ���� ��������� ScrollRect <= 0.8f (������), �� ����������� �� 1f (����) �� ��������� 0.5f.
        if (scrollBar.verticalNormalizedPosition <= 0.8f)
        {
            LeanTween.value(gameObject, scrollBar.verticalNormalizedPosition, 1f, 0.5f)
            .setEaseInOutSine()
            .setOnUpdate((float val) => { scrollBar.verticalNormalizedPosition = val; });
        }

        // ���� ��������� ScrollRect >= 0.8f (�����), �� ����������� �� 0f (������) �� ��������� 0.5f.
        if (scrollBar.verticalNormalizedPosition >=0.8f)
        {
            LeanTween.value(gameObject, scrollBar.verticalNormalizedPosition, 0f, 0.5f)
            .setEaseInOutSine()
            .setOnUpdate((float val) => { scrollBar.verticalNormalizedPosition = val; });
        }
    }
}
