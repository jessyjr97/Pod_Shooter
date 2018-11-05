using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class FollowMouse : NetworkBehaviour {
    [SerializeField] GameObject gun;
    [SerializeField] Camera playerCamera;
    [SerializeField] GameObject player;

    void Start() {

    }
    
    void Update() {
        if (isLocalPlayer)
        {
            if (Input.GetAxis("Mouse X") != 0)
            {
                player.transform.Rotate(0, Input.GetAxis("Mouse X") * 25, 0);

            }
            if (Input.GetAxis("Mouse Y") != 0)
            {
                playerCamera.transform.Rotate(-Input.GetAxis("Mouse Y") * 5, 0, 0);
                gun.transform.Rotate(-Input.GetAxis("Mouse Y") * 5, 0, 0);
                playerCamera.transform.Translate(0, -Input.GetAxis("Mouse Y") * 0.1f, 0);
            }
        }
    }
}
