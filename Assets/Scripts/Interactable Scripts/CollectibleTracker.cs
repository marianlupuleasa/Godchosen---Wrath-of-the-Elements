using UnityEngine;
using System.Collections.Generic;

public class CollectibleTracker : MonoBehaviour
{
    public static CollectibleTracker Instance;

    private HashSet<string> collectedIDs = new HashSet<string>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void MarkCollected(string id)
    {
        collectedIDs.Add(id);
    }

    public bool IsCollected(string id)
    {
        return collectedIDs.Contains(id);
    }

    public void ClearCollected()
    {
        collectedIDs.Clear();
    }
}
