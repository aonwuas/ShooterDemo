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
				FireProjectile(g);
			}
			_playerInput._isFiring = false;
		}
	}
	
	void FireProjectile(GameObject g){
		Rigidbody2D projectileInstance = Instantiate(projectile, g.transform.position, Quaternion.identity) as Rigidbody2D;
	}
}
