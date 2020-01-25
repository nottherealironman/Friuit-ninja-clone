using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watermelon : MonoBehaviour
{
	public GameObject wmelonSlicedPrefab;

	Rigidbody2D rb;
	public float force = 12f;
	void Start(){
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(transform.up*force, ForceMode2D.Impulse);
	}

    void OnTriggerEnter2D(Collider2D collision){
    	if(collision.tag == "Blade"){
    		Debug.Log("Cut watermelon");
    		Vector3 direction = (collision.transform.position - transform.position).normalized;
    		Quaternion rotation = Quaternion.LookRotation(direction);
    		Instantiate(wmelonSlicedPrefab, transform.position, rotation);
    		Destroy(gameObject);
    	}
    }
}
