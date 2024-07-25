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

    private VerticalLayoutGroup activeContent; // �������� Content

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

        // �������� ����� ��������� �������
        GameObject newComment = Instantiate(commentPrefab, activeContent.transform);

        TextMeshProUGUI commentText = newComment.transform.Find("CommentText").GetComponent<TextMeshProUGUI>();
        if (commentText != null)
        {
            // ����������� ����� �� Input ���� � �������� ��������
            commentText.text = commentInputField.text;
        }

        commentInputField.text = "";
        newComment.transform.SetAsFirstSibling();

        // ���������, ���� �� ����������� � ������ ������
        UpdateNoCommentsText();
    }

    private void UpdateNoCommentsText()
    {
        bool hasComments = activeContent.transform.childCount > 0;

        GameObject noCommentsObject = activeContent.transform.Find("������������ ���� ��� ���").gameObject;

        if (noCommentsObject != null)
        {
            // �������� ��� ���������� ������ � ����������� �� ������� ������������
            noCommentsObject.SetActive(!hasComments);
        }
    }
}
