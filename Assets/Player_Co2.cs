using UnityEngine;
using UnityEngine.Networking;

public class Player_Co2 : NetworkBehaviour
 {

	// Use this for initialization


   // Add a public field for the Bullet prefab.
      public GameObject bulletPrefab;

    // Add a public field for the location of the Bullet Spawn.

      public Transform bulletSpawn;




	
	
	// Update is called once per frame
	void Update ()
    {
	

        //Add Input handling in the Update function.

       if (Input.GetKeyDown(KeyCode.Space))
          {
              CmdFire();
           }
  }

    //Add a “Fire” function to fire a Bullet.

    [Command]
    void CmdFire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        // Spawn the bullet on the Clients
        NetworkServer.Spawn(bullet);


        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }

}
