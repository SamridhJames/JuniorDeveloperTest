using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using TakeawayCodingTask.Task4.Interface;

namespace TakeawayCodingTask.Task4.ProcessFile
{
    public class ProcessCustomA : IProcessFile
    {
        public void ConvertFileDataToJson(string inputFilePath, string outputFilePath)
        {
            var customerContent = new StringBuilder();
            var headerFound = false;
            const char customDeliminator = '\n';

            foreach (var line in File.ReadLines(inputFilePath))
            {
                if (line.Contains("#custstart") || line.Contains("#invoicestart"))
                {
                    headerFound = !headerFound;
                }
                else
                {
                    if (!headerFound) continue;
                    customerContent.Append(customDeliminator);
                    customerContent.Append(line);
                }
            }

            var data = customerContent.ToString().Split(new[] {"#custend"}, StringSplitOptions.None);
            var allCustomerRecords = new List<Task_04.Customer>();
            var regexDict = HelperMethods.RegexDict();
            var nameRegex = new Regex(regexDict["Name"]);
            var addressRegex = new Regex(regexDict["Address"]);
            var emailAddressRegex = new Regex(regexDict["EmailAddress"]);
            var phoneNumberRegex = new Regex(regexDict["PhoneNumber"]);
            var postCodeRegex = new Regex(regexDict["PostCode"]);
            foreach (var customer in data)
            {
                var customerObj = new Task_04.Customer();
                var eachCustomerData = customer.Split(customDeliminator);
                if (eachCustomerData.Length <= 1) continue;
                if (nameRegex.IsMatch(eachCustomerData[1])) customerObj.Name = eachCustomerData[1];
                var address = eachCustomerData.Skip(2).Take(eachCustomerData.Length - 5).Where(line => line != "").Aggregate("", (current, line) => current + line);
                if (addressRegex.IsMatch(address)) customerObj.Address = address;
                if (postCodeRegex.IsMatch(eachCustomerData[eachCustomerData.Length - 3])) customerObj.PostCode = eachCustomerData[eachCustomerData.Length-4];
                if (phoneNumberRegex.IsMatch(eachCustomerData[eachCustomerData.Length - 2])) customerObj.PhoneNumber = eachCustomerData[eachCustomerData.Length-3];
                if (emailAddressRegex.IsMatch(eachCustomerData[eachCustomerData.Length - 1])) customerObj.EmailAddress = eachCustomerData[eachCustomerData.Length-2];
                allCustomerRecords.Add(customerObj);
            } 

            var jsonString = JsonConvert.SerializeObject(new
            {
                customerData = allCustomerRecords
            });

            File.WriteAllText(outputFilePath + inputFilePath.Split('\\').Last().Split('.').First() + ".Custom_A.txt.json", jsonString);
        }
    }
}
