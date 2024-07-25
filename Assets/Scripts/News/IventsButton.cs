using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IventsButton : MonoBehaviour
{
    public GameObject Ivents;
    public GameObject News;
    public GameObject Calendar;
    public Button ScrollRect;
    public ScrollRect Rect;
    public TMP_Text label;

    public bool visibile = true;
    void Start()
    {
        Rect.onValueChanged.AddListener(delegate { OnScrollRectClick(); });
    }

    public void ButtonArrowCkick()
    {
        if (label.text.Contains("Новости"))
        {
            Ivents.SetActive(true);
        }    
        else if (label.text.Contains("Мероприятия"))
        {
            News.SetActive(true);
        }

    }

    public void ButtonCalendarClick()
    {
        Calendar.SetActive(true);
    }

    public void OnScrollRectClick()
    {
        if (Rect.velocity.magnitude == 0)
        {
            Ivents.SetActive(false);
            News.SetActive(false);
            Calendar.SetActive(false);
        }
    }
}
