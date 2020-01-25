using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
	public GameObject appleSlicedPrefab;

	Rigidbody2D rb;
	public float force = 12f;
	void Start(){
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(transform.up*force, ForceMode2D.Impulse);
	}

    void OnTriggerEnter2D(Collider2D collision){
    	if(collision.tag == "Blade"){
    		Debug.Log("Collided with apple");
    		Vector3 direction = (collision.transform.position - transform.position).normalized;
    		Quaternion rotation = Quaternion.LookRotation(direction);
    		Instantiate(appleSlicedPrefab, transform.position, rotation);
    		Destroy(this.gameObject);
    	}
    }
}
