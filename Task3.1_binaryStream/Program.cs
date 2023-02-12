using static Task3_1_common.Data;

namespace Task3_1_binaryStream;

public static class Program
{
    public static void Main()
    {
        var file1 = OpenFileWrite(1, FileMode.Create);
        WriteFile(file1, List1);
        file1.Close();
        
        var file2 = OpenFileWrite(2, FileMode.Create);
        WriteFile(file2, List2);

        var file1Reader = OpenFileRead(1, FileMode.Open);
        var readData = ReadAllData(file1Reader, List1.Count);
        file1Reader.Close();
        
        WriteFile(file2, readData);
        file2.Close();
    }
    
    private static BinaryWriter OpenFileWrite(int index, FileMode fileMode) 
        => new(File.Open(GetFileName(index), fileMode));
    
    private static BinaryReader OpenFileRead(int index, FileMode fileMode) 
        => new(File.Open(GetFileName(index), fileMode));

    private static void WriteFile(BinaryWriter file, List<string> data) => data.ForEach(file.Write);

    private static List<string> ReadAllData(BinaryReader file, int stringAmount)
    {
        var result = new List<string>();

        for (var i = 0; i < stringAmount; i++) 
            result.Add(file.ReadString());

        return result;
    }
}