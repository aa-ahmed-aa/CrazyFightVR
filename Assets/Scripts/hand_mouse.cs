using UnityEngine;
using System.Collections;

public class hand_mouse : MonoBehaviour {
    // Add a public field for the Bullet prefab.
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Example());
    }

    //Add a “Fire” function to fire a Bullet.
    IEnumerator Example()
    {
        yield return new WaitForSeconds(5.0f);
        CmdFire();
    }

    void CmdFire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 2;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 5.0f);
    }
}
