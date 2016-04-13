using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {
	public PlayerInput _playerInput;
	public float _maxSpeed = 8f;
	// Use this for initialization
	void Start () {
		_playerInput = transform.GetComponent<PlayerInput>();
	
	}

	void FixedUpdate () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(_playerInput._hMove * _maxSpeed, _playerInput._vMove * _maxSpeed);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
