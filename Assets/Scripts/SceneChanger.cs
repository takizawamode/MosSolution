using UnityEngine;
// ����������� using.
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // ����� �������� ����� �� ID.
    public void LoadScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
