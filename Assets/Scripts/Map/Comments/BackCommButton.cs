using UnityEngine;

public class BackCommButton : MonoBehaviour
{
    
    public GameObject commentsWinow;

    public void CloseComments()
    {
        commentsWinow.SetActive(false);
    }
}
