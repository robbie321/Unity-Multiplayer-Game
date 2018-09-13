using UnityEngine;

// Very Import that the class is serializable as unity will know how to save and load this class
// if its not Serializable , it will not even show up as a varibale in inspector.


[System.Serializable]
public class PlayerWeapon
{

    public string name = "Glock";

    public float damage = 10f;
    public float range = 100f;

}
