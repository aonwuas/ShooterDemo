using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {
	public enum projectile_type {BULLET, LASER, LINE};
	protected GameObject instantiationObject;
	protected float damage;

	// Use this for initialization
	void Start () {
	}

	public GameObject instanceObject(){
		return instantiationObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
	}
}
