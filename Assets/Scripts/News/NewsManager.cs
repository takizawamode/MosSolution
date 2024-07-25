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
            // Создайте новый экземпляр префаба
            GameObject newPost = Instantiate(postPrefab, NewsContent.transform);

            // Заполните данные нового поста
            TextMeshProUGUI titleText = newPost.transform.Find("PostName").GetComponent<TextMeshProUGUI>();
            if (titleText != null)
            {
                // Используйте текст из Input поля в качестве заголовка
                titleText.text = titleInputField.text;
            }

            TextMeshProUGUI descriptionText = newPost.transform.Find("PostText").GetComponent<TextMeshProUGUI>();
            if (descriptionText != null)
            {
                // Используйте текст из Input поля в качестве описания
                descriptionText.text = descriptionInputField.text;
            }

            // Добавьте автоматическое заполнение времени
            TextMeshProUGUI timeText = newPost.transform.Find("PostTime").GetComponent<TextMeshProUGUI>();
            if (timeText != null)
            {
                timeText.text = GetCurrentTime();
            }

            // Найдите Image в новом посте
            Image postImageComponent = newPost.transform.Find("PostImage").GetComponent<Image>();

            if (postImageComponent != null && postImage != null)
            {
                // Присвойте ему значение из вашей формы
                postImageComponent.sprite = postImage.sprite;
            }

            // Очистите Input поля после добавления поста
            titleInputField.text = "";
            descriptionInputField.text = "";

            newPost.transform.SetAsFirstSibling();
            // Устанавливаем имя объекта в редакторе Unity
            newPost.name = "Пост " + GetCurrentDate();

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
