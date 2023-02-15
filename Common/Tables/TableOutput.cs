using System.Text;
using Common.Tables.API;

namespace Common.Tables;

public class TableOutput
{
    private const char _horizontalSymbol = '-';
    private const char _verticalSymbol = '|';

    private readonly string _mainHeader;
    private string[] _headers;
    private IEnumerable<string[]> _rows;
    private int[] _columnsLengths;
    private string _horizontalBorder; 

    public TableOutput(string header, IEnumerable<ITableItem> tableData)
    {
        if(tableData == null || !tableData.Any())
            throw new ArgumentException("Спроба створити пусту таблицю.");

        _mainHeader = header;
        CalculateHeaders(tableData);
        CalculateRows(tableData);

        ValidateRowsAndHeaders();

        CalculateColumnsLengths();
        CalculateHorizontalBorder();
    }

    public void Show()
    {
        var oldForegroundColor = Console.ForegroundColor;
        ShowMainHeader();
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        
        ShowHorizontalLine();
        Console.WriteLine(GetFormattedRow(_headers));
        ShowHorizontalLine();
        
        Console.ForegroundColor = oldForegroundColor;

        foreach (var row in _rows)
        {
            Console.WriteLine(GetFormattedRow(row));
            ShowHorizontalLine();
        }
    }

    private void CalculateHeaders(IEnumerable<ITableItem> tableData) 
        => _headers = tableData
            .FirstOrDefault()?
            .GetInfoHeaders()
            .Prepend("№")
            .ToArray()!;

    private void CalculateRows(IEnumerable<ITableItem> tableData) 
        => _rows = tableData.Select((item, num) =>  item
                .GetFullInfo()
                .Prepend((num+1).ToString())
                .ToArray());

    private void ValidateRowsAndHeaders()
    {
        if (_headers.Length != _rows.First().Length)
            throw new ArgumentException("Кількість стовпців і заголовків різна.");
    }

    private void CalculateColumnsLengths()
    {
        _columnsLengths = new int[_headers.Length];
        
        for (var i = 0; i < _headers.Length; i++)
        {
            var currentIndex = i;
            var columnValues = _rows.Select(row => row[currentIndex]);
            var longestValueLength = columnValues.Max(value => value.Length);
            var headerLenght = _headers[i].Length;
            
            _columnsLengths[i] = Math.Max(longestValueLength, headerLenght) + 1;
        }
    }

    private void CalculateHorizontalBorder()
    {
        var targetLenght = 2 * _headers.Length + 1 + _columnsLengths.Sum();
        var result = new StringBuilder();
        
        for (var i = 0; i < targetLenght; i++)
            result.Append(_horizontalSymbol);
        
        _horizontalBorder = result.ToString();
    }

    private void ShowHorizontalLine() => Console.WriteLine(_horizontalBorder);

    private string GetFormattedRow(string[] row)
    {
        var result = new StringBuilder();

        for (var i = 0; i < row.Length; i++)
        {
            var length = _columnsLengths[i];
            var column = string.Format($"{_verticalSymbol} {{0,-{length}}}", row[i]);
            result.Append(column);
        }

        result.Append(_verticalSymbol);
        return result.ToString();
    }

    private void ShowMainHeader() => Console.WriteLine(CenterText(_mainHeader, _horizontalBorder.Length));

    private string CenterText(string text, int space)
    {
        var emptySpace = space - text.Length;
        if (space <= 1)
            return text;

        var oneSidePadding = GetEmptyString(emptySpace / 2);
        return oneSidePadding + text + oneSidePadding;
    }

    private string GetEmptyString(int length)
    {
        var result = "";
        for (var i = 0; i < length; i++)
            result += " ";
        return result;
    }
}