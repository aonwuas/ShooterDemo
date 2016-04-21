using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	GameInfo _gameInfo;

	private float _creationTime;
	private Vector2 _startPosition;
	public float _amplitude;
	public float _hSpeed;
	public float _vSpeed;
	public float _moveSpeed;
	public float _enemySpeed;
	public int _health;
	public float _timeScale;
	public int direction = 1;

	//public float _currentSpeed;

	void Awake(){
		_amplitude = 10.3f;




		_moveSpeed = 1f;
		_enemySpeed = 5f;
		_hSpeed = 5f;

		_gameInfo = GameObject.FindGameObjectWithTag("GameInfo").transform.GetComponent<GameInfo>();
	}

	// Use this for initialization
	void Start () {
		_health = _gameInfo._enemyBaseHealth * _gameInfo._difficultyLevel;
		_vSpeed = _gameInfo._difficultyLevel;
		_creationTime = Time.time;
		_startPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		setVelocity ();
	}

	public void Hurt(int damage){
		_health -= damage;
		if(_health <= 0){
			Debug.Log("I hath been slain!");
			Destroy(this.gameObject);
		}
	}

	void FixedUpdate() {

	}

	void setVelocity(){
		float deltaT = (Time.time - _creationTime);
		float lerped = Mathf.Lerp(0f, _amplitude, (1f + Mathf.Cos(_vSpeed * deltaT))/2f) - (_amplitude/2f);
		this.GetComponent<Rigidbody2D>().velocity = new Vector2(_vSpeed * lerped, -1f);

	}

	/*
	void lerp (float min, float max)
	{
		_currentSpeed = Mathf.Lerp (min, max, Time.time);
	}*/
}
