using UnityEngine;
using System.Collections;

public class RotateFan : MonoBehaviour {
	public float speed = 15f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, speed, 0);
	}
}
