﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    GameInfo gameInfo;
    public float damage;
    public int pointValue;
    private Vector2 _startPosition;
    public float _amplitude;
	public float _enemySpeed;
    public float _health;
    public bool _vulnerable = false;
    float vertExtent, horzExtent;
    MovementPattern.ZigZagPattern move;

    //public float _currentSpeed;

    void Awake()
    {
        _amplitude = 10.3f;
        gameInfo = GameObject.FindGameObjectWithTag("GameInfo").transform.GetComponent<GameInfo>();
    }

    // Use this for initialization
    void Start()
    {
        vertExtent = Camera.main.orthographicSize;
        horzExtent = vertExtent * Screen.width / Screen.height;
        _health = gameInfo.enemyHealth * gameInfo._difficultyLevel;
		_enemySpeed = gameInfo._difficultyLevel * gameInfo.enemySpeed;
        _startPosition = this.transform.position;
        damage = 5;
        pointValue = 5;
        move = new MovementPattern.ZigZagPattern(80, 15, 25, this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        move.Move();
        if (!_vulnerable)
        {
            if (transform.position.x >= -horzExtent && transform.position.x <= horzExtent && transform.position.y >= -vertExtent && transform.position.y <= vertExtent)
            {
                _vulnerable = true;
            }
        }
    }

    public void Hurt(float damage)
    {
        if (this._vulnerable) { _health -= damage; }
        if (_health <= 0){
			Die();
        }
    }
    
    void FixedUpdate()
    {

    }

	private void Die(){
        gameInfo.addPoints(this);
		Destroy(this.gameObject);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameInfo.adjustHealth(this);
        }
    }
}
