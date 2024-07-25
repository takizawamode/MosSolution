using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ����������� using.
using UnityEngine.UI;

public class MarksShower : MonoBehaviour
{
    // ����� ���� ��� Toggle (������ �������) � �������� ������� ����� (marks).
    public Toggle toggle;
    public GameObject[] marks;

    // �������� ���������� Toggle ��� ����������.
    void Update()
    {
        // ���� ������� ��������, ������������ ������ ����� �� ������� marks.
        if (toggle.isOn)
        {
            foreach (GameObject mark in marks)
            {
                mark.SetActive(true);
            }
        }
        // ���� ������� �s�������, �������������� ������ ����� �� ������� marks.
        else
        {
            foreach (GameObject mark in marks)
            {
                mark.SetActive(false);
            }
        }
    }
}
