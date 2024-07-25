using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDisable : MonoBehaviour
{
    // Вывод поля для объекта Start.
    public GameObject Startobj;

    // При 1 загрузке сцены с задержкой 2 сек. применить метод "DisableObject" (отключить Start).
    void Start()
    {
        Invoke("DisableObject", 2f);
    }

    // Метод на отключение объекта Start.
    private void DisableObject()
    {
        Startobj.SetActive(false);
    }
}
