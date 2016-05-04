using UnityEngine;
using System.Collections;

public class BulletController : ProjectileController {
	projectile_type type = projectile_type.BULLET;
	private int bulletLevel = 0;
	private float bulletLife = 5f;
	public float cooldown;
	private int speed;
	GameInfo _gameInfo;
    private int bulletfire;


	void Awaken(){

	}

	void Start(){
		this.instantiationObject = (GameObject)Resources.Load("Prefabs/Ship/Bullet");
		_gameInfo = GameObject.FindGameObjectWithTag("GameInfo").transform.GetComponent<GameInfo>();
		this.damage = _gameInfo._bulletBaseDamage;
		speed = _gameInfo._bulletSpeed * 2;
		Upgrade();
	}

	public void DealDamage(Enemy target, Bullet b){
		target.Hurt(bulletLevel * this.damage);
		Destroy(b.gameObject);
	}

	public void Upgrade(){
		this.bulletLevel += 1;
		this.speed += 1;
		cooldown = 3.5f/(_gameInfo._bulletFireRate + bulletLevel);
	}

	public void FireBullet(Vector2 startPosition){
		GameObject newBullet = GameObject.Instantiate(this.instantiationObject, startPosition, Quaternion.identity) as GameObject;
		newBullet.GetComponent<Bullet>().setController(this);
		newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);

        GameObject newBullet2 = GameObject.Instantiate(this.instantiationObject, startPosition, Quaternion.identity) as GameObject;
        newBullet2.GetComponent<Bullet>().setController(this);
        newBullet2.GetComponent<Rigidbody2D>().velocity = new Vector2(speed/5f, speed);

        GameObject newBullet3 = GameObject.Instantiate(this.instantiationObject, startPosition, Quaternion.identity) as GameObject;
        newBullet3.GetComponent<Bullet>().setController(this);
        newBullet3.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed/5f, speed);

        GameObject newBullet4 = GameObject.Instantiate(this.instantiationObject, startPosition, Quaternion.identity) as GameObject;
        newBullet4.GetComponent<Bullet>().setController(this);
        newBullet4.GetComponent<Rigidbody2D>().velocity = new Vector2(speed / 10f, speed);

        GameObject newBullet5 = GameObject.Instantiate(this.instantiationObject, startPosition, Quaternion.identity) as GameObject;
        newBullet5.GetComponent<Bullet>().setController(this);
        newBullet5.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed / 10f, speed);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
