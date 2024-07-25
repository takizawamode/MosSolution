using System;
using UnityEngine;
using UnityEngine.UI;

public class DateCalendarFilter : MonoBehaviour
{
    public Toggle addPost;
    public GameObject newsFeed; // Ссылка на объект "Новости (Лента)"
    public string postTag = "Post";

    public void FilterPostsByDate()
    {
        string buttonName = gameObject.name;
        string DateString = buttonName + ".06.2024";

        // Перебираем все дочерние объекты в "Новости (Лента)"
        foreach (Transform postTransform in newsFeed.transform)
        {
            // Проверяем тег объекта
            if (postTransform.CompareTag(postTag))
            {
                // Получаем имя объекта "Пост"
                string postName = postTransform.gameObject.name;

                // Проверяем, содержится ли в имени текущая дата
                if (postName.Contains(DateString))
                {
                    // Если содержится, оставляем объект видимым
                    postTransform.gameObject.SetActive(true);
                }
                else
                {
                    // Если не содержится, делаем объект невидимым
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
