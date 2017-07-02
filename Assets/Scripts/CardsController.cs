using UnityEngine;
using System.Collections;

public class CardsController : MonoBehaviour {

    public Animator ani;
    public GameObject Character;
    public Transform Character_SpawnPoint;

    // public AudioClip sound;

    // Use this for initialization
    void Start () {
        ani.enabled = false;
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Enter");
        //AudioSource.PlayClipPoint(sound, transform.position);
        if(other.CompareTag("Player"))
        {
            ani.enabled = true;
            StartCoroutine(Example());
        }
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(8.0f);

        var bullet = (GameObject)Instantiate(
                Character,
                Character_SpawnPoint.position,
                Character_SpawnPoint.rotation);
    }
}
