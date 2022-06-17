using System;
using TakeawayCodingTask.Task4.Interface;

namespace TakeawayCodingTask.Task4.ProcessFile
{
    public class FileFactory: IFileFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public FileFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IProcessFile GetFileName(FileEnum fileEnum)
        {
            switch (fileEnum)
            {
                case FileEnum.Csv:
                    return (IProcessFile)_serviceProvider.GetService(typeof(ProcessCsv));
                case FileEnum.Tab:
                    return (IProcessFile)_serviceProvider.GetService(typeof(ProcessTab));
                case FileEnum.Custom:
                    return (IProcessFile) _serviceProvider.GetService(typeof(ProcessCustomA));
                default:
                    throw new ArgumentOutOfRangeException(nameof(fileEnum), fileEnum, $"Not supported or added yet");
            }
        }
    }
}
