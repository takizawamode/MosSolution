using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ����������� using.
using UnityEngine.UI;

public class Map0MarkScaler : MonoBehaviour
{
    // ����� ���� ��� ������ �����.
    public Button ScaleMark;

    // ����� ����� ��� ������ Map0, Map1.
    public GameObject Map0;
    public GameObject Map1;

    // ����� ���� ��� ������ �������� RectTransform � scrollRect.
    public RectTransform Content;
    public ScrollRect scrollRect;

    // ����� ���� ��� ������ ��������� ��������� �������� (�����).
    public Vector3 newPosition = new Vector3(-2626.67944f, 3101.07202f, 0f);

    // ����� ���������� �������� ����� �� ������� �� �����.
    public void ScaleMarkClick()
    {
        // ���� ������� Map0, �� ��������� Map0, �������� Map1 � �������� ���������� � ������ content ��� ������� �����.
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
