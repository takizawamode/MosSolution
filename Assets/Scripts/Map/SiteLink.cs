using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiteLink : MonoBehaviour
{
    // ����� ���� ��� ������� link.
    public string link;

    // ����� ��� �������� ����� link.
    public void OpenLink()
    {
        Application.OpenURL(link);
    }
}
