using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewsListShow : MonoBehaviour
{
    public GameObject ivents;
    public GameObject news;

    public GameObject IventsButton;
    public GameObject NewsButton;

    public TMP_Text label;

    public void OnNewsBtnClick()
    {
        news.SetActive(true);

        ivents.SetActive(false);
        label.text = "Новости";
    }

    void Update()
    {
        if (label.text.Contains("Новости"))
        {
            IventsButton.SetActive(true);
            NewsButton.SetActive(false);
        }
    }
}
