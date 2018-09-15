﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserAccountLobby : MonoBehaviour {
    public Text usernameText;
	// Use this for initialization
	void Start () {
        if (UserAccountManager.IsLoggedIn)
        {
            usernameText.text = UserAccountManager.LoggedIn_Username;
        }
        
	}

    public void LogOut()
    {
        if (UserAccountManager.IsLoggedIn)
        {
            UserAccountManager.instance.LogOut();
        }
       
    }
}
