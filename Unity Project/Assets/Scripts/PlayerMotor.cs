using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;
    private Rigidbody rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    //gets a movement vector
    public void Move(Vector3 v)
    {
        velocity = v;
    }
    //get rotation vector
    public void Rotate(Vector3 r)
    {
        rotation = r;
    }
    //camera rotation
    public void RotateCamera(Vector3 rc)
    {
        cameraRotation = rc;
    }
    //run every physics iteration
    private void FixedUpdate()
    {
        //perform movement
        PerformMovement();
        //perform rotation
        PerformRotation();
    }

    void PerformMovement()
    {
        if(velocity != Vector3.zero)
        {
            //move rigidbody of player to the position of the player + the velocity
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    void PerformRotation()
    {
       rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if(cam != null)
        {
            cam.transform.Rotate(-cameraRotation);
        }
    }
}
