﻿using UnityEngine;
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

    void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Enemy")
        {
            if (other.name.Equals("Chaser(Clone)"))
            {
                this.controller.DealDamage(other.gameObject.GetComponent<ChaseEnemy>(), this);
            }
            if (other.name.Equals("Enemy(Clone)")) {
                this.controller.DealDamage(other.gameObject.GetComponent<Enemy>(), this);
            }
            
            
        }
    }
}
