using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {
	public PlayerInput _playerInput;
	public float _baseSpeed = 8f;

	// Use this for initialization
	void Start () {
		_playerInput = transform.GetComponent<PlayerInput>();

	}

	void FixedUpdate () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(_playerInput._hMove * _baseSpeed, _playerInput._vMove * _baseSpeed);
	}


	// Update is called once per frame
	void Update () {
	
	}
}
