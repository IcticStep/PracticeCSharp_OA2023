namespace Common.Tables.API;

public interface ITableItem
{
    public string[] GetInfoHeaders();
    public string[] GetFullInfo();
}