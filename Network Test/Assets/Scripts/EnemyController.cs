using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyController : NetworkBehaviour {

	public GameObject EbulletPrefab;
    public Transform EbulletSpawn;

	int r;
	int m;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		r = Random.Range(0,1000);

		if(r %100 == 0){
			CmdEFire();
		}

		move();
	}

	[Command]
    void CmdEFire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            EbulletPrefab,
            EbulletSpawn.position,
            EbulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        NetworkServer.Spawn(bullet);

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);        
    }

	void move(){
		m = Random.Range(0, 120);
		if(m % 12 ==0){
			var angles = transform.rotation.eulerAngles;
			angles.y +=180;
			if(transform.position.z > 25 || transform.position.z < -25 || transform.position.x > 25 
			|| transform.position.z < -25){
				transform.rotation = Quaternion.Euler(angles);
				GetComponent<Rigidbody>().velocity = transform.forward *4;
				
			}
			else{
				GetComponent<Rigidbody>().velocity = transform.forward *2;
			}
		}
	}

}
