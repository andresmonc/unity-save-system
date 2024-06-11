using UnityEngine;
using System;

public class EntityID : MonoBehaviour
{
    [SerializeField] private string uniqueID;

    public string UniqueID => uniqueID;

    void Start()
    {
        // Check if the unique ID has not been generated yet
        if (string.IsNullOrEmpty(uniqueID))
        {
            // Generate a new unique ID
            uniqueID = Guid.NewGuid().ToString();

            // Optionally log the unique ID for debugging purposes
            Debug.Log($"Generated new unique ID: {uniqueID}");
        }
        else
        {
            // Optionally log the existing unique ID for debugging purposes
            Debug.Log($"Using existing unique ID: {uniqueID}");
        }
    }

#if UNITY_EDITOR
    void OnValidate()
    {
        if (string.IsNullOrEmpty(uniqueID))
        {
            uniqueID = Guid.NewGuid().ToString();
            Debug.Log($"Generated new unique ID in editor: {uniqueID}");
        }
    }
#endif
}
