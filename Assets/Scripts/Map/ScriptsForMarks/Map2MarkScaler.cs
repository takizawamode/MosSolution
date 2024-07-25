using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ����������� using.
using UnityEngine.UI;

public class Map2MarkScaler : MonoBehaviour
{
    // ����� ���� ��� ������ �����.
    public Button ScaleMark;

    // ����� ����� ��� ������ Map2, Map3.
    public GameObject Map2;
    public GameObject Map3;

    // ����� ���� ��� ������ �������� RectTransform � scrollRect.
    public RectTransform Content;
    public ScrollRect scrollRect;

    // ����� ���� ��� ������ ��������� ��������� �������� (�����).
    public Vector3 newPosition = new Vector3(-2626.67944f, 3101.07202f, 0f);

    // ����� ���������� �������� ����� �� ������� �� �����.
    public void ScaleMarkClick()
    {
        // ���� ������� Map2, �� ��������� Map2, �������� Map3 � �������� ���������� � ������ content ��� ������� �����.
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
