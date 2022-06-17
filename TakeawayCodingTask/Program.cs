using System.IO;
using Microsoft.Extensions.DependencyInjection;
using TakeawayCodingTask.Task4;
using TakeawayCodingTask.Task4.Interface;
using TakeawayCodingTask.Task4.ProcessFile;

namespace TakeawayCodingTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Major TODOS => could not implement those out, as 4 hours were out, took few minutes more to finish.
            //1. Combine mapping for all files into one, rather than each different one(because only tab files have columns).
            //2. Fix Program.cs to take input from users.
            //3. Fix inconsistencies for csv, file, make them more robust.
            //3. Fix Regex validation for incoming fields.
            //4. Probably add unit tests to validate.
            var taskObj1 = new Task_01();
            var taskObj2 = new Task_02();
            var taskObj3 = new Task_03();
            //change path to run, output files are to every question are in the results folder
            const string inputFilePath = "D:\\Users\\samri\\OneDrive\\Desktop\\C#\\JuniorDeveloperTest-master\\JuniorDeveloperTest-master\\TakeawayCodingTask\\SampleInputFiles\\Import_005.Custom_A.txt";
            const string outputFilePath = "D:\\Users\\samri\\OneDrive\\Desktop\\C#\\JuniorDeveloperTest-master\\JuniorDeveloperTest-master\\TakeawayCodingTask\\Results\\";

            HelperMethods.SetupStudentScoresForTask2(out var mathStudent, out var scienceStudent);
            HelperMethods.SetupStudentScoresForTask3(out var mathStudentList, out var scienceStudentList);

            //Task 1
            var resultTask1 = taskObj1.FizzBuzz(16);
            File.WriteAllText(outputFilePath + "task1.txt", string.Join(" ", resultTask1));

            //Task 2
            var resultTask2 = taskObj2.HonorRoll(mathStudent, scienceStudent);
            File.WriteAllText(outputFilePath + "task2.txt", string.Join(" ", resultTask2));

            //Task 3
            var resultTask3 = taskObj3.HonorRoll(mathStudentList, scienceStudentList);
            File.WriteAllText(outputFilePath + "task3.txt", string.Join(" ", resultTask3));

            //Task 4
            //implemented factory method with DI to decide processing class object based on extension. Easy to extend.
            var serviceProvider = new ServiceCollection()
                .AddTransient<IFileFactory, FileFactory>()
                .AddTransient<IFileProcessingService, FileProcessingService>()
                .AddScoped<ProcessCsv>()
                .AddScoped<IProcessFile, ProcessCsv>(s => s.GetService<ProcessCsv>())
                .AddScoped<ProcessTab>()
                .AddScoped<IProcessFile, ProcessTab>(s => s.GetService<ProcessTab>())
                .AddScoped<ProcessCustomA>()
                .AddScoped<IProcessFile, ProcessCustomA>(s => s.GetService<ProcessCustomA>())
                .BuildServiceProvider();

            var fileService = serviceProvider.GetService<IFileProcessingService>();
            fileService.ProcessFileData(inputFilePath, outputFilePath);
        }
    }
}