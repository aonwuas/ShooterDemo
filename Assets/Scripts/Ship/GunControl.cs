﻿using UnityEngine;
using System.Collections;

public class GunControl : MonoBehaviour
{
    public PlayerInput _playerInput;
    private GameObject projectile;
    public GameObject[] _hardpoints;
    private GameInfo _gameInfo;
    private float firingDelay;
    private float nextShot;
    // Use this for initialization
    void Start()
    {
        _playerInput = transform.GetComponentInParent<PlayerInput>();
        _hardpoints = GameObject.FindGameObjectsWithTag("Gun");
        this.projectile = (GameObject)Resources.Load("Prefabs/Ship/Bullet");
        _gameInfo = GameObject.FindGameObjectWithTag("GameInfo").transform.GetComponent<GameInfo>();
        firingDelay = 1f / _gameInfo._bulletFireRate;
        nextShot = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FireController();
    }

    void Update()
    {
        
    }


    void FireController()
    {
        if (_playerInput._isFiring)
        {
            if (Time.time >= nextShot)
            {
                foreach (GameObject g in _hardpoints)
                {
                    g.GetComponent<Animator>().speed = 3;
                    FireProjectile(g);

                }
                nextShot = Time.time + firingDelay;
            }
        }
        else
        {
            foreach (GameObject g in _hardpoints)
            {
                g.GetComponent<Animator>().speed = 1;

            }
        }
    }

    void FireProjectile(GameObject g)
    {
        Rigidbody2D projectileInstance = Instantiate(projectile, g.transform.position, Quaternion.identity) as Rigidbody2D;
    }
}
