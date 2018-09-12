using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
//act as an object that is networked
public class PlayerSetup : NetworkBehaviour {
    [SerializeField]
    Behaviour[] componentsToDiasble;
    private Camera sceneCamera;
    private void Start()
    {
        //check if we are the local player
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componentsToDiasble.Length; i++)
            {
                transform.position = new Vector3(17, 1, 10);
                componentsToDiasble[i].enabled = false;
            }

        }
        else
        {
            transform.position = new Vector3(17, 1, -10);
            sceneCamera = Camera.main;
            if(sceneCamera != null)
            {
                sceneCamera.gameObject.SetActive(false);
            }
        }
    }
    private void OnDisable()
    {
        if(sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }
    }
}
