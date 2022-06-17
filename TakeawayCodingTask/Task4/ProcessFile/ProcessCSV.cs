using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using TakeawayCodingTask.Task4.Interface;
using Newtonsoft.Json;

namespace TakeawayCodingTask.Task4.ProcessFile
{
    public class ProcessCsv: IProcessFile
    {
        public void ConvertFileDataToJson(string inputFilePath, string outputFilePath)
        {
            var regexDict = HelperMethods.RegexDict();
            var data = File.ReadAllLines(inputFilePath)
                .Select(line => Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))")).ToArray();
            var allCustomerRecords = new List<Task_04.Customer>();

            foreach (var record in data)
            {
                if (string.Join("", record) == "") continue;
                var customerObj = new Task_04.Customer();
                var nameRegex = new Regex(regexDict["Name"]);
                if (record[0] != null && nameRegex.IsMatch(record[0])) customerObj.Name = record[0].Replace(@"""", "");
                var addressRegex = new Regex(regexDict["Address"]);
                if (record[1] != null && addressRegex.IsMatch(record[1])) customerObj.Address = record[1].Replace(@"""", "");
                var emailAddressRegex = new Regex(regexDict["EmailAddress"]);
                if (record[2] != null && emailAddressRegex.IsMatch(record[2])) customerObj.EmailAddress = record[2].Replace(@"""", "");
                var phoneNumberRegex = new Regex(regexDict["PhoneNumber"]);
                if (record[3] != null && phoneNumberRegex.IsMatch(record[3])) customerObj.PhoneNumber = record[3].Replace(@"""", "");
                allCustomerRecords.Add(customerObj);
            }

            var jsonString = JsonConvert.SerializeObject(new
            {
                customerData = allCustomerRecords
            });

            File.WriteAllText(outputFilePath + inputFilePath.Split('\\').Last().Split('.').First() +".json", jsonString);
        }
    }
}