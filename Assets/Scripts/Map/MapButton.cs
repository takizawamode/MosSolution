using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Добавленные using.
using UnityEngine.UI;

public class MapButton : MonoBehaviour
{
    // Вывод поля для выбора кнопки ScrollRect, ScrollRect Map, ScrollRect scrollBar.
    public Button ScrollRect;
    public ScrollRect Map;
    public ScrollRect scrollBar;

    // Вывод массива для выбора объектов toggles, поля для выбора search, cross.
    public GameObject[] toggles;
    public GameObject search;
    public GameObject cross;

    // Вывод массива для выбора объектов Infos.
    public GameObject[] Infos;

    public GameObject showHide;

    // Булевая переменная visible для проверки видимости информации.
    public bool visibile = true;

    // При загрузки сцены добавлен слушатель для метода OnScrollRectClick.
    void Start()
    {
        Map.onValueChanged.AddListener(delegate { OnScrollRectClick(); } );
    }

    // Метод скрытия информации на scrollBar при нажатии на карту (Map).
    public void OnScrollRectClick()
    {
        // Если карта на двигается.
        if (Map.velocity.magnitude == 0)
        {
            // Скрыть объекты (информацию) каждого элемента массива Infos.
            foreach (GameObject info in Infos)
            {
                info.SetActive(false);
            }

            // Показать объекты (выборки) каждого элемента массива toggles.
            foreach (GameObject toggle in toggles)
            {
                toggle.SetActive(true);
            }

            // Показать объекты search, cross.
            search.SetActive(true);
            cross.SetActive(true);

            showHide.SetActive(true);

            // Видимость информации = false.
            visibile = false;

            // Если положение ScrollRect <= 0.8f (сверху), то переместить на 1f (вниз) со скоростью 0.5f.
            if (scrollBar.verticalNormalizedPosition <= 0.8f)
            {
                LeanTween.value(gameObject, scrollBar.verticalNormalizedPosition, 1f, 0.5f)
                .setEaseInOutSine()
                .setOnUpdate((float val) => { scrollBar.verticalNormalizedPosition = val; });
            }
        }
        // Если информацию не видно (false) И карта двигается - не показывать кнопки выборки и поиск.
        else if (visibile = false && Map.velocity.magnitude != 0)
        {
            foreach (GameObject toggle in toggles)
            {
                toggle.SetActive(false);
            }
            search.SetActive(false);
            cross.SetActive(false);
        }
    }
}
