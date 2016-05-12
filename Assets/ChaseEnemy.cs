using UnityEngine;
using System.Collections;

public class ChaseEnemy : Enemy {

    GameInfo gameInfo;
    public float damage;
    new public int pointValue;
    private Vector2 _startPosition;
    new public float _enemySpeed;
    new public float _health;
    public bool _vulnerable = false;
    float vertExtent, horzExtent;
    MovementPattern.TargetedPattern tmove;

    void Awake()
    {
        gameInfo = GameObject.FindGameObjectWithTag("GameInfo").transform.GetComponent<GameInfo>();
    }


	// Use this for initialization
	void Start () {
        _health = Mathf.Ceil(gameInfo.enemyHealth * gameInfo._difficultyLevel / 5f);
        damage = 1;
        pointValue = 2;
        vertExtent = Camera.main.orthographicSize;
        horzExtent = vertExtent * Screen.width / Screen.height;
        tmove = new MovementPattern.TargetedPattern(30, 1f, this.gameObject, GameObject.FindGameObjectWithTag("Player"));
	}
	
	// Update is called once per frame
	void Update () {
        tmove.Move();
        if (!_vulnerable)
        {
            if (transform.position.x >= -horzExtent && transform.position.x <= horzExtent && transform.position.y >= -vertExtent && transform.position.y <= vertExtent)
            {
                _vulnerable = true;
            }
        }
	}

    private void Die()
    {
        gameInfo.addPoints(this.GetComponent<ChaseEnemy>());
        Destroy(this.gameObject);
    }


    new public void Hurt(float damage)
    {
        if (this._vulnerable) { _health -= damage; }
        if (_health <= 0)
        {
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameInfo.adjustHealth(this);
        }
    }
}
