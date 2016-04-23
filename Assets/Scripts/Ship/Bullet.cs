using UnityEngine;
using System.Collections;

public class Bullet : Projectile {
    GameInfo _gameInfo;
	public int _type = (int)_projectile_type.BULLET;
	public float _bulletVelocity;
	public float _lifeTime;
	public int _bulletDamage;


	void Awake() {
        _gameInfo = GameObject.FindGameObjectWithTag("GameInfo").transform.GetComponent<GameInfo>();
        _lifeTime = 2f;
		_bulletVelocity = 15f;
		_bulletDamage = 10;

		
	}


	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, _lifeTime);
		//_bulletDamage = _gameInfo._bulletBaseDamage * _gameInfo._bulletLevel;
		this.GetComponent<Rigidbody2D> ().velocity  = new Vector2 (0, _bulletVelocity);

	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)	{

		if( other.tag == "Enemy" ){
			other.gameObject.GetComponent<Enemy>().Hurt(_bulletDamage);
			Destroy(this.gameObject);
		}
	}

}
		