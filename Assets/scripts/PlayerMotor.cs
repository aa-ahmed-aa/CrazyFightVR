using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{


    [SerializeField]
    private Camera cam;


    private Vector3 Velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 camerarotation = Vector3.zero;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    //get movement vector
    public void Move(Vector3 _velocity)
    {

        Velocity = _velocity;

    }

    //get rotation vector
    public void Rotate(Vector3 _rotation)
    {

        rotation = _rotation;

    }

    //get rotation vector for a camera
    public void RotateCamera(Vector3 _camerarotation)
    {

        camerarotation = _camerarotation;

    }


    //run every physics iteration
    void FixedUpdate()
    {
        preformmovement();
        performrotation();

    }
    //preform movement based on velocity variable

    void preformmovement()
    {
        if (Velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + Velocity * Time.fixedDeltaTime);
        }


    }


    //preform rotation
    void performrotation()
    {

        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (cam != null)
        {
            cam.transform.Rotate(camerarotation);

        }
    }

}
