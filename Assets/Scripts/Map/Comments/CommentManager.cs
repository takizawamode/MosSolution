using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CommentManager : MonoBehaviour
{
    public GameObject commentPrefab;
    public GameObject[] Comments;
    public TMP_InputField commentInputField;
    public Button sendButton;
    public GameObject Notification;

    private VerticalLayoutGroup activeContent; // Активный Content

    public void SendComment()
    {

        foreach (GameObject comment in Comments)
        {
            if (comment.gameObject.activeSelf)
            {
                activeContent = comment.GetComponentInChildren<VerticalLayoutGroup>();
                break;
            }
        }

        if (string.IsNullOrWhiteSpace(commentInputField.text))
        {
            Notification.SetActive(true);
            return;
        }

        // Создайте новый экземпляр префаба
        GameObject newComment = Instantiate(commentPrefab, activeContent.transform);

        TextMeshProUGUI commentText = newComment.transform.Find("CommentText").GetComponent<TextMeshProUGUI>();
        if (commentText != null)
        {
            // Используйте текст из Input поля в качестве описания
            commentText.text = commentInputField.text;
        }

        commentInputField.text = "";
        newComment.transform.SetAsFirstSibling();

        // Проверяем, есть ли комментарии в данный момент
        UpdateNoCommentsText();
    }

    private void UpdateNoCommentsText()
    {
        bool hasComments = activeContent.transform.childCount > 0;

        GameObject noCommentsObject = activeContent.transform.Find("Комментариев пока что нет").gameObject;

        if (noCommentsObject != null)
        {
            // Скрываем или отображаем объект в зависимости от наличия комментариев
            noCommentsObject.SetActive(!hasComments);
        }
    }
}
