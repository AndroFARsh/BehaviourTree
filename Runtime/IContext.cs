namespace BTree.Runtime
{
  public interface IContext
  {
    bool Has<T>() => Has<T>(typeof(T));
    bool Has<T>(object key);
    
    bool TryGet<T>(out T value) => TryGet<T>(typeof(T), out value);

    bool TryGet<T>(object key, out T value)
    {
      if (Has<T>(key))
      {
        value = Get<T>(key);
        return true;
      }

      value = default(T);
      return false;
    }

    T Get<T>() => Get<T>(typeof(T));
    T Get<T>(object key);
    
    T Put<T>(T newValue) => Put<T>(typeof(T), newValue);
    T Put<T>(object key, T newValue);
  }
}