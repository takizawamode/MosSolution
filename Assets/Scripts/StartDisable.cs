using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDisable : MonoBehaviour
{
    // ����� ���� ��� ������� Start.
    public GameObject Startobj;

    // ��� 1 �������� ����� � ��������� 2 ���. ��������� ����� "DisableObject" (��������� Start).
    void Start()
    {
        Invoke("DisableObject", 2f);
    }

    // ����� �� ���������� ������� Start.
    private void DisableObject()
    {
        Startobj.SetActive(false);
    }
}
