using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToSpawn;
    [SerializeField] private Transform _characterTransform;

    private const int MaxCommandQueueSize = 10;
    private Queue<Command> _commandQueue = new Queue<Command>();
    private Queue<(Command comand, Vector2 position)> _rightClickCommandQueue = new Queue<(Command, Vector2)>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var moveCommand = new MoveCharacterCommand(_characterTransform);
            moveCommand.Invoke(mousePosition);
            AddCommandToQueue(moveCommand);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var spawnCommand = new SpawnPrefabCommand(_prefabToSpawn);
            _rightClickCommandQueue.Enqueue((spawnCommand, mousePosition));
        }

        if (!Input.GetMouseButtonDown(2))
        {
            Undo();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ExcuteRightClickCommands();
        }
    }

    private void AddCommandToQueue(Command command)
    {
        if (_commandQueue.Count >= MaxCommandQueueSize)
        {
            _commandQueue.Dequeue();
        }
        _commandQueue.Enqueue(command);
    }

    private void Undo()
    {
        if (_commandQueue.Count > 0)
        {
            var lastCommand = _commandQueue.Dequeue();
            lastCommand.Undo();
        }
        else
        {
            Debug.Log("No Commands to Undo.");
        }
    }

    private void ExcuteRightClickCommands()
    {
        while (_rightClickCommandQueue.Count > 0)
        {
            var (cmd, position) = _rightClickCommandQueue.Dequeue();
            cmd.Invoke(position);
            AddCommandToQueue(cmd);
        }
    }


}
