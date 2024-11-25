using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputConfiguration: MonoBehaviour
{
    private Dictionary<string, KeyCode> keyBindings;

    public InputConfiguration()
    {
        keyBindings = new Dictionary<string, KeyCode>
        {
            { "MoveLeft", KeyCode.LeftArrow },
            { "MoveRight", KeyCode.RightArrow },
            { "Jump", KeyCode.Space }
        };
    }

    // Obtener la tecla para una acción específica
    public KeyCode GetKeyForAction(string action)
    {
        if (keyBindings.ContainsKey(action))
        {
            return keyBindings[action];
        }
        return KeyCode.None; // Si no existe la acción, devolvemos una tecla no válida
    }

    // Cambiar la tecla para una acción específica
    public void SetKeyForAction(string action, KeyCode newKey)
    {
        if (keyBindings.ContainsKey(action))
        {
            keyBindings[action] = newKey;
        }
        else
        {
            keyBindings.Add(action, newKey);
        }
    }
}
