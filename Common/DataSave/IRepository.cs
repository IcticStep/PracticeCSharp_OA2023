﻿namespace Common.DataSave;

public interface IRepository<T> : IEnumerable<T>
{
    public void Add(T value);
    public void RemoveAt(int index);
    public IEnumerable<T> GetData();
    public int Count();
    public bool IsEmpty();
}