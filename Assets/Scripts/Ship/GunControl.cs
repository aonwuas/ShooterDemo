using UnityEngine;
using System.Collections;

public class GunControl : MonoBehaviour {
	public PlayerInput _playerInput;
	public GameObject projectile;
	public GameObject[] _hardpoints;
	// Use this for initialization
	void Start () {
		_playerInput = transform.GetComponentInParent<PlayerInput>();
		_hardpoints = GameObject.FindGameObjectsWithTag("Gun");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (_playerInput._isFiring){
			foreach(GameObject g in _hardpoints){
				fireProjectile(g);
			}
			_playerInput._isFiring = false;
		}
	}
	
	void fireProjectile(GameObject g){
		Debug.Log("Firing bullet from" + g.name);
		Rigidbody2D projectileInstance = Instantiate(projectile, g.transform.position, Quaternion.Euler(new Vector3(1,0,0))) as Rigidbody2D;
	}
}
