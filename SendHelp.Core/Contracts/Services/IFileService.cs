namespace SendHelp.Core.Contracts.Services;

public interface IFileService
{
    void Delete(string folderPath, string fileName);

    T Read<T>(string folderPath, string fileName);

    void Save<T>(string folderPath, string fileName, T content);
}