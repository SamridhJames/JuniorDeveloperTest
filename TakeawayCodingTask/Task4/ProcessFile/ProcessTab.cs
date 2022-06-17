using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using TakeawayCodingTask.Task4.Interface;

namespace TakeawayCodingTask.Task4.ProcessFile
{
    public class ProcessTab : IProcessFile
    {
        public void ConvertFileDataToJson(string inputFilePath, string outputFilePath)
        {
            var regexDict = HelperMethods.RegexDict();
            var customerDataTable = new DataTable();
            var reader = new StreamReader(inputFilePath);
            var columnNames = reader.ReadLine()?.Split('\t');
            var allCustomerRecords = new List<Task_04.Customer>();

            foreach (var columnName in columnNames)
            {
                customerDataTable.Columns.Add(columnName);
            }

            while (reader.Peek() > 0)
            {
                var dataRow = customerDataTable.NewRow();
                dataRow.ItemArray = reader.ReadLine().Split('\t');
                customerDataTable.Rows.Add(dataRow);
            }
            
            foreach (DataRow row in customerDataTable.Rows)
            {
                var customerObj = new Task_04.Customer();
                foreach (DataColumn column in customerDataTable.Columns)
                {
                    var nameRegex = new Regex(regexDict["Name"]);
                    var addressRegex = new Regex(regexDict["Address"]);
                    var emailAddressRegex = new Regex(regexDict["EmailAddress"]);
                    var phoneNumberRegex = new Regex(regexDict["PhoneNumber"]);
                    var postCodeRegex = new Regex(regexDict["PostCode"]);
                    switch (column.ColumnName)
                    {
                        case "Name" when nameRegex.IsMatch(row[column].ToString()):
                            customerObj.Name = row[column].ToString();
                            break;
                        case "Address" when addressRegex.IsMatch(row[column].ToString()):
                            customerObj.Address = row[column].ToString();
                            break;
                        case "EMail" when emailAddressRegex.IsMatch(row[column].ToString()):
                            customerObj.EmailAddress = row[column].ToString();
                            break;
                        case "Phone" when phoneNumberRegex.IsMatch(row[column].ToString()):
                            customerObj.PhoneNumber = row[column].ToString();
                            break;
                        case "PostCode" when postCodeRegex.IsMatch(row[column].ToString()):
                            customerObj.PostCode = row[column].ToString();
                            break;
                    }
                }
                allCustomerRecords.Add(customerObj);
            }

            var jsonString = JsonConvert.SerializeObject(new
            {
                customerData = allCustomerRecords
            });

            File.WriteAllText(outputFilePath + inputFilePath.Split('\\').Last().Split('.').First() + ".json", jsonString);
        }
    }
}
