using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabCommand : Command
{
    private GameObject _prefab;
    private GameObject _spawnedObject;

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
    public override void Undo()
    {
        if (_spawnedObject != null)
        {
            GameObject.Destroy(_spawnedObject);
            Debug.Log("SpawnPrefabCommand undone: Object Destroyed.");
        }
    }
}
