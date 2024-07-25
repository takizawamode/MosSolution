using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class PasswordRecovery2 : MonoBehaviour
{
    public SceneChanger sceneChanger;
    public TMP_InputField codeInput;
    public TMP_Text errorText;
    public GameObject box;
    private string regFile;

    private void Start()
    {
        regFile = Path.Combine(Application.persistentDataPath, "reg.txt");
        // Читаем данные из файла и сохраняем код
        if (File.Exists(regFile))
        {
            string regData = File.ReadAllText(regFile);

            string[] lines = regData.Split('\n');
            foreach (string line in lines)
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2)
                {
                    if (parts[0].Trim() == "Code")
                    {
                        PlayerPrefs.SetString("recoveryCode", parts[1].Trim());
                        break;
                    }
                }
            }
        }
        else
        {
            Debug.LogError("Файл " + regFile + " не найден!");
        }
    }

    public void ContinueButtonClicked()
    {
        string inputCode = codeInput.text;
        errorText.text = "";

        string recoveryCode = PlayerPrefs.GetString("recoveryCode");
        if (string.IsNullOrEmpty(recoveryCode))
        {
            box.SetActive(true);
            errorText.text = "Код восстановления не найден. Попробуйте получить его еще раз.";
            return;
        }

        if (inputCode != recoveryCode)
        {
            box.SetActive(true);
            errorText.text = "Неверный код восстановления пароля";
        }
        else
        {
            // Удаляем код из файла
            if (File.Exists(regFile))
            {
                string regData = File.ReadAllText(regFile);
                regData = regData.Replace("Code:" + recoveryCode, "");
                File.WriteAllText(regFile, regData);
            }

            PlayerPrefs.DeleteKey("recoveryCode");

            sceneChanger.LoadScene(4);
        }
    }
}