using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ����������� using.
using UnityEngine.UI;

public class MapScaler : MonoBehaviour
{
    // ����� ���� ��� ������ Plus � Minus.
    public Button plusButton;
    public Button minusButton;

    // ����� ���� ��� ������� ��� �������� Map0, Map1, Map2, Map3.
    public GameObject[] Maps;

    // ����� ���� ��� ������� ������������� ������� Content.
    public RectTransform Content;

    // ��������� ��������� � ����������� ������ Plus � Minus �����������.
    void Update()
    {
        // ��� ����� ������� ���������������� (���� ������ Map3 �������) ����������� ������ Plus.
        if (Maps[3].active == true)
        {
            plusButton.interactable = false;
        }
        // ��������� ������ Plus � ��������� ��������� ����������������.
        else
            plusButton.interactable = true;

        // ��� ����� ��������� ���������������� (���� ������ Map0 �������) ����������� ������ Minus.
        if (Maps[0].active == true)
        {
            minusButton.interactable = false;
        }
        // ��������� ������ Minus � ��������� ��������� ����������������.
        else
            minusButton.interactable = true;
    }

    // ����� ���������� �������� ����� ��� ������� �� ������ Plus.
    public void PlusClick()
    {
        // ����, ������� ��������� ���������� ������� ������� �� ������� Maps.
        for (int i = 0; i < Maps.Length; i++)
        {
            if (Maps[i].active == true)
            {
                // ���������� ����������� ������� Map � ��������� ���������� ������� Map �� �������.
                Maps[i].SetActive(false);
                Maps[i + 1].SetActive(true);

                // ���������� ����� (�.�. ���� ���������� ��������).
                break;
            }
        }

        // ����� ������ ��������� ������ �����.
        MapBorderResize();
    }

    // ����� ���������� �������� ����� ��� ������� �� ������ Minus.
    public void MinusClick()
    {
        // ����, ������� ��������� ���������� ������� ������� �� ������� Maps c ���������� ��������.
        for (int i = 3; i < Maps.Length; i--)
        {
            if (Maps[i].active == true)
            {
                // ���������� ����������� ������� Map � ��������� ����������� ������� Map �� �������.
                Maps[i].SetActive(false);
                Maps[i - 1].SetActive(true);

                // ���������� ����� (�.�. ���� ���������� ��������).
                break;
            }
        }

        // ����� ������ ��������� ������ �����.
        MapBorderResize();
    }

    // ����� ��������� ������� ������ Content (�����).
    public void MapBorderResize()
    {
        // ���� ������ Map0 ������� - ��������� ������� Width � Height ��� Content � �.�.
        if (Maps[0].active == true)
        {
            Content.sizeDelta = new Vector2(699.66f, 1297.68f);
        }
        if (Maps[1].active == true)
        {
            Content.sizeDelta = new Vector2(1140.63f, 1583.34f);
        }
        if (Maps[2].active == true)
        {
            Content.sizeDelta = new Vector2(2330.08f, 2980.9f);
        }
        if (Maps[3].active == true)
        {
            Content.sizeDelta = new Vector2(3970.7f, 5177.68f);
        }
    }
}
