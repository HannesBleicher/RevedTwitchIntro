using System.Collections.Generic;
using UnityEngine;

public class SaveNames : MonoBehaviour
{
    private List<string> names = new List<string>();
    
    public void AddName(string name)
    {
        names.Add(name);
    }

    public bool IsUsed(string name)
    {
        if (names.Contains(name))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
