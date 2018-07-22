using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lga238 {
public class PlaceCyl : MonoBehaviour {

	// Use this for initialization

	public GameObject cyl;

	// randomlmy place cylinde game object on map
	void Start () {
		for(int i = 0; i < 10; i++){
			GameObject temp = GameObject.Instantiate(cyl, new Vector3(Random.Range(-240f,240f),7f, Random.Range(-240f,240f)), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
}
