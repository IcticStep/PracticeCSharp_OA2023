using static System.Text.Encoding;
using static Task3_1_common.Data;

namespace Task3_1_fileStream;

public static class Program
{
    public static void Main()
    {
        var file1 = OpenFile(1, FileMode.Create);
        WriteFile(file1, List1);
        file1.Close();

        var file2 = OpenFile(2, FileMode.Create);
        WriteFile(file2, List2);

        file1 = OpenFile(1, FileMode.Open);
        var readData = ReadAllBytesFromFile(file1);
        file1.Close();
        
        WriteFile(file2, readData);
        file2.Close();
    }
    
    private static FileStream OpenFile(int index, FileMode fileMode) => new (GetFileName(index), fileMode);
    
    private static void WriteFile(Stream file, List<string> data) 
        => data.ForEach(line => file.Write(UTF8.GetBytes(line + "\n")));
    
    private static void WriteFile(Stream file, Span<byte> data) 
        => file.Write(data);

    private static Span<byte> ReadAllBytesFromFile(Stream file)
    {
        var result = new byte[file.Length];
        
        var toRead = (int)file.Length;
        var read = 0;

        while (toRead > 0)
        {
            var delta = file.Read(result, read, toRead);
            
            if(delta == 0) break;

            read += delta;
            toRead -= delta;
        }

        return result;
    }
}