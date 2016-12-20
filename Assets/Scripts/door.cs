using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {

	// Smothly open a door
	public    float smooth = 2.0f;
	public    float DoorOpenAngle = 90.0f;
	public float DoorCloseAngle = 0.0f;
	public    bool open ;
	public    bool enter ; 
	//Main function
	void Update ( ){

		if(open == true){ 
			Quaternion    target = Quaternion.Euler (0, DoorOpenAngle, 0);
			// Dampen towards the target rotation
			transform.localRotation = Quaternion.Slerp(transform.localRotation, target,
				Time.deltaTime * smooth);
		}

		if(open == false){
			Quaternion target1 = Quaternion.Euler (0, DoorCloseAngle, 0);
			// Dampen towards the target rotation
			transform.localRotation = Quaternion.Slerp(transform.localRotation, target1,
				Time.deltaTime * smooth);
		}

		if(enter == true){
			if(Input.GetKeyDown("f")){
				open = !open;
			}
		}

	}

	//Activate the Main function when player is near the door
	void OnTriggerEnter ( Collider other){

		if (other.gameObject.tag == "Player") {
			enter = true;
		}
	}

	//Deactivate the Main function when player is go away from door
	void OnTriggerExit (Collider other)
	{

		if (other.gameObject.tag == "Player") {
			(enter) = false;
		}
	}
} 

