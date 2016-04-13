using UnityEngine;
using System.Collections;

public class Bullet : Projectile {
	public int _type = (int)_projectile_type.BULLET;
	public float _bulletVelocity;
	public int lifeTime;
	// Use this for initialization
	void Start () {
		this.lifeTime = 1;
		this._bulletVelocity = 15f;
		destroyThis(lifeTime);
		this.GetComponent<Rigidbody2D> ().velocity  = new Vector2 (0, _bulletVelocity);
	}

	void Awake() {

	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnCollision2D(Collider2D other){
		if( other.tag == "enemy" ){
			destroyThis ();
		}
	}



	void destroyThis(int duration = 0){
		Destroy(this.gameObject, duration);
	}
}
		