using UnityEngine;
using System;

public class NewsFilter : MonoBehaviour
{
    public GameObject newsFeed; // ������ �� ������ "������� (�����)"
    public string postTag = "Post";

    void Start()
    {
        FilterPostsByDate();
    }

    void FilterPostsByDate()
    {
        DateTime currentDate = DateTime.Now;
        string todayDateString = currentDate.ToString("dd.MM.yyyy");

        // ���������� ��� �������� ������� � "������� (�����)"
        foreach (Transform postTransform in newsFeed.transform)
        {
            // ��������� ��� �������
            if (postTransform.CompareTag(postTag))
            {
                // �������� ��� ������� "����"
                string postName = postTransform.gameObject.name;

                // ���������, ���������� �� � ����� ������� ����
                if (postName.Contains(todayDateString))
                {
                    // ���� ����������, ��������� ������ �������
                    postTransform.gameObject.SetActive(true);
                }
                else
                {
                    // ���� �� ����������, ������ ������ ���������
                    postTransform.gameObject.SetActive(false);
                }
            }
        }
    }
}
