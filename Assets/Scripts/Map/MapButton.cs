using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ����������� using.
using UnityEngine.UI;

public class MapButton : MonoBehaviour
{
    // ����� ���� ��� ������ ������ ScrollRect, ScrollRect Map, ScrollRect scrollBar.
    public Button ScrollRect;
    public ScrollRect Map;
    public ScrollRect scrollBar;

    // ����� ������� ��� ������ �������� toggles, ���� ��� ������ search, cross.
    public GameObject[] toggles;
    public GameObject search;
    public GameObject cross;

    // ����� ������� ��� ������ �������� Infos.
    public GameObject[] Infos;

    public GameObject showHide;

    // ������� ���������� visible ��� �������� ��������� ����������.
    public bool visibile = true;

    // ��� �������� ����� �������� ��������� ��� ������ OnScrollRectClick.
    void Start()
    {
        Map.onValueChanged.AddListener(delegate { OnScrollRectClick(); } );
    }

    // ����� ������� ���������� �� scrollBar ��� ������� �� ����� (Map).
    public void OnScrollRectClick()
    {
        // ���� ����� �� ���������.
        if (Map.velocity.magnitude == 0)
        {
            // ������ ������� (����������) ������� �������� ������� Infos.
            foreach (GameObject info in Infos)
            {
                info.SetActive(false);
            }

            // �������� ������� (�������) ������� �������� ������� toggles.
            foreach (GameObject toggle in toggles)
            {
                toggle.SetActive(true);
            }

            // �������� ������� search, cross.
            search.SetActive(true);
            cross.SetActive(true);

            showHide.SetActive(true);

            // ��������� ���������� = false.
            visibile = false;

            // ���� ��������� ScrollRect <= 0.8f (������), �� ����������� �� 1f (����) �� ��������� 0.5f.
            if (scrollBar.verticalNormalizedPosition <= 0.8f)
            {
                LeanTween.value(gameObject, scrollBar.verticalNormalizedPosition, 1f, 0.5f)
                .setEaseInOutSine()
                .setOnUpdate((float val) => { scrollBar.verticalNormalizedPosition = val; });
            }
        }
        // ���� ���������� �� ����� (false) � ����� ��������� - �� ���������� ������ ������� � �����.
        else if (visibile = false && Map.velocity.magnitude != 0)
        {
            foreach (GameObject toggle in toggles)
            {
                toggle.SetActive(false);
            }
            search.SetActive(false);
            cross.SetActive(false);
        }
    }
}
