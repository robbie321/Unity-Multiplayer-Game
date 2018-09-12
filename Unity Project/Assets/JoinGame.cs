using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class JoinGame : MonoBehaviour {
    private NetworkManager networkManager;
    private List<GameObject> roomList = new List<GameObject>();
	// Use this for initialization
	void Start () {
        networkManager = NetworkManager.singleton;
        if(networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }

        RefreshRoomList();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RefreshRoomList()
    {

    }
}
