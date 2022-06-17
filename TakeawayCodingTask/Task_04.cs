namespace TakeawayCodingTask
{
    internal class Task_04
    {
        public class Customer
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public string PostCode { get; set; }
            public string EmailAddress { get; set; }
            public string PhoneNumber { get; set; }
        }

        /* 
        Customer details can arrive into the system in several ways.
        The end of the file name will dictate what format the data is in, 
           - As CSV files, *.csv
             All fields will appear in the same order for each file e.g.

           - As Tab files, *.tab
             Fields can be ordered differently in each file, but field names will always be identical, e

           - As Custom Tag delimted files, *.Custom_A.txt
             Where custom delimiters appear 

        Output
           The output format is json, the output file will contain a json array of customer objects from the input file

        1. Ignore all other data in the files which would not fit into the above customer class
        2. Keep in mind that some of these files can run to gigabytes.
        3. The Integrations Team tell us there will be addition formats soon, so our solution must be extensible.
        4. The integrations Team have given a set of Sample input files, in the "SampleInputFiles" folder

        5. Take your time with this, add as many classes & methods as you think you need, show us what you can do!
        */

        public void CustomerImportToCommonFormat(string inputFile, string outputFile)
        {
            //implemented factory method with DI to decide processing class object based on extension. Easy to extend.
            //Please refer to Program.cs fro starting point and Task4 folder.

        }
    }
}
