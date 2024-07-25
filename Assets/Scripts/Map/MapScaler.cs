using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Добавленные using.
using UnityEngine.UI;

public class MapScaler : MonoBehaviour
{
    // Вывод поля для кнопок Plus и Minus.
    public Button plusButton;
    public Button minusButton;

    // Вывод поля для массива для объектов Map0, Map1, Map2, Map3.
    public GameObject[] Maps;

    // Вывод поля для объекта трансформации размера Content.
    public RectTransform Content;

    // Проаверка активация и деактивация кнопок Plus и Minus ежесекундно.
    void Update()
    {
        // При самой большой масштабируемости (если объект Map3 активен) деактивация кнопки Plus.
        if (Maps[3].active == true)
        {
            plusButton.interactable = false;
        }
        // Активация кнопки Plus в остальных вариантах масштабируемости.
        else
            plusButton.interactable = true;

        // При самой маленькой масштабируемости (если объект Map0 активен) деактивация кнопки Minus.
        if (Maps[0].active == true)
        {
            minusButton.interactable = false;
        }
        // Активация кнопки Minus в остальных вариантах масштабируемости.
        else
            minusButton.interactable = true;
    }

    // Метод увиличения масштаба карты при нажатии на кнопку Plus.
    public void PlusClick()
    {
        // Цикл, который проверяет активность каждого объекта из массива Maps.
        for (int i = 0; i < Maps.Length; i++)
        {
            if (Maps[i].active == true)
            {
                // Отключение актуального объекта Map и включение следующего объекта Map из массива.
                Maps[i].SetActive(false);
                Maps[i + 1].SetActive(true);

                // Прерывание цикла (т.е. цикл проходится пошагово).
                break;
            }
        }

        // Вызов метода изменения границ карты.
        MapBorderResize();
    }

    // Метод уменьшения масштаба карты при нажатии на кнопку Minus.
    public void MinusClick()
    {
        // Цикл, который проверяет активность каждого объекта из массива Maps c последнего элемента.
        for (int i = 3; i < Maps.Length; i--)
        {
            if (Maps[i].active == true)
            {
                // Отключение актуального объекта Map и включение предыдущего объекта Map из массива.
                Maps[i].SetActive(false);
                Maps[i - 1].SetActive(true);

                // Прерывание цикла (т.е. цикл проходится пошагово).
                break;
            }
        }

        // Вызов метода изменения границ карты.
        MapBorderResize();
    }

    // Метод изменения размера границ Content (карты).
    public void MapBorderResize()
    {
        // Если объект Map0 включен - изменение размера Width и Height для Content и т.д.
        if (Maps[0].active == true)
        {
            Content.sizeDelta = new Vector2(699.66f, 1297.68f);
        }
        if (Maps[1].active == true)
        {
            Content.sizeDelta = new Vector2(1140.63f, 1583.34f);
        }
        if (Maps[2].active == true)
        {
            Content.sizeDelta = new Vector2(2330.08f, 2980.9f);
        }
        if (Maps[3].active == true)
        {
            Content.sizeDelta = new Vector2(3970.7f, 5177.68f);
        }
    }
}
