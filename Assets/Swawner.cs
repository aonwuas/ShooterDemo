using UnityEngine;
using System.Collections;

public class Swawner : MonoBehaviour {
	public GameObject enemy;
	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnEnemy", 3f, 0.25f);
	}
	
	// Update is called once per frame
	void Update () {

	}
	void SpawnEnemy(){
		Rigidbody2D enemyInstance = Instantiate(enemy, this.transform.position, Quaternion.identity) as Rigidbody2D;
	}
}
