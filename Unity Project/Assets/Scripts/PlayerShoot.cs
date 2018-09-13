using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour
{

    private const string PLAYER_TAG = "Player";

    public PlayerWeapon weapon;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

    void Start()
    {
        if (cam == null)
        {
            Debug.LogError("PlayerShoot: No camera referenced!");
            this.enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    [Client]
    void Shoot()
    {
        Debug.Log("Shot");
        // Declare here.. will store info on what we hit
        RaycastHit _hit;

        // if we hit something..
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask))
        {
            Debug.Log("Raycasting..");
            if (_hit.collider.tag == PLAYER_TAG)
            {
                
                Debug.Log("PLayer name:" + _hit.collider.name+ ":"+" Player Tag:" + _hit.collider.tag);
                CmdPlayerShot(_hit.collider.name);
            }
        }

    }

    [Command]
    void CmdPlayerShot(string _ID)
    {
        Debug.Log(_ID + " has been shot.");
    }

}