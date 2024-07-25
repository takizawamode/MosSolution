using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveDataScript : MonoBehaviour
{
    public SceneChanger sceneChanger;
    // Три кнопки: Редактировать, Сохранить и Изменить пароль
    public Button editButton;
    public Button saveButton;
    public Button changePasswordButton;
    // Все поля, которые нужно сохранять
    public TMP_InputField firstNameInput;
    public TMP_InputField lastNameInput;
    public TMP_InputField emailInput;
    public TMP_InputField patronymicInput;
    public TMP_InputField phoneInput;
    public TMP_InputField addressInput;
    public TMP_InputField detailsInput;
    public TMP_InputField numberAndSeriesInput;
    public TMP_InputField departmentCodeInput;
    public TMP_InputField issuedByWhomInput;
    public TMP_InputField placeOfBirthInput;
    public TMP_InputField policyInput;
    public TMP_InputField snilsInput;

    private string filePath;

    void Start()
    {

        filePath = Path.Combine(Application.persistentDataPath, "reg.txt");

        // Считываем данные из файла reg.txt
        ReadDataFromFile();

        // Прикрепляем методы к нажатиям на кнопки
        editButton.onClick.AddListener(OnEditButtonClick);
        saveButton.onClick.AddListener(SaveDataToFile);
        changePasswordButton.onClick.AddListener(OnChangePasswordButtonClick);

        // Скрываем кнопку Редактировать, так как пользователь еще не начал редактирование
        editButton.gameObject.SetActive(true);

        changePasswordButton.gameObject.SetActive(false);
        changePasswordButton.interactable = false;
        // Скрываем кнопку Сохранить, так как пользователь еще не начал редактирование
        saveButton.gameObject.SetActive(false);
    }

    // Считывает данные из файла reg.txt и заполняет соответствующие TMP поля
    void ReadDataFromFile()
    {
        if (File.Exists(filePath))
        {
            // Читаем все строки из файла reg.txt
            string[] lines = File.ReadAllLines(filePath);

            // Ищем нужные строки и заполняем поля
            foreach (string line in lines)
            {
                if (line.StartsWith("First name: ") && line.Length > 12)
                {
                    firstNameInput.text = line.Substring(12);
                }
                else if (line.StartsWith("Last name: ") && line.Length > 11)
                {
                    lastNameInput.text = line.Substring(11);
                }
                else if (line.StartsWith("Email: ") && line.Length > 7)
                {
                    emailInput.text = line.Substring(7);
                }
                else if (line.StartsWith("Patronymic: ") && line.Length > 12)
                {
                    patronymicInput.text = line.Substring(12);
                }
                else if (line.StartsWith("Phone: ") && line.Length > 6)
                {
                    phoneInput.text = line.Substring(6);
                }
                else if (line.StartsWith("Address: ") && line.Length > 8)
                {
                    addressInput.text = line.Substring(8);
                }
                else if (line.StartsWith("Details: ") && line.Length > 8)
                {
                    detailsInput.text = line.Substring(8);
                }
                else if (line.StartsWith("Number and series: ") && line.Length > 19)
                {
                    numberAndSeriesInput.text = line.Substring(19);
                }
                else if (line.StartsWith("Department code: ") && line.Length > 17)
                {
                    departmentCodeInput.text = line.Substring(17);
                }
                else if (line.StartsWith("Issued by whom: ") && line.Length > 16)
                {
                    issuedByWhomInput.text = line.Substring(16);
                }
                else if (line.StartsWith("Place of birth: ") && line.Length > 16)
                {
                    placeOfBirthInput.text = line.Substring(16);
                }
                else if (line.StartsWith("Policy: ") && line.Length > 8)
                {
                    policyInput.text = line.Substring(8);
                }
                else if (line.StartsWith("SNILS: ") && line.Length > 7)
                {
                    snilsInput.text = line.Substring(7);
                }
            }
        }
    }


    // Обработчик нажатия на кнопку Редактировать
    void OnEditButtonClick()
    {
        // Показываем кнопку Сохранить и скрываем кнопку Редактировать
        saveButton.gameObject.SetActive(true);
        editButton.gameObject.SetActive(false);
        //changePasswordButton.gameObject.SetActive(true);
        // Разрешаем редактирование всех полей
        firstNameInput.interactable = true;
        lastNameInput.interactable = true;
        emailInput.interactable = true;
        patronymicInput.interactable = true;
        phoneInput.interactable = true;
        addressInput.interactable = true;
        detailsInput.interactable = true;
        numberAndSeriesInput.interactable = true;
        departmentCodeInput.interactable = true;
        issuedByWhomInput.interactable = true;
        placeOfBirthInput.interactable = true;
        policyInput.interactable = true;
        snilsInput.interactable = true;
    }

    // Обработчик нажатия на кнопку Сохранить
    void SaveDataToFile()
    {
        // Скрываем кнопку Сохранить и показываем кнопку Редактировать
        saveButton.gameObject.SetActive(false);
        editButton.gameObject.SetActive(true);
        // Запрещаем редактирование всех полей
        firstNameInput.interactable = false;
        lastNameInput.interactable = false;
        emailInput.interactable = false;
        patronymicInput.interactable = false;
        phoneInput.interactable = false;
        addressInput.interactable = false;
        detailsInput.interactable = false;
        numberAndSeriesInput.interactable = false;
        departmentCodeInput.interactable = false;
        issuedByWhomInput.interactable = false;
        placeOfBirthInput.interactable = false;
        policyInput.interactable = false;
        snilsInput.interactable = false;

        // Открываем файл для чтения и поиска строки Password
        string password = null;
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("Password: "))
                {
                    password = line;
                    break;
                }
            }
        }

        // Открываем файл для записи и перезаписываем его, вставляя сохраненную строку Password
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("First name: " + firstNameInput.text);
            writer.WriteLine("Last name: " + lastNameInput.text);
            writer.WriteLine("Email: " + emailInput.text);
            writer.WriteLine(password); // переставлено в четвертое место
            writer.WriteLine("Patronymic: " + patronymicInput.text);
            writer.WriteLine("Phone: " + phoneInput.text);
            writer.WriteLine("Address: " + addressInput.text);
            writer.WriteLine("Details: " + detailsInput.text);
            writer.WriteLine("Number and series: " + numberAndSeriesInput.text);
            writer.WriteLine("Department code: " + departmentCodeInput.text);
            writer.WriteLine("Issued by whom: " + issuedByWhomInput.text);
            writer.WriteLine("Place of birth: " + placeOfBirthInput.text);
            writer.WriteLine("Policy: " + policyInput.text);
            writer.WriteLine("SNILS: " + snilsInput.text);

            // Сообщаем пользователю, что данные успешно сохранены
            Debug.Log("Данные успешно сохранены!");
        }
    }


    // Обработчик нажатия на кнопку Изменить пароль
    void OnChangePasswordButtonClick()
    {
        sceneChanger.LoadScene(2);
    }
}
