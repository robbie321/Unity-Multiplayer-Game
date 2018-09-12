using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking.Match;
public class roomListItem : MonoBehaviour {
    public delegate void JoinRoomDelegate(MatchInfoSnapshot match);
    //create instance of delegate
    public JoinRoomDelegate joinRoomCallback;
    [SerializeField]
    private Text roomNameText;
    private MatchInfoSnapshot match;
    public void Setup(MatchInfoSnapshot _match, JoinRoomDelegate _joinRoomCallback)
    {
        joinRoomCallback = _joinRoomCallback;
        match = _match;
        roomNameText.text = match.name + "(" + match.currentSize + "/" + match.maxSize + ")";


    
    }

    public void JoinRoom()
    {
        joinRoomCallback.Invoke(match);
    }
}
//we wantt to be able to make a delegate that will contain a bunch of references to a set of functions that we want to call but we do not know what these functions are yet. only at runtime
//functions are able to subscribe to this callback so when we invoke it all the functions subscribed to it wil be called
/*
     create delegate void
     create instance of that delegate(callback)
     when setting up put in a function that we will set the joinroomcallback equal to
     then whatever function is passed in, it will be called
*/
