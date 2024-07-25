using UnityEngine;
// Добавленные using.
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Метод загрузки сцены по ID.
    public void LoadScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
