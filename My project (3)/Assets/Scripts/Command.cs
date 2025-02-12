using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public abstract void Invoke(Vector2 position);


    protected void LogPosition(Vector2 position)
    {
        Debug.Log($"Command executed at position: {position}");
    }
}
