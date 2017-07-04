using UnityEngine;
using System.Collections;

public class test_hands_controll : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Enter");
        //AudioSource.PlayClipPoint(sound, transform.position);
        if (other.CompareTag("Player"))
        {
            transform.Translate(new Vector3(0f, 0f, 5f));
        }
    }
}
