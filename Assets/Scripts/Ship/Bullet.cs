using UnityEngine;
using System.Collections;

public class Bullet : Projectile {
	public int _type = (int)_projectile_type.BULLET;
	public float _bulletVelocity;
	public float _lifeTime;


	void Awake() {
		_lifeTime = 2f;
		_bulletVelocity = 15f;
		
	}


	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, _lifeTime);
		this.GetComponent<Rigidbody2D> ().velocity  = new Vector2 (0, _bulletVelocity);
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)	{

		if( other.tag == "Enemy" ){
			Destroy(other.gameObject);
			Destroy(this.gameObject);
		}
	}

}
		