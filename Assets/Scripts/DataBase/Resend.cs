using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System;

public class Resend : MonoBehaviour
{
    private string smtpHost = "smtp.gmail.com";
    private int smtpPort = 587;
    private string senderEmail = "mosvozmojnosti@gmail.com";
    private string senderPassword = "pirjxebdqsdwhihe";

    private string ReadEmailFromRegFile()
    {
        string email = "";
        string filePath = Path.Combine(Application.persistentDataPath, "reg.txt"); ;
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                if (line.StartsWith("Email="))
                {
                    email = line.Substring(6);
                    break;
                }
            }
        }
        return email;
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

    public bool SendEmail(string toEmail, string code)
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
        catch (SmtpException e)
        {
            Debug.Log(e.Message);
            return false;
        }
    }

    private void UpdateCodeInRegFile(string email, string code)
    {
        string filePath = Path.Combine(Application.dataPath, "reg.txt");
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("Code="))
                {
                    lines[i] = "Code=" + code;
                    break;
                }
            }
            File.WriteAllLines(filePath, lines);
        }
    }

    public void ResendCode()
    {
        // Путь к файлу reg.txt в папке Assets
        string path = Application.dataPath + "/reg.txt";
        // Считываем все строки файла
        string[] lines = File.ReadAllLines(path);
        // Поиск строки Email и извлечение значения
        string email = null;
        foreach (string line in lines)
        {
            if (line.StartsWith("Email:"))
            {
                email = line.Substring("Email:".Length).Trim();
                break;
            }
        }
        // Если email не найден, выводим сообщение об ошибке и выходим
        if (string.IsNullOrEmpty(email))
        {
            Debug.Log("Email not found in reg file");
            return;
        }
        // Генерируем код и отправляем его на email
        string code = GenerateCode();
        bool sent = SendEmail(email, code);
        // Если отправка прошла успешно, обновляем значение кода в файле
        if (sent)
        {
            // Поиск строки Code и замена значения
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("Code:"))
                {
                    lines[i] = "Code: " + code;
                    break;
                }
            }
            // Записываем изменения в файл
            File.WriteAllLines(path, lines);
            Debug.Log("Код успешно отправлен на email " + email);
        }
        else
        {
            Debug.Log("Не удалось отправить код на email " + email);
        }
    }

}
