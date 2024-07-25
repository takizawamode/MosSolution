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
        // ������ ������ �� ����� � ��������� ���
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
            Debug.LogError("���� " + regFile + " �� ������!");
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
            errorText.text = "��� �������������� �� ������. ���������� �������� ��� ��� ���.";
            return;
        }

        if (inputCode != recoveryCode)
        {
            box.SetActive(true);
            errorText.text = "�������� ��� �������������� ������";
        }
        else
        {
            // ������� ��� �� �����
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