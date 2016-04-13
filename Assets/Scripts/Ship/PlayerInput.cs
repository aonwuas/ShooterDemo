﻿using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	public float _hMove, _vMove;
	private float _currentRotation;//	, _maxRotation = 5;
	public bool _isFiring = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		horizontalMovement();
		checkFire();
	}

	public void horizontalMovement(){
		_hMove = Input.GetAxis("Horizontal");
		_vMove = Input.GetAxis("Vertical");
	}
	private void checkFire(){
		if( Input.GetButtonDown("Fire1") ){
			_isFiring = true;
		}
	}
	
}