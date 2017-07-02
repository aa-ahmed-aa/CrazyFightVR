using UnityEngine;

//[RequireComponent(typeof(ConfigurableJoint))]
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;

    //[SerializeField]
    //private float thrusterForce = 1000f;


    //[Header("Spring settings:")]
    //[SerializeField]
    //private  JointDriveMode jointMode = JointDriveMode.Position;

    //[SerializeField]
    //private float jointSpring = 20f;
    //[SerializeField]
    //private float jointMaxForce = 40f;


    private PlayerMotor motor;
    private ConfigurableJoint joint;




    void Start()
    {

        motor = GetComponent<PlayerMotor>();
        //joint = GetComponent<ConfigurableJoint>();

        //SetJointSettings(jointSpring);
    }

    void Update()
    {
        //calculate movement velocity as a3d vectors
        float _xmov = Input.GetAxisRaw("Horizontal");
        float _zmov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xmov;
        Vector3 _movVertical = transform.forward * _zmov;

        //final movement vector
        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;


        //apply movement
        motor.Move(_velocity);


        //calculate rotation as a 3d vector (turning around)
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;


        //apply rotation
        motor.Rotate(_rotation);



        /////camera


        //calculate camera rotation as a 3d vector (turning around)
        float _xRot = Input.GetAxisRaw("Mouse Y");

        float _cameraRotationX = _xRot * lookSensitivity;



        //apply camera rotation
        motor.RotateCamera(_cameraRotationX);


        // Calculate the thrusterforce based on player input

      //  Vector3 _thrusterForce = Vector3.zero;
      //  if (Input.GetButton("Jump"))
      //  {

      //      _thrusterForce = Vector3.up * thrusterForce;
      //      SetJointSettings(0f);
      //  }
      //  else
      //  {

      //      SetJointSettings(jointSpring);

      //  }

      //  // Apply the thruster force
      //  motor.ApplyThruster(_thrusterForce);
    
      //}


        //private void SetJointSettings (float _jointSpring)
        //{
        //joint.yDrive = new JointDrive {
        //    positionSpring = _jointSpring,
        //    maximumForce = jointMaxForce
        //};





    }

}
