using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class PasswordCreate : MonoBehaviour
{
    public TMP_InputField passwordInput;
    public TMP_InputField confirmPasswordInput;
    public TMP_Text errorText;
    public GameObject Box;
    public SceneChanger sceneChanger;

    private string email;
    private string regFilePath;

    private void Start()
    {
        regFilePath = Path.Combine(Application.persistentDataPath, "reg.txt");
        email = DataTransfer.email;
    }

    public void OnContinueButtonClick()
    {
        string password = passwordInput.text;
        string confirmPassword = confirmPasswordInput.text;

        // ���������, ��� ������ ���������
        if (password != confirmPassword)
        {
            Box.SetActive(true);
            errorText.text = "������ �� ���������";
            return;
        }

        // ���������, ��� ������ ������������� ��������� �������
        string pattern = @"^[a-zA-Z0-9_]+$";
        if (!System.Text.RegularExpressions.Regex.IsMatch(password, pattern))
        {
            Box.SetActive(true);
            errorText.text = "������ ����� ��������� ������ ��������, ����� � �������������";
            return;
        }

        string[] regData = File.ReadAllLines(regFilePath);
        for (int i = 0; i < regData.Length; i++)
        {
            string[] parts = regData[i].Split(':');
            if (parts.Length == 2 && parts[0].Trim() == "Password")
            {
                regData[i] = $"Password: {password}";
                File.WriteAllLines(regFilePath, regData);

                // ������� ������ "Code: < >", ���� ��� ����������
                for (int j = 0; j < regData.Length; j++)
                {
                    string[] codeParts = regData[j].Split(':');
                    if (codeParts.Length == 2 && codeParts[0].Trim() == "Code")
                    {
                        regData[j] = "";
                        File.WriteAllLines(regFilePath, regData);
                        break;
                    }
                }

                sceneChanger.LoadScene(5);
                Debug.Log("������ ������� ��������");
                return;
            }
        }

        Box.SetActive(true);
        errorText.text = "�� ������� �������� ������";
    }
}
