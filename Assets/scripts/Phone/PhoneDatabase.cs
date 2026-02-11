using UnityEngine;

public class PhoneDatabase : MonoBehaviour
{
    [Header("Fixed number (6 digits)")]
    public string fixedNumber = "123456";
    public string karlNumber = "654321";

    public bool TryCall(string dialedNumber)
    {
        string n = Normalize(dialedNumber);

        if (n == fixedNumber)
        {
            Debug.Log("wird angerufen: " + n);
            return true;
        }
        if (n == karlNumber)
        {
            Debug.Log("Karl du huanshohn " + n);
            return true;
        }

        Debug.Log("unbekannte nummer: " + n);
        return false;
    }

    private static string Normalize(string s)
    {
        if (string.IsNullOrEmpty(s)) return "";
        return s.Replace("-", "").Trim();
    }
}