using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ����������� using.
using TMPro;

public class CrossClear : MonoBehaviour
{
    // ����� ���� ��� ������ ���� ��� ����� ������.
    public TMP_InputField search;

    // ����� �� �������� ���� ��� ����� ������.
    public void ClearField()
    {
        search.text = string.Empty;
    }
}
