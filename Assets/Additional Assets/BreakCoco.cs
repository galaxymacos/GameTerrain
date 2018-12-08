using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakCoco : MonoBehaviour {

	public GameObject topProjectile;
	public GameObject bottomProjectile;
	public GameObject originalProjectile;
	public float force = 5f;
	public float timer = 30f;
	public bool UseTimer = true;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision col){
		originalProjectile.SetActive(false);
		topProjectile.SetActive(true);
		bottomProjectile.SetActive(true);
		topProjectile.transform.parent = null;
		bottomProjectile.transform.parent = null;
		Rigidbody rb = topProjectile.GetComponent<Rigidbody>();
		rb.AddForce(transform.forward * force, ForceMode.Impulse);
		rb = bottomProjectile.GetComponent<Rigidbody>();
		rb.AddForce(transform.forward * -force, ForceMode.Impulse);
		if (UseTimer)
			Invoke("StartTimer", timer);
	}
	private void StartTimer(){
		Destroy(gameObject);
	}

	void OnDestroy(){
		Destroy(bottomProjectile);
		Destroy(topProjectile);
		
	}
}
