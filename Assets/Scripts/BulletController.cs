using UnityEngine;
using System.Collections;

public class BulletController : ProjectileController {
	projectile_type type = projectile_type.BULLET;
	private int bulletLevel = 0;
	private float bulletLife = 5f;
	public float cooldown;
	private int speed;
	GameInfo _gameInfo;


	void Awaken(){

	}

	void Start(){
		this.instantiationObject = (GameObject)Resources.Load("Prefabs/Ship/Bullet");
		_gameInfo = GameObject.FindGameObjectWithTag("GameInfo").transform.GetComponent<GameInfo>();
		this.damage = _gameInfo._bulletBaseDamage;
		speed = _gameInfo._bulletSpeed;
		Upgrade();
	}

	public void DealDamage(Enemy target, Bullet b){
		target.Hurt(bulletLevel * this.damage);
		Destroy(b.gameObject);
	}

	public void Upgrade(){
		this.bulletLevel += 1;
		this.speed += 1;
		cooldown = 1f/(_gameInfo._bulletFireRate + bulletLevel);
	}

	public void FireBullet(Vector2 startPosition){
		GameObject newBullet = GameObject.Instantiate(this.instantiationObject, startPosition, Quaternion.identity) as GameObject;
		newBullet.GetComponent<Bullet>().setController(this);
		newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
