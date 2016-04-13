using UnityEngine;
using System.Collections;

public class Bullet : Projectile {
	public int _type = (int)_projectile_type.BULLET;
	public float _bulletVelocity = 20f;
	public int lifeTime = 5;
	// Use this for initialization
	void Start () {
		destroyThis(lifeTime);
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
		