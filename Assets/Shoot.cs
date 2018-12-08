using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    [SerializeField] private GameObject projectile;
    [SerializeField] private float strength = 15f;
    
    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire2")) {
            GameObject coco = Instantiate(projectile, transform.position, transform.rotation);
            coco.GetComponent<Rigidbody>().AddForce(transform.forward*strength,ForceMode.Impulse);
        }
        
        if (Input.GetButtonDown("Fire1")) {
            // Bit shift the index of the layer (8) to get a bit mask
		int layerMask = 1 << 12;

            // This would cast rays only against colliders in layer 8.
            // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
		layerMask = ~layerMask;

            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 500,layerMask)) {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance,
                    Color.yellow);
                Debug.Log("Did Hit");
                if (hit.collider.CompareTag("target")) {
                    hit.collider.gameObject.GetComponent<Target>().Hit();
                }
                else {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000,
                        Color.white);
                    Debug.Log("Did not Hit");
                }
            }
        }
    }
}