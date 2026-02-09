using System;
using System.Collections.Generic;

public class GameState
{
    private Dictionary<string, string> states = new();

    public event Action<string, string> OnStateChanged;

    public void Set(string key, string value)
    {
        states[key] = value;
        OnStateChanged?.Invoke(key, value);
    }

    public string Get(string key, string defaultValue = "")
    {
        return states.TryGetValue(key, out var value) ? value : defaultValue;
    }

    public bool Is(string key, string value)
    {
        return Get(key) == value;
    }
}