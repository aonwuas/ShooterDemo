using UnityEngine;
using System.Collections;

public class Rocket : ProjectileController
{
    GameInfo gameInfo;
    public int _type = (int)projectile_type.LASER;
    private RocketController controller;
    MovementPattern.TargetedPattern movementScript;
    Enemy e;


    public void setController(RocketController controller)
    {
        this.controller = controller;
    }

    void FixedUpdate()
    {
        //movementScript.Move();
        //this.transform.rotation = Quaternion.AngleAxis(gameInfo.relativeAngle(transform.position, findClosestEnemy()), new Vector3(0, 0, 1));
    }

    void Start()
    {
        //movementScript = new MovementPattern.TargetedPattern(10f, gameInfo.rocketTurn, this.gameObject, );
        gameInfo = GameObject.FindGameObjectWithTag("GameInfo").transform.GetComponent<GameInfo>();
        Destroy(this.gameObject, 7f);
    }

    /*Enemy findClosestEnemy()
    {
        
    }*/

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Enemy")
        {
            this.controller.DealDamage(other.gameObject.GetComponent<Enemy>(), this);
        }
    }
}
