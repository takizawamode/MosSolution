using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class NewsManager : MonoBehaviour
{
    public GameObject postPrefab;
    public VerticalLayoutGroup NewsContent;
    public Image postImage;
    public GameObject Notification1;
    public GameObject Notification3;

    public TMP_InputField titleInputField;
    public TMP_InputField descriptionInputField;

    public void AddPost()
    {
        if (!string.IsNullOrEmpty(titleInputField.text) && !string.IsNullOrEmpty(descriptionInputField.text) && postImage.sprite != null)
        {
            // �������� ����� ��������� �������
            GameObject newPost = Instantiate(postPrefab, NewsContent.transform);

            // ��������� ������ ������ �����
            TextMeshProUGUI titleText = newPost.transform.Find("PostName").GetComponent<TextMeshProUGUI>();
            if (titleText != null)
            {
                // ����������� ����� �� Input ���� � �������� ���������
                titleText.text = titleInputField.text;
            }

            TextMeshProUGUI descriptionText = newPost.transform.Find("PostText").GetComponent<TextMeshProUGUI>();
            if (descriptionText != null)
            {
                // ����������� ����� �� Input ���� � �������� ��������
                descriptionText.text = descriptionInputField.text;
            }

            // �������� �������������� ���������� �������
            TextMeshProUGUI timeText = newPost.transform.Find("PostTime").GetComponent<TextMeshProUGUI>();
            if (timeText != null)
            {
                timeText.text = GetCurrentTime();
            }

            // ������� Image � ����� �����
            Image postImageComponent = newPost.transform.Find("PostImage").GetComponent<Image>();

            if (postImageComponent != null && postImage != null)
            {
                // ��������� ��� �������� �� ����� �����
                postImageComponent.sprite = postImage.sprite;
            }

            // �������� Input ���� ����� ���������� �����
            titleInputField.text = "";
            descriptionInputField.text = "";

            newPost.transform.SetAsFirstSibling();
            // ������������� ��� ������� � ��������� Unity
            newPost.name = "���� " + GetCurrentDate();

            Notification3.SetActive(true);
        }
        else
        {
            Notification1.SetActive(true);
        }
            
    }

    private string GetCurrentTime()
    {
        DateTime currentTime = DateTime.Now;
        return currentTime.ToString("HH:mm");
    }

    private string GetCurrentDate()
    {
        DateTime currentDate = DateTime.Now;
        return currentDate.ToString("dd.MM.yyyy");
    }
}
