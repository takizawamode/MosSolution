using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class AuthorizationScript : MonoBehaviour
{
    public SceneChanger sceneChanger;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_Text errorText;
    public GameObject Box;

    public static class UserHolder
    {
        public static string email;
    }

    public void OnContinueButtonClicked()
    {
        string Email = emailInput.text;
        string password = passwordInput.text;

        string filePath = Path.Combine(Application.persistentDataPath, "reg.txt");
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("Email:") && lines[i].Substring(6).Trim() == Email)
                {
                    if (i + 1 < lines.Length && lines[i + 1].StartsWith("Password:") && lines[i + 1].Substring(9).Trim() == password)
                    {
                        UserHolder.email = Email;
                        sceneChanger.LoadScene(5);
                        return;
                    }
                }
            }
        }
        Box.SetActive(true);
        errorText.text = "Пользователь не найден";
    }
}
