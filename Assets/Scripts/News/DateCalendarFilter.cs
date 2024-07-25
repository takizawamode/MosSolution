using System;
using UnityEngine;
using UnityEngine.UI;

public class DateCalendarFilter : MonoBehaviour
{
    public Toggle addPost;
    public GameObject newsFeed; // ������ �� ������ "������� (�����)"
    public string postTag = "Post";

    public void FilterPostsByDate()
    {
        string buttonName = gameObject.name;
        string DateString = buttonName + ".06.2024";

        // ���������� ��� �������� ������� � "������� (�����)"
        foreach (Transform postTransform in newsFeed.transform)
        {
            // ��������� ��� �������
            if (postTransform.CompareTag(postTag))
            {
                // �������� ��� ������� "����"
                string postName = postTransform.gameObject.name;

                // ���������, ���������� �� � ����� ������� ����
                if (postName.Contains(DateString))
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

        DateTime currentDate = DateTime.Now;
        string currentDateNow = currentDate.ToString("dd.MM.yyyy");

        if (DateString != currentDateNow)
        {
            addPost.interactable = false;
        }
        else
        {
            addPost.interactable = true;
        }
    }
}
