using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
	bool isSlicing = false;
	Rigidbody2D rb;
	Camera cam;
    public GameObject BladeTrailPrefab;
    GameObject currentTrail;
    CircleCollider2D cc;

    Vector2 previousPos;
    public float thresholdVelocity = 1f;

	void Start(){
		cam = Camera.main;
		rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CircleCollider2D>();
        cc.enabled = false;
	}

    // Update is called once per frame
    void Update()
    {
     	if(Input.GetMouseButtonDown(0)){
     		StartSlicing();
            //Debug.Log("Start");
     	}
     	else if(Input.GetMouseButtonUp(0)){
     		EndSlicing();
            //Debug.Log("End");
     	}

     	if(isSlicing){
     		UpdateBlade();
     	}
    }

    private void StartSlicing(){
    	isSlicing = true;
        currentTrail = Instantiate(BladeTrailPrefab, transform);
        previousPos = cam.ScreenToWorldPoint(Input.mousePosition);
        cc.enabled = true;
    }

    private void EndSlicing(){
    	isSlicing = false;
        Destroy(currentTrail, 0.1f);
        cc.enabled = false;
    }

    private void UpdateBlade(){
        Vector2 currentPos = cam.ScreenToWorldPoint(Input.mousePosition);
    	rb.position = currentPos;
        float velocity = (currentPos - previousPos).magnitude / Time.deltaTime;
        if(velocity >thresholdVelocity){
            cc.enabled = true;
        }
        else{
            cc.enabled = false;
        }
        previousPos = currentPos;

    }
}
