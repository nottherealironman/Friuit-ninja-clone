using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitGenerator : MonoBehaviour
{
    public GameObject wmelonPrefab;
    public GameObject applePrefab;
    public Transform[] spawnPoints;
	public Transform startPoint;
    public Transform startPointApple;
	public float minDelay = 0.1f;
	public float maxDelay = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateOrange() );
    }

    

    IEnumerator GenerateOrange(){
    	while(true){
    		float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);
            
            int spawnInx1 = Random.Range(0, spawnPoints.Length);
            int spawnInx2 = Random.Range(0, spawnPoints.Length);

            Transform spawnPoint1 = spawnPoints[spawnInx1];
            Transform spawnPoint2 = spawnPoints[spawnInx2];

            GameObject spawnedWmelon = Instantiate(wmelonPrefab, spawnPoint1.position, spawnPoint1.rotation);
            GameObject spawnedApple = Instantiate(applePrefab, spawnPoint2.position, spawnPoint2.rotation);
            
            Destroy(spawnedApple, 3f);
            Destroy(spawnedWmelon, 3f);
        }
    	
    }
}
