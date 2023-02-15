using System.Text.Json;

namespace Common;

public class FileRepository
{
    private readonly string _filePath;

    public FileRepository(string filePath) => _filePath = filePath;

    public IEnumerable<T>? Load<T>()
    {
        if (!new FileInfo(_filePath).Exists)
            return null;
        
        var fileStream = new StreamReader(new FileStream(_filePath, FileMode.Open));
        var dataJson = fileStream.ReadToEnd();
        fileStream.Close();
        return JsonSerializer.Deserialize<IEnumerable<T>>(dataJson);
    }

    public void Save<T>(T data)
    {
        var dataJson = JsonSerializer.Serialize(data);
        var fileStream = new StreamWriter(new FileStream(_filePath, FileMode.Create));
        fileStream.Write(dataJson);
        fileStream.Close();
    }
}