using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiteLink : MonoBehaviour
{
    // Вывод поля для вставки link.
    public string link;

    // Метод для открытия сайта link.
    public void OpenLink()
    {
        Application.OpenURL(link);
    }
}
