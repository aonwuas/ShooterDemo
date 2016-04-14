using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public enum _projectile_type {BULLET, LASER, LINE};
	private int _damage;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
	}
}
