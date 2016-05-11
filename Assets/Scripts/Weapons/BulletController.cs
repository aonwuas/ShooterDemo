using UnityEngine;
using System.Collections;

public class BulletController : ProjectileController {
	public float cooldown;
	private float speed;
	GameInfo gameInfo;
    private int bulletfire;


	void Awaken(){

	}

	void Start(){
		this.instantiationObject = (GameObject)Resources.Load("Prefabs/Ship/Bullet");
		gameInfo = GameObject.FindGameObjectWithTag("GameInfo").transform.GetComponent<GameInfo>();
		damage = gameInfo.bulletDamage;
		speed = gameInfo.bulletSpeed;
        cooldown = gameInfo.bulletCooldown;
	}

	public void DealDamage(Enemy target, Bullet b){
		target.Hurt(this.damage);
		Destroy(b.gameObject);
	}

	public void FireBullet(Vector2 startPosition){
        Fire(startPosition, new Vector2(speed * 0f, speed));
        Fire(startPosition, new Vector2(speed / 5f, speed));
        Fire(startPosition, new Vector2(-speed/ 5f, speed));
        Fire(startPosition, new Vector2(speed / 10f, speed));
        Fire(startPosition, new Vector2(-speed/ 10f, speed));
	}

    private void Fire(Vector2 startPosition, Vector2 direction) {
        GameObject newBullet5 = GameObject.Instantiate(this.instantiationObject, startPosition, Quaternion.identity) as GameObject;
        newBullet5.GetComponent<Bullet>().setController(this);
        newBullet5.GetComponent<Rigidbody2D>().velocity = direction;
    }

	// Update is called once per frame
	void Update () {
	
	}
}
