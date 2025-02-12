using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacterCommand : Command
{
    private Transform _characterTransform;

    public MoveCharacterCommand(Transform characterTransform)
    {
        _characterTransform = characterTransform;
    }



    public override void Invoke(Vector2 position)
    {
        if (_characterTransform != null)
        {
            _characterTransform.position = position;
            LogPosition(position);
        }
        else
        {
            Debug.LogError("Character Transform is not assigned!");
        }
    }
}
