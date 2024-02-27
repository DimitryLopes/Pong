using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Dictionary<KeyActions, KeyCode> keyBindings = new Dictionary<KeyActions, KeyCode>();

    public void SetKeyBinding(KeyActions actionName, KeyCode keyCode)
    {
        keyBindings[actionName] = keyCode;
    }

    public bool IsKeyPressed(KeyActions actionName)
    {
        if (!keyBindings.ContainsKey(actionName))
        {
            Debug.LogWarning("Key binding not found for action: " + actionName);
            return false;
        }

        KeyCode keyCode = keyBindings[actionName];
        return Input.GetKey(keyCode);
    }

    public bool GetKeyDown(KeyActions actionName)
    {
        if (!keyBindings.ContainsKey(actionName))
        {
            Debug.LogWarning("Key binding not found for action: " + actionName);
            return false;
        }

        KeyCode keyCode = keyBindings[actionName];
        return Input.GetKeyDown(keyCode);
    }

    public bool GetKeyUp(KeyActions actionName)
    {
        if (!keyBindings.ContainsKey(actionName))
        {
            Debug.LogWarning("Key binding not found for action: " + actionName);
            return false;
        }

        KeyCode keyCode = keyBindings[actionName];
        return Input.GetKeyUp(keyCode);
    }
}

public enum KeyActions
{
    Left,
    Right,
    Up,
    Down,
    Run,
    Interact,
    Attack
}