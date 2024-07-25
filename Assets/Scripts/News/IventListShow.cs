using UnityEngine;
using TMPro;

public class IventListShow : MonoBehaviour
{
    public GameObject ivents;
    public GameObject news;

    public GameObject IventsButton;
    public GameObject NewsButton;

    public TMP_Text label;

    public void OnIventBtnClick()
    {
        news.SetActive(false);

        ivents.SetActive(true);
        label.text = "�����������";
    }

    void Update()
    {
        if (label.text.Contains("�����������"))
        {
            IventsButton.SetActive(false);
            NewsButton.SetActive(true);
        }
    }
}
