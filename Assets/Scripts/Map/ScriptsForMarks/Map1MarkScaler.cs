using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ����������� using.
using UnityEngine.UI;

public class Map1MarkScaler : MonoBehaviour
{
    // ����� ���� ��� ������ �����.
    public Button ScaleMark;

    // ����� ����� ��� ������ Map1, Map2.
    public GameObject Map1;
    public GameObject Map2;

    // ����� ���� ��� ������ �������� RectTransform � scrollRect.
    public RectTransform Content;
    public ScrollRect scrollRect;

    // ����� ���� ��� ������ ��������� ��������� �������� (�����).
    public Vector3 newPosition = new Vector3(-2626.67944f, 3101.07202f, 0f);

    // ����� ���������� �������� ����� �� ������� �� �����.
    public void ScaleMarkClick()
    {
        // ���� ������� Map1, �� ��������� Map1, �������� Map2 � �������� ���������� � ������ content ��� ������� �����.
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
