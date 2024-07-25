using UnityEngine;
using System;

public class NewsFilter : MonoBehaviour
{
    public GameObject newsFeed; // Ссылка на объект "Новости (Лента)"
    public string postTag = "Post";

    void Start()
    {
        FilterPostsByDate();
    }

    void FilterPostsByDate()
    {
        DateTime currentDate = DateTime.Now;
        string todayDateString = currentDate.ToString("dd.MM.yyyy");

        // Перебираем все дочерние объекты в "Новости (Лента)"
        foreach (Transform postTransform in newsFeed.transform)
        {
            // Проверяем тег объекта
            if (postTransform.CompareTag(postTag))
            {
                // Получаем имя объекта "Пост"
                string postName = postTransform.gameObject.name;

                // Проверяем, содержится ли в имени текущая дата
                if (postName.Contains(todayDateString))
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
    }
}
