using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System;
using TMPro;

public class PasswordRecovery : MonoBehaviour
{
    public SceneChanger sceneChanger;
    public TMP_InputField emailInput;
    public TMP_Text errorText;
    public GameObject box;
    private string smtpHost = "smtp.gmail.com";
    private int smtpPort = 587;
    private string senderEmail = "mosvozmojnosti@gmail.com";
    private string senderPassword = "pirjxebdqsdwhihe";
    private string regFilePath;

    private void Start()
    {
        regFilePath = Path.Combine(Application.persistentDataPath, "reg.txt");
    }

    public void SendCode()
    {
        string email = emailInput.text;
        errorText.text = "";

        if (!IsValidEmail(email))
        {
            box.SetActive(true);
            errorText.text = "Введите корректный email";
            return;
        }

        string[] userEmail = FindUserCredentialsByEmail(email);
        if (userEmail == null)
        {
            box.SetActive(true);
            errorText.text = "Указанный Email не зарегистрирован";
            return;
        }

        string code = GenerateCode();
        if (!SendEmail(email, code))
        {
            box.SetActive(true);
            errorText.text = "Не удалось отправить код на email";
            return;
        }

        if (SaveCode(email, code))
        {
            box.SetActive(true);
            errorText.text = "Код отправлен на email";
        }
        else
        {
            box.SetActive(true);
            errorText.text = "Не удалось сохранить код";
            return;
        }

        sceneChanger.LoadScene(3);
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    private string GenerateCode()
    {
        byte[] codeBytes = new byte[2];
        using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(codeBytes);
        }
        int codeInt = BitConverter.ToInt16(codeBytes, 0) % 10000;
        codeInt = Math.Abs(codeInt);
        return codeInt.ToString("D4");
    }

    private bool SendEmail(string toEmail, string code)
    {
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(senderEmail);
        mail.To.Add(new MailAddress(toEmail));
        mail.Subject = "Код для восстановления пароля";
        mail.Body = "Код для восстановления пароля: " + code;

        SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort);
        smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
        smtpClient.EnableSsl = true;

        try
        {
            smtpClient.Send(mail);
            return true;
        }
        catch (Exception ex)
        {
            errorText.text = "Ошибка при отправке email: " + ex.Message;
            return false;
        }

    }

    private bool SaveCode(string email, string code)
    {
        try
        {
            string[] lines = File.ReadAllLines(regFilePath);
            using (StreamWriter writer = new StreamWriter(regFilePath))
            {
                foreach (string line in lines)
                {
                    if (!line.StartsWith("Code"))
                    {
                        writer.WriteLine(line);
                    }
                }
                writer.WriteLine($"Code:{email}:{code}");
            }
            return true;
        }
        catch
        {
            return false;
        }
    }
    private string[] FindUserCredentialsByEmail(string email)
    {
        if (!File.Exists(regFilePath))
        {
            return null;
        }
        string[] lines = File.ReadAllLines(regFilePath);
        foreach (string line in lines)
        {
            if (line.TrimStart().StartsWith("Email:", StringComparison.OrdinalIgnoreCase) && line.Contains(email, StringComparison.OrdinalIgnoreCase))
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2)
                {
                    return new string[] { email, parts[1].Trim() };
                }
            }
        }
        return null;
    }
}