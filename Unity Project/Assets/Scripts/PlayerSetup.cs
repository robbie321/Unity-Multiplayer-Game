using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
//act as an object that is networked
[RequireComponent(typeof(Player))]
public class PlayerSetup : NetworkBehaviour {
    [SerializeField]
    Behaviour[] componentsToDisable;
    [SerializeField]
    private Transform[] spawnPoints;
    private Camera sceneCamera;

    [SerializeField]
    string remoteLayerName = "RemotePlayer";
    private void Start()
    {
        //check if we are the local player
        if (!isLocalPlayer)
        {
            DisableComponents();
            AssignRemoteLayer();
                transform.position = new Vector3(17, 1, 10);

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
       GetComponent<Player>().Setup();
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        string _netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player _player = GetComponent<Player>();

        GameManager.RegisterPlayer(_netID, _player);
    }

    void AssignRemoteLayer()
    {
        gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
    }

    void DisableComponents()
    {
        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].enabled = false;
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
