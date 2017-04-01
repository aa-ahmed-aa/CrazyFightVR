using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class test : MonoBehaviour
{

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;
    private PlayerMotor motor;


    void Start()
    {

        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        //calculate movement velocity as a3d vectors
        float _xmov = Input.GetAxisRaw("Horizontal");
        float _zmov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xmov;
        Vector3 _movVertical = transform.forward * _zmov;

        //final movement vector
     //   Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;


        //apply movement
      //  motor.Move(_velocity);


        //calculate rotation as a 3d vector (turning around)
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;


        //apply rotation
        motor.Rotate(_rotation);



        /////camera


        //calculate camera rotation as a 3d vector (turning around)
        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _Camerarotation = new Vector3(_xRot, 0f, 0f) * lookSensitivity;


        //apply camera rotation
        motor.RotateCamera(_Camerarotation);

    }

}
