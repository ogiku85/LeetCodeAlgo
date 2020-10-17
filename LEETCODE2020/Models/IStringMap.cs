namespace LEETCODE2020.Models
{
    public interface IStringMap<TValue> where TValue : class
    {
        int Count { get; }
        TValue DefaultValue { get; set; }

        bool AddElement(string key, TValue value);
        TValue GetValue(string key);
        bool RemoveElement(string key);
    }
}