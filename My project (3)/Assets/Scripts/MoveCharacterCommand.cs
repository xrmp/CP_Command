using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacterCommand : Command
{
    private Transform _characterTransform;
    private Vector2 _previousPosition;

    public MoveCharacterCommand(Transform characterTransform)
    {
        _characterTransform = characterTransform;
    }



    public override void Invoke(Vector2 position)
    {
        if (_characterTransform != null)
        {
            _previousPosition = _characterTransform.position;
            _characterTransform.position = position;
            LogPosition(position);
        }
        else
        {
            Debug.LogError("Character Transform is not assigned!");
        }
    }

    public override void Undo()
    {
        if (_characterTransform != null)
        {
            _characterTransform.position = _previousPosition;
            Debug.Log("MoveCharacterCommand undone: Character moved back.");
        }
    }
}
