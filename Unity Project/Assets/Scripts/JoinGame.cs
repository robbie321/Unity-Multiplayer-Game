using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class JoinGame : MonoBehaviour {
    private NetworkManager networkManager;

    [SerializeField]
    private Text status;
    [SerializeField]
    private GameObject roomListItemPF;
    [SerializeField]
    private Transform roomListParent;
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
        //clear rooms in list
        ClearRoomList();
        //refreshing
        networkManager.matchMaker.ListMatches(0,10,"",true,0,0, OnMatchList);
        status.text = "Loading...";
    }

    public void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matches)
    {
        status.text = "";
        if(matches == null)
        {
            //connectivity issue
            status.text = "Couldn't get room list";
            return;

        }


        //add new ones to list
        //JSON response for List<MatchInfoSnapshot>

        /*
          for each match we find, make a new object.
          scroll view will set the position of this object.
          parent it to the scroll view
         */
        foreach (MatchInfoSnapshot match in matches)
        {
            GameObject roomListItemGO = Instantiate(roomListItemPF);
            roomListItemGO.transform.SetParent(roomListParent);
            //have a component sit on the game object
            roomListItem roomLI = roomListItemGO.GetComponent<roomListItem>();
            if(roomLI != null)
            {
                roomLI.Setup(match, JoinRoom);

            }
            //set up call back function. use a delegate
            

            roomList.Add(roomListItemGO);
        }

        if(roomList.Count == 0)
        {
            status.text = "No rooms at the moment.";
        }
    }

    void ClearRoomList()
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            Destroy(roomList[i]);
        }
        roomList.Clear();

    }

    public void JoinRoom(MatchInfoSnapshot _match)
    {
        Debug.Log("Game Joined");
        networkManager.matchMaker.JoinMatch(_match.networkId, "", "", "", 0, 0, networkManager.OnMatchJoined);
        ClearRoomList();
        status.text = "Joining...";
    }
    
}
