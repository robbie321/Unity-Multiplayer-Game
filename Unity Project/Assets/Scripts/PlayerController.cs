using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerController))]
public class PlayerController : MonoBehaviour {
    //Players speed
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float lookSensitivity = 3;
    //players motor
    private PlayerMotor motor;
    //[SerializeField]
    private Animator animator;


    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
        animator = GetComponent<Animator>(); 
    }

    private void Update()
    {
        //calculate movement velocity as a 3d vector
        float xMov = Input.GetAxis("Horizontal");
        float zMov = Input.GetAxis("Vertical");

        Vector3 movHorizontal = transform.right * xMov;
        Vector3 movVertical = transform.forward * zMov;

        //final velocity vector
        Vector3 velocity = (movHorizontal + movVertical) * speed;

        //Animate movement
        //animator.SetFloat("ForwardVelocity", zMov);

        //apply movement
        motor.Move(velocity);

        //player rotation as 3d vector. first get y postion. (Turning around
        float yRotation = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0f, yRotation, 0f) * lookSensitivity;
        //apply rotation
        motor.Rotate(rotation);

        //camera rotation as 3d vector. first get y postion. (Turning around
        float xRotation = Input.GetAxisRaw("Mouse Y");

        Vector3 camRotation = new Vector3(xRotation, 0f, 0f) * lookSensitivity;
        //apply camera rotation
        motor.RotateCamera(camRotation);
    }

}
