using UnityEngine;
using System.Collections;

public class Bullet : ProjectileController {
    GameInfo _gameInfo;
	public int _type = (int)projectile_type.BULLET;
	private BulletController controller;


	public void setController(BulletController controller){
		this.controller = controller;
	}

	void OnTriggerEnter2D(Collider2D other)	{

		if( other.tag == "Enemy" ){
			this.controller.DealDamage(other.gameObject.GetComponent<Enemy>(), this);
		}
	}
}
		