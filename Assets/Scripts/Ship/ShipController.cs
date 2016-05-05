using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {
	public PlayerInput _playerInput;
	GameInfo _gameInfo;
	public float _hMoveSpeed;
	public float _vMoveSpeed;
	public float _scrollSpeed;

	// Use this for initialization

	void Awake(){

	}
	void Start () {
		_gameInfo = GameObject.FindGameObjectWithTag("GameInfo").transform.GetComponent<GameInfo>();
		_playerInput = transform.GetComponent<PlayerInput>();
		_hMoveSpeed = _gameInfo.shipHSpeed;
		_vMoveSpeed = _gameInfo.shipVSpeed;
		_scrollSpeed = _gameInfo._scrollSpeed;
	}

	void FixedUpdate () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(_playerInput._hMove * _hMoveSpeed, _playerInput._vMove * _vMoveSpeed);
	}


	// Update is called once per frame
	void Update () {
	
	}
}
