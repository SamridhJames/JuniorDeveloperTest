namespace TakeawayCodingTask.Task4.Interface
{
    public interface IFileFactory
    {
        IProcessFile GetFileName(FileEnum fileEnum);
    }
}
