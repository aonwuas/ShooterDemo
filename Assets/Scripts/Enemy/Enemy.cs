using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	private float _creationTime;
	private Vector2 _startPosition;
	public float _amplitude;
	public float _vSpeed;
	public float _moveSpeed;
	public float _enemySpeed;

	void Awake(){
		_amplitude = 3f;
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
		 FollowPath();
	}

	void FollowPath(){
		float deltaT = Time.time - _creationTime;
		this.GetComponent<Rigidbody2D>().velocity = _enemySpeed * new Vector2(_amplitude * Mathf.Cos(deltaT), _vSpeed/_enemySpeed * 1f);
	}
}
