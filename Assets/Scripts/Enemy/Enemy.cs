using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	private float _creationTime;
	private Vector2 _startPosition;
	public float _amplitude;
	public float _vSpeed;
	public float _moveSpeed;
	public float _enemySpeed;
	public int _alt;
	public float _timeScale;

	//public float _currentSpeed;

	void Awake(){
		_alt = 0;
		_amplitude = 10f;
		_vSpeed = -1f;
		_moveSpeed = 1f;
		_enemySpeed = 5f;
	}

	// Use this for initialization
	void Start () {
		_creationTime = Time.time;
		_startPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Hurt(){

	}

	void FixedUpdate() {
		float deltaT = (Time.time - _creationTime)*5f;
		//this.transform.position.x = _startPosition.x + Mathf.Cos (deltaT);
		this.transform.position = new Vector2 (Mathf.Clamp(_startPosition.x + Mathf.Cos(deltaT) * _amplitude, -5, 5), _startPosition.y);
		//FollowPath ();

	}

	void FollowPath(){
		float deltaT = (Time.time - _creationTime)*5f;
		this.GetComponent<Rigidbody2D>().velocity = _enemySpeed * new Vector2(_amplitude * Mathf.Cos(deltaT), _vSpeed/_enemySpeed * 5f);
	}

	/*
	void lerp (float min, float max)
	{
		_currentSpeed = Mathf.Lerp (min, max, Time.time);
	}*/
}
