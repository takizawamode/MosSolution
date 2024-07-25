using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;
using TMPro;

public class Profile : MonoBehaviour
{
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

    private string connectionString;
    private IDbConnection dbConnection;
    private IDbCommand dbCommand;

    void Start()
    {
        string connectionString = "URI=file:" + Application.dataPath + "/MV.db;Pooling=true;Max Pool Size=100;Min Pool Size=1;Connect Timeout=2000;";
        dbConnection = new SqliteConnection(connectionString);
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();

        // Retrieve the user email from DataTransfer
        string userEmail = DataTransfer.email;

        if (!string.IsNullOrEmpty(userEmail))
        {
            // Retrieve the user data for the email from Profile table
            dbCommand.CommandText = "SELECT Last_name, First_name, Patronymic, Email, Phone, Address, Details, Number_and_series, Department_code, Issued_by_whom, Place_of_birth, Policy, SNILS FROM Profile WHERE Email = @Email";
            IDbDataParameter emailParameter = dbCommand.CreateParameter();
            emailParameter.ParameterName = "@Email";
            emailParameter.Value = userEmail;
            dbCommand.Parameters.Add(emailParameter);
            IDataReader reader = dbCommand.ExecuteReader();

            if (reader.Read())
            {
                if (!reader.IsDBNull(reader.GetOrdinal("Last_name")))
                    lastNameInput.text = reader.GetString(reader.GetOrdinal("Last_name"));
                if (!reader.IsDBNull(reader.GetOrdinal("First_name")))
                    firstNameInput.text = reader.GetString(reader.GetOrdinal("First_name"));
                if (!reader.IsDBNull(reader.GetOrdinal("Patronymic")))
                    patronymicInput.text = reader.GetString(reader.GetOrdinal("Patronymic"));
                if (!reader.IsDBNull(reader.GetOrdinal("Phone")))
                    phoneInput.text = reader.GetString(reader.GetOrdinal("Phone"));
                if (!reader.IsDBNull(reader.GetOrdinal("Address")))
                    addressInput.text = reader.GetString(reader.GetOrdinal("Address"));
                if (!reader.IsDBNull(reader.GetOrdinal("Details")))
                    detailsInput.text = reader.GetString(reader.GetOrdinal("Details"));
                if (!reader.IsDBNull(reader.GetOrdinal("Number_and_series")))
                    numberAndSeriesInput.text = reader.GetString(reader.GetOrdinal("Number_and_series"));
                if (!reader.IsDBNull(reader.GetOrdinal("Department_code")))
                    departmentCodeInput.text = reader.GetString(reader.GetOrdinal("Department_code"));
                if (!reader.IsDBNull(reader.GetOrdinal("Issued_by_whom")))
                    issuedByWhomInput.text = reader.GetString(reader.GetOrdinal("Issued_by_whom"));
                if (!reader.IsDBNull(reader.GetOrdinal("Place_of_birth")))
                    placeOfBirthInput.text = reader.GetString(reader.GetOrdinal("Place_of_birth"));
                if (!reader.IsDBNull(reader.GetOrdinal("Policy")))
                    policyInput.text = reader.GetString(reader.GetOrdinal("Policy"));
                if (!reader.IsDBNull(reader.GetOrdinal("SNILS")))
                    snilsInput.text = reader.GetString(reader.GetOrdinal("SNILS"));
                if (!reader.IsDBNull(reader.GetOrdinal("Email")))
                    emailInput.text = reader.GetString(reader.GetOrdinal("Email"));
            }
            reader.Close();
        }
    }// Set up a function to update the user's profile information in the database
    public void UpdateProfile()
    {
        // Retrieve the user email from DataTransfer
        string userEmail = DataTransfer.email;
        if (!string.IsNullOrEmpty(userEmail))
        {
            dbCommand.CommandText = "UPDATE Profile SET Last_name = @Last_name, First_name = @First_name, Patronymic = @Patronymic, Phone = @Phone, Address = @Address, Details = @Details, Number_and_series = @Number_and_series, Department_code = @Department_code, Issued_by_whom = @Issued_by_whom, Place_of_birth = @Place_of_birth, Policy = @Policy, SNILS = @SNILS WHERE Email = @Email";
            IDbDataParameter emailParameter = dbCommand.CreateParameter();
            emailParameter.ParameterName = "@Email";
            emailParameter.Value = userEmail;
            dbCommand.Parameters.Add(emailParameter);
            IDbDataParameter lastNameParameter = dbCommand.CreateParameter();
            lastNameParameter.ParameterName = "@Last_name";
            lastNameParameter.Value = lastNameInput.text;
            dbCommand.Parameters.Add(lastNameParameter);
            IDbDataParameter firstNameParameter = dbCommand.CreateParameter();
            firstNameParameter.ParameterName = "@First_name";
            firstNameParameter.Value = firstNameInput.text;
            dbCommand.Parameters.Add(firstNameParameter);
            IDbDataParameter patronymicParameter = dbCommand.CreateParameter();
            patronymicParameter.ParameterName = "@Patronymic";
            patronymicParameter.Value = patronymicInput.text;
            dbCommand.Parameters.Add(patronymicParameter);
            IDbDataParameter phoneParameter = dbCommand.CreateParameter();
            phoneParameter.ParameterName = "@Phone";
            phoneParameter.Value = phoneInput.text;
            dbCommand.Parameters.Add(phoneParameter);
            IDbDataParameter addressParameter = dbCommand.CreateParameter();
            addressParameter.ParameterName = "@Address";
            addressParameter.Value = addressInput.text;
            dbCommand.Parameters.Add(addressParameter);
            IDbDataParameter detailsParameter = dbCommand.CreateParameter();
            detailsParameter.ParameterName = "@Details";
            detailsParameter.Value = detailsInput.text;
            dbCommand.Parameters.Add(detailsParameter);
            IDbDataParameter numberAndSeriesParameter = dbCommand.CreateParameter();
            numberAndSeriesParameter.ParameterName = "@Number_and_series";
            numberAndSeriesParameter.Value = numberAndSeriesInput.text;
            dbCommand.Parameters.Add(numberAndSeriesParameter);
            IDbDataParameter departmentCodeParameter = dbCommand.CreateParameter();
            departmentCodeParameter.ParameterName = "@Department_code";
            departmentCodeParameter.Value = departmentCodeInput.text;
            dbCommand.Parameters.Add(departmentCodeParameter);
            IDbDataParameter issuedByWhomParameter = dbCommand.CreateParameter();
            issuedByWhomParameter.ParameterName = "@Issued_by_whom";
            issuedByWhomParameter.Value = issuedByWhomInput.text;
            dbCommand.Parameters.Add(issuedByWhomParameter);
            IDbDataParameter placeOfBirthParameter = dbCommand.CreateParameter();
            placeOfBirthParameter.ParameterName = "@Place_of_birth";
            placeOfBirthParameter.Value = placeOfBirthInput.text;
            dbCommand.Parameters.Add(placeOfBirthParameter);
            IDbDataParameter policyParameter = dbCommand.CreateParameter();
            policyParameter.ParameterName = "@Policy";
            policyParameter.Value = policyInput.text;
            dbCommand.Parameters.Add(policyParameter);
            IDbDataParameter snilsParameter = dbCommand.CreateParameter();
            snilsParameter.ParameterName = "@SNILS";
            snilsParameter.Value = snilsInput.text;
            dbCommand.Parameters.Add(snilsParameter);

            dbCommand.ExecuteNonQuery();
        }
    }

    // Set up a function to close the database connection
    private void OnDestroy()
    {
        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Close();
        dbConnection = null;
    }
}