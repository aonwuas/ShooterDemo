using UnityEngine;
using System.Collections;

public class Laser : ProjectileController
{
    GameInfo _gameInfo;
    public int _type = (int)projectile_type.LASER;
    private LaserController controller;


    public void setController(LaserController controller)
    {
        this.controller = controller;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Enemy")
        {
            this.controller.DealDamage(other.gameObject.GetComponent<Enemy>(), this);
        }
    }
}
