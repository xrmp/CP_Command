using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn;
    [SerializeField] private Transform characterTransform;

    private Command _leftClickCommand;
    private Command _rightClickCommand;

    private void Start()
    {
        _leftClickCommand = new MoveCharacterCommand(characterTransform);
        _rightClickCommand = new SpawnPrefabCommand(prefabToSpawn);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _leftClickCommand.Invoke(mousePosition);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _rightClickCommand.Invoke(mousePostion);
        }
    }
}
