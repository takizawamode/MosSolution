using UnityEngine;

public class OpenComments : MonoBehaviour
{
    public GameObject commentsWindow;
    public GameObject comment;
    public GameObject[] otherComments;
    
    public void openComments()
    {
        commentsWindow.SetActive(true);

        foreach (GameObject comment in otherComments)
        {
            comment.SetActive(false);
        }

        comment.SetActive(true);
    }
}
