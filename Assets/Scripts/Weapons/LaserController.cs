using UnityEngine;
using System.Collections;

public class LaserController : ProjectileController
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

    public void DealDamage(Enemy target, Laser b)
    {
        target.Hurt(this.damage);
        Destroy(b.gameObject);
    }

    public void FireLaser(Vector2 startPosition, Vector2 targetPosition)
    {

        
        GameObject newBullet = GameObject.Instantiate(this.instantiationObject, startPosition, Quaternion.identity) as GameObject;
        newBullet.GetComponent<Laser>().setController(this);    
        newBullet.GetComponent<Rigidbody2D>().velocity = speed * (targetPosition-startPosition).normalized;
        newBullet.transform.rotation = Quaternion.AngleAxis(gameInfo.relativeAngle(startPosition, targetPosition), new Vector3(0, 0, 1));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
