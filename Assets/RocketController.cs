using UnityEngine;
using System.Collections;

public class RocketController : ProjectileController
{
    public float cooldown;
    private float speed;
    GameInfo gameInfo;


    void Awaken()
    {

    }

    void Start()
    {
        this.instantiationObject = (GameObject)Resources.Load("Prefabs/Ship/Laser");
        gameInfo = GameObject.FindGameObjectWithTag("GameInfo").transform.GetComponent<GameInfo>();
        damage = gameInfo.laserDamage;
        speed = gameInfo.laserSpeed;
        cooldown = gameInfo.laserCooldown;
    }

    public void DealDamage(Enemy target, Rocket r)
    {
        target.Hurt(this.damage);
        Destroy(r.gameObject);
    }

    public void FireRocket(Vector2 startPosition, Vector2 targetPosition)
    {
        cooldown = gameInfo.laserCooldown;
        speed = gameInfo.laserSpeed;
        GameObject newBullet = GameObject.Instantiate(this.instantiationObject, startPosition, Quaternion.identity) as GameObject;
        newBullet.GetComponent<Rocket>().setController(this);
        newBullet.GetComponent<Rigidbody2D>().velocity = speed * (targetPosition - startPosition).normalized;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
