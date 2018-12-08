using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	[SerializeField] private Animator anim;

	public void Hit() {
		anim.SetBool("down",true);
	}

	private void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag("projectile")) {
			Hit();
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
