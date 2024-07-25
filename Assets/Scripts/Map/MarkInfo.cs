using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ����������� using.
using UnityEngine.UI;

public class MarkInfo : MonoBehaviour
{
    // ����� ���� ��� ������ ������ (�����) mark, ScrollRect scrollBar.
    public Button mark;
    public ScrollRect scrollBar;

    // ����� ������� ��� ������ �������� toggles, ���� ��� ������ search, cross � ������� OtherInfo.
    public GameObject[] toggles;
    public GameObject search;
    public GameObject cross;
    public GameObject[] OtherInfo;
    public GameObject showHide;

    // ����� ���� ��� ������ ������� ����������.
    public GameObject info;

    // ����� ��� ������ ���������� �����.
    public void OnMarkClick()
    {
        // ������ ������� (�������) ������� �������� ������� toggles.
        foreach (GameObject toggle in toggles)
        {
            toggle.SetActive(false);
        }
        // ������ ������� (���������� ������ �����) ������� �������� ������� OtherInfo.
        foreach (GameObject otherInfo in OtherInfo)
        {
            otherInfo.SetActive(false);
        }

        // ������ ������� search, cross.
        search.SetActive(false);
        cross.SetActive(false);

        showHide.SetActive(false);

        // �������� ���������� �����.
        info.SetActive(true);

        // ���� ��������� ScrollRect >= 0.8f (�����), �� ����������� �� 0f (������) �� ��������� 0.5f.
        if (scrollBar.verticalNormalizedPosition >= 0.8f)
        {
            LeanTween.value(gameObject, scrollBar.verticalNormalizedPosition, 0f, 0.5f)
            .setEaseInOutSine()
            .setOnUpdate((float val) => { scrollBar.verticalNormalizedPosition = val; });
        }
    }
}
