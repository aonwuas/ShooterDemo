using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	public float _hMove, _vMove;
	public bool _isFiring = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		HorizontalMovement();
		CheckFire();
	}

	public void HorizontalMovement(){
		_hMove = Input.GetAxis("Horizontal");
		_vMove = Input.GetAxis("Vertical");
	}
	private void CheckFire(){
		if (Input.GetMouseButton (0)) {
			_isFiring = true;
		}
		else {
			_isFiring = false;
		}
	}
	
}
