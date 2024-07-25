using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.IO;
using System;
using TMPro;

public class Registration : MonoBehaviour
{
    public SceneChanger sceneChanger;
    public TMP_InputField firstNameInputField;
    public TMP_InputField lastNameInputField;
    public TMP_InputField emailInputField;
    public TMP_InputField passwordInputField;
    public TMP_Text errorMessageText;
    public GameObject Box;

    private string dataPath;

    private void Start()
    {
        dataPath = Path.Combine(Application.persistentDataPath, "reg.txt");
        if (!File.Exists(dataPath))
        {
            File.Create(dataPath).Close();
        }
    }

    public void OnClick()
    {
        errorMessageText.text = "";
        if (IsAllInputFieldsFilled())
        {
            Regex emailRegex = new Regex(@"^[-A-Za-z0-9!+?_]+(?:\.[-A-Za-z0-9!+?_~]+)*@(?:[a-z0-9]([-a-z0-9]{0,61}[a-z0-9])?\.)*(?:aero|arpa|asia|biz|cat|com|coop|edu|gov|info|int|jobs|mil|mobi|museum|name|net|org|pro|tel|travel|[a-z][a-z])$");
            Regex nameRegex = new Regex(@"^[а-яА-Я]+$");
            Regex passwordRegex = new Regex(@"^[a-zA-Z0-9_]+$");
            if (!emailRegex.IsMatch(emailInputField.text))
            {
                Box.SetActive(true);
                errorMessageText.text = "Введите корректный email";
            }
            else if (!nameRegex.IsMatch(firstNameInputField.text))
            {
                Box.SetActive(true);
                errorMessageText.text = "Введите Имя на русском языке";
            }
            else if (!nameRegex.IsMatch(lastNameInputField.text))
            {
                Box.SetActive(true);
                errorMessageText.text = "Введите Фамилию на русском языке";
            }
            else if (!passwordRegex.IsMatch(passwordInputField.text))
            {
                Box.SetActive(true);
                errorMessageText.text = "Пароль может содержать только латиницу, цифры и подчеркивание";
            }
            else
            {
                string[] fileContent = File.ReadAllLines(dataPath);
                bool userExists = false;
                string emailPattern = @"Email\s*:\s*(?<email>[^\n]+)";
                string passwordPattern = @"Password\s*:\s*(?<password>[^\n]+)";
                string content = string.Join("\n", fileContent);

                Match emailMatch = Regex.Match(content, emailPattern);
                Match passwordMatch = Regex.Match(content, passwordPattern);

                if (emailMatch.Success && passwordMatch.Success && emailMatch.Groups["email"].Value.Trim() == emailInputField.text.Trim() && passwordMatch.Groups["password"].Value.Trim() == passwordInputField.text.Trim())
                {
                    userExists = true;
                }

                if (userExists)
                {
                    Box.SetActive(true);
                    errorMessageText.text = "Пользователь с таким email уже существует";
                }
                else
                {
                    if (string.IsNullOrEmpty(firstNameInputField.text) || string.IsNullOrEmpty(lastNameInputField.text) ||
                        string.IsNullOrEmpty(emailInputField.text) || string.IsNullOrEmpty(passwordInputField.text))
                    {
                        Box.SetActive(true);
                        errorMessageText.text = "Пожалуйста, заполните все поля";
                    }
                    else
                    {
                        string firstName = firstNameInputField.text;
                        string lastName = lastNameInputField.text;
                        string email = emailInputField.text;
                        string password = passwordInputField.text;
                        string[] newData = new string[] { "First name: " + firstName, "Last name: " + lastName, "Email: " + email, "Password: " + password };
                        File.AppendAllLines(dataPath, newData);
                        Debug.Log("Data saved to file!");
                        sceneChanger.LoadScene(0);
                    }
                }
            }
        }
    }

    public TMP_InputField[] Fields;
    private bool IsAllInputFieldsFilled()
    {
        foreach (TMP_InputField field in Fields)
        {
            if (field.text.Trim() == "")
            {
                return false;
            }
        }
        return true;

    }
}