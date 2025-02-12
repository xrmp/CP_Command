using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabCommand : Command
{
    private GameObject _prefab;

    public SpawnPrefabCommand(GameObject prefab)
    {
        _prefab = prefab;
    }

    public override void Invoke(Vector2 position)
    {
        if (_prefab != null)
        {
            GameObject.Instantiate(_prefab, position, Quaternion.identity);
            LogPosition(position);
        }
        else
        {
            Debug.LogError("Prefab is not assigned!");
        }
    }
}
