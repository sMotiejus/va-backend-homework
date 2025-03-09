namespace VintedAcademyBackendHomework.Services;

public class FileOutputService:IOutputService
{
    private readonly string _filePath;
    
    public FileOutputService(string pathToFile)
    {
        _filePath = pathToFile;
        if (File.Exists(_filePath))
            File.WriteAllText(_filePath, string.Empty);
        else
            File.Create(_filePath).Close();
    }
    
    public void WriteLine(string output)
    {
        using var fileWriter = new StreamWriter(_filePath, append: true);
        fileWriter.WriteLine(output);
    }
}