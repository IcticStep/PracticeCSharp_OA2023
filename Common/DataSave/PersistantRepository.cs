using System.Collections;
using Common.DataSave.API;

namespace Common.DataSave;

public class PersistantRepository<T> : IRepository<T>
{
    private readonly FileCollectionSaver<T> _fileCollectionSaver;
    private List<T> _collection;

    public PersistantRepository(string filePath)
    {
        _fileCollectionSaver = new(filePath);
        Load();
    }

    public IEnumerator<T> GetEnumerator() => _collection.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public void Add(T value)
    {
        _collection.Add(value);
        Save();
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _collection.Count)
            throw new ArgumentException("Некоректний індекс видалення!");

        _collection.RemoveAt(index);
        Save();
    }

    public IEnumerable<T> GetData() => _collection.AsEnumerable();
    public int Count() => _collection.Count;

    public bool IsEmpty() => _collection.Count == 0;

    private void Load()
    {
        var loaded = _fileCollectionSaver.Load();
        if (!loaded.Any())
            _collection = new List<T>();

        _collection = loaded.ToList();
    }

    private void Save() => _fileCollectionSaver.Save(_collection);
}