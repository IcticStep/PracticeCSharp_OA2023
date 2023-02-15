using System.Text.Json;

namespace Common.DataSave;

public class FileCollectionSaver<T>
{
    private readonly string _filePath;
    
    public FileCollectionSaver(string filePath) => _filePath = filePath;

    public IEnumerable<T> Load()
    {
        if (!new FileInfo(_filePath).Exists)
            return Array.Empty<T>();
        
        var fileStream = new StreamReader(new FileStream(_filePath, FileMode.Open));
        var dataJson = fileStream.ReadToEnd();
        fileStream.Close();
        return JsonSerializer.Deserialize<IEnumerable<T>>(dataJson) ?? Array.Empty<T>();
    }

    public void Save(IEnumerable<T> data)
    {
        var dataJson = JsonSerializer.Serialize(data);
        var fileStream = new StreamWriter(new FileStream(_filePath, FileMode.Create));
        fileStream.Write(dataJson);
        fileStream.Close();
    }
}