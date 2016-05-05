using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    GameInfo gameInfo;
    public float damage;
    public int pointValue;
    private float _creationTime;
    private Vector2 _startPosition;
    public float _amplitude;
	public float _enemySpeed;
    public float _health;
    public bool _vulnerable = false;
    MovementPattern.ZigZagPattern move;
    MovementPattern.TargetedPattern tmove;

    //public float _currentSpeed;

    void Awake()
    {

        _amplitude = 10.3f;
        gameInfo = GameObject.FindGameObjectWithTag("GameInfo").transform.GetComponent<GameInfo>();
    }

    // Use this for initialization
    void Start()
    {
        _health = gameInfo.enemyHealth * gameInfo._difficultyLevel;
		_enemySpeed = gameInfo._difficultyLevel * gameInfo.enemySpeed;
        _creationTime = Time.time;
        _startPosition = this.transform.position;
        damage = 5;
        pointValue = 5;
        move = new MovementPattern.ZigZagPattern(80, 15, 25, this.gameObject);
        tmove = new MovementPattern.TargetedPattern(10, 1, this.gameObject, GameObject.FindGameObjectWithTag("Player"));
    }

    // Update is called once per frame
    void Update()
    {
        //move.Move();
        tmove.Move();
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
