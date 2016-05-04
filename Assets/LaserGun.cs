using UnityEngine;
using System.Collections;


public class LaserGun : MonoBehaviour
{

    private LaserController controller;
    private GameInfo gameInfo;
    private PlayerInput input;
    //private Animator animator;
    private float aspeed = 2f;
    private ShipController shipControl;
    private float nextFire;


    void Start()
    {
        input = this.transform.GetComponentInParent<PlayerInput>();
        shipControl = this.transform.GetComponentInParent<ShipController>();
        //this.animator = this.GetComponent<Animator>();
        gameInfo = GameObject.FindGameObjectWithTag("GameInfo").transform.GetComponent<GameInfo>();
        controller = gameInfo.GetComponent<LaserController>();
        //this.animator.speed = aspeed;
    }

    void Awaken()
    {
        nextFire = 0;
    }

    void FixedUpdate()
    {
  
        if (input._isFiring)
        {
                controller.FireLaser(this.transform.position, Input.mousePosition);
                nextFire = Time.time + controller.cooldown;
        }

    }
}
