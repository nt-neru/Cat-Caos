using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Connection;
using FishNet.Object;

public class PlayerController : NetworkBehaviour
{
    public override void OnStartClient()
    {
        base.OnStartClient();
        if (!base.IsOwner)
        {
            gameObject.GetComponent<PlayerController>().enabled = false;
        }
    }

    void Start()
    {
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
