using UnityEngine;
using System.Collections;

public class Bullet : ProjectileController {
    GameInfo _gameInfo;
	private BulletController controller;


	public void setController(BulletController controller){
		this.controller = controller;
	}

    void Start()
    {
        Destroy(this.gameObject, 5f);
    }

	void OnTriggerEnter2D(Collider2D other)	{

		if( other.tag == "Enemy" ){
			this.controller.DealDamage(other.gameObject.GetComponent<Enemy>(), this);
		}
	}
}
		