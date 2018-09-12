using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class PauseMenu : MonoBehaviour {
    [SerializeField]
    private GameObject pauseMenu;
    private NetworkManager networkManager;
    public static bool isOn = false;
	// Use this for initialization
	void Start () {
        networkManager = NetworkManager.singleton;
        isOn = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
	}
    public void LeaveRoom()
    {
        MatchInfo matchInfo = networkManager.matchInfo;
        networkManager.matchMaker.DropConnection(matchInfo.networkId, matchInfo.nodeId, 0, networkManager.OnDropConnection);
        networkManager.StopHost();
    }
    void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        isOn = pauseMenu.activeSelf;
    }
    //disconnecting video to disable player abilities
}
