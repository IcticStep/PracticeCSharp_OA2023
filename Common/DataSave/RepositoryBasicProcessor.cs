using Common.Tables;
using Common.Tables.API;

namespace Common.DataSave;

public class RepositoryBasicProcessor<T> where T : ITableItem
{
    private readonly IRepository<T> _repository;
    private readonly string _header;
    
    public RepositoryBasicProcessor(IRepository<T> repository, string header)
        => (_repository, _header) = (repository, header);
    

    public void CheckLoadedResources() =>
        Console.WriteLine(_repository.IsEmpty()
            ? "Файл записів відсутній. Програма створить новий, коли ви щось додасте."
            : $"Файл успішно завантажено. В системі {_repository.Count()} записів.");

    public void ShowAll()
    {
        if (!_repository.Any())
        {
            Console.WriteLine("Записи відсутні.");
            return;
        }
        
        ShowTable(_header, (_repository as IEnumerable<ITableItem>)!);
    }
    
    public void RemoveRecord()
    {
        if (!_repository.Any())
        {
            Console.WriteLine("Записи відсутні.");
            return;
        }
        
        Console.WriteLine("Видалення об'єкту");
        Inputter.GetInput("Введіть номер запису, який треба видалити або 0 щоб відмінити видалення: ",
            out var input, 0, _repository.Count());

        if (input == 0)
        {
            Console.WriteLine("Відміна видалення.");
            return;
        }

        _repository.RemoveAt(input - 1);
        Console.WriteLine("Видалення пройшло успішно.");
    }

    public void ShowTable(string name, IEnumerable<ITableItem> tapeRecorders) 
        => new TableOutput(name, tapeRecorders).Show();
}