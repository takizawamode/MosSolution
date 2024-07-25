using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Добавленные using.
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class SearchContentResize : MonoBehaviour
{
    // Вывод полей для выбора scrollRect, content, layoutGroup.
    private ScrollRect scrollRect;
    private RectTransform content;
    private VerticalLayoutGroup layoutGroup;

    // Метод на получение компонентов объектов scrollRect, content, layoutGroup.
    private void Awake()
    {
        scrollRect = GetComponent<ScrollRect>();
        content = scrollRect.content;
        layoutGroup = content.GetComponent<VerticalLayoutGroup>();
    }

    // Метод на изменение высоты content с учетом видимых кнопок в layoutGroup.
    private void Update()
    {
        // Количество видимых дочерних объектов.
        int visibleChildCount = 0;

        // Высота контента.
        float contentHeight = 0f;

        // Высота VerticalLayoutGroup с учетом отступов.
        float layoutGroupHeight = layoutGroup.padding.top + layoutGroup.padding.bottom;


        for (int i = 0; i < content.childCount; i++)
        {
            // Получаем RectTransform текущего дочернего объекта.
            RectTransform childRectTransform = content.GetChild(i).GetComponent<RectTransform>();

            // Если дочерний объект активен и видим.
            if (childRectTransform.gameObject.activeSelf)
            {
                // Увеличиваем счетчик видимых дочерних объектов.
                visibleChildCount++;
                // Добавляем высоту дочернего объекта и расстояние между ним и следующим к общей высоте контента.
                contentHeight += childRectTransform.rect.height + layoutGroup.spacing;
            }
        }

        // Если есть хотя бы один видимый дочерний объект.
        if (visibleChildCount > 0)
        {
            // Вычитаем расстояние между последним видимым дочерним объектом и следующим к общей высоте контента.
            contentHeight -= layoutGroup.spacing;
            // Добавляем расстояние между всеми видимыми дочерними объектами к высоте VerticalLayoutGroup.
            layoutGroupHeight += (visibleChildCount - 1) * layoutGroup.spacing;

            // Устанавливаем новое значение sizeDelta для контента с учетом вычисленных высот.
            content.sizeDelta = new Vector2(content.sizeDelta.x, contentHeight + layoutGroupHeight);
        }
    }
}
