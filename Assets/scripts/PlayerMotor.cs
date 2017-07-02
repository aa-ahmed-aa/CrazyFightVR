﻿using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {


    [SerializeField]
    private Camera cam;


    private Vector3 Velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private float cameraRotationX = 0f;
    private float currentCameraRotationX = 0f;

    //private Vector3 thrusterForce = Vector3.zero;

    [SerializeField]
    private float cameraRotationLimit = 85f;

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

   // Gets a rotational vector for the camera
   public void RotateCamera(float _cameraRotationX)
   {
       cameraRotationX = _cameraRotationX;
   }
	


   // Get a force vector for our thrusters
   //public void ApplyThruster(Vector3 _thrusterForce)
   //{
   //    thrusterForce = _thrusterForce;
   //}


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

       //if (thrusterForce != Vector3.zero)
       //{
       //    rb.AddForce(thrusterForce * Time.fixedDeltaTime, ForceMode.Acceleration);
       //}
   
   }


    //preform rotation
   void performrotation()
   {

       rb.MoveRotation(rb.rotation *Quaternion.Euler(rotation));
       if (cam != null)
       {
           // Set our rotation and clamp it
           currentCameraRotationX -= cameraRotationX;
           currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

           //Apply our rotation to the transform of our camera
           cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
       
       }
   }

}
