using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour, ISaveable
{
    private int exampleCount = 2;
    private int exampleSize = 500;
    
    [SerializeField] private EntityID entityID;

    public void Load(SaveData saveData)
    {
        exampleCount = saveData.GetData<int>("exampleCount");
        exampleSize = saveData.GetData<int>("exampleSize");
    }

    public SaveData Save()
    {
        return SaveData.Of(
            entityID.UniqueID,
            ("exampleCount", exampleCount),
            ("exampleSize", exampleSize)
        );
    }
}
