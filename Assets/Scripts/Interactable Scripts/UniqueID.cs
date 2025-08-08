using UnityEngine;

[ExecuteAlways]
public class UniqueID : MonoBehaviour
{
    [SerializeField] private string uniqueId;

    public string ID => uniqueId;

    void Awake()
    {
        if (string.IsNullOrEmpty(uniqueId))
            uniqueId = System.Guid.NewGuid().ToString();
    }

#if UNITY_EDITOR
    void OnValidate()
    {
        if (string.IsNullOrEmpty(uniqueId))
            uniqueId = System.Guid.NewGuid().ToString();
    }
#endif
}