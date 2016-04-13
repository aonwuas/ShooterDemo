using UnityEngine;
using System.Collections;

public class GunControl : MonoBehaviour {
	public PlayerInput _playerInput;
	public Bullet bulletPrefab;
	// Use this for initialization
	void Start () {
		_playerInput = transform.GetComponentInParent<PlayerInput>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (_playerInput._fire){
			Debug.Log("Firing bullet");
			_playerInput._fire = false;
		}
	}

	void fireProjectile(){
		Bullet projectile = (Bullet)Instantiate(bulletPrefab,this.transform.position, this.transform.rotation);
	}
}
