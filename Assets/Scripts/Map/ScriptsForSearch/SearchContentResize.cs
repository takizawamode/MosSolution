using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ����������� using.
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class SearchContentResize : MonoBehaviour
{
    // ����� ����� ��� ������ scrollRect, content, layoutGroup.
    private ScrollRect scrollRect;
    private RectTransform content;
    private VerticalLayoutGroup layoutGroup;

    // ����� �� ��������� ����������� �������� scrollRect, content, layoutGroup.
    private void Awake()
    {
        scrollRect = GetComponent<ScrollRect>();
        content = scrollRect.content;
        layoutGroup = content.GetComponent<VerticalLayoutGroup>();
    }

    // ����� �� ��������� ������ content � ������ ������� ������ � layoutGroup.
    private void Update()
    {
        // ���������� ������� �������� ��������.
        int visibleChildCount = 0;

        // ������ ��������.
        float contentHeight = 0f;

        // ������ VerticalLayoutGroup � ������ ��������.
        float layoutGroupHeight = layoutGroup.padding.top + layoutGroup.padding.bottom;


        for (int i = 0; i < content.childCount; i++)
        {
            // �������� RectTransform �������� ��������� �������.
            RectTransform childRectTransform = content.GetChild(i).GetComponent<RectTransform>();

            // ���� �������� ������ ������� � �����.
            if (childRectTransform.gameObject.activeSelf)
            {
                // ����������� ������� ������� �������� ��������.
                visibleChildCount++;
                // ��������� ������ ��������� ������� � ���������� ����� ��� � ��������� � ����� ������ ��������.
                contentHeight += childRectTransform.rect.height + layoutGroup.spacing;
            }
        }

        // ���� ���� ���� �� ���� ������� �������� ������.
        if (visibleChildCount > 0)
        {
            // �������� ���������� ����� ��������� ������� �������� �������� � ��������� � ����� ������ ��������.
            contentHeight -= layoutGroup.spacing;
            // ��������� ���������� ����� ����� �������� ��������� ��������� � ������ VerticalLayoutGroup.
            layoutGroupHeight += (visibleChildCount - 1) * layoutGroup.spacing;

            // ������������� ����� �������� sizeDelta ��� �������� � ������ ����������� �����.
            content.sizeDelta = new Vector2(content.sizeDelta.x, contentHeight + layoutGroupHeight);
        }
    }
}
