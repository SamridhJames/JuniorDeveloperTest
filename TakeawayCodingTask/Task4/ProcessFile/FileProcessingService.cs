using System;
using System.Linq;
using TakeawayCodingTask.Task4.Interface;

namespace TakeawayCodingTask.Task4.ProcessFile
{
    public class FileProcessingService: IFileProcessingService
    {
        private readonly IFileFactory _fileFactory;
        private IProcessFile _processFile;

        public FileProcessingService(IFileFactory fileFactory)
        {
            _fileFactory = fileFactory;
        }
        public void ProcessFileData(string inputFilePath, string outputFilePath)
        {
            _processFile = GetFileName(inputFilePath);
            _processFile.ConvertFileDataToJson(inputFilePath, outputFilePath);
        }

        private IProcessFile GetFileName(string filePath)
        {
            var fileType = string.Join("", filePath.Split('.').Skip(1).ToArray());
            switch (fileType)
            {
                case "csv":
                    return _fileFactory.GetFileName(FileEnum.Csv);
                case "tab":
                    return _fileFactory.GetFileName(FileEnum.Tab);
                case "Custom_Atxt":
                    return _fileFactory.GetFileName(FileEnum.Custom);
                default:
                    throw new ArgumentOutOfRangeException($"Invalid type");
            }
        }
    }
}
