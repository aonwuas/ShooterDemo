using UnityEngine;
using System.Collections;


public class LaserGun : MonoBehaviour
{

    private LaserController controller;
    private GameInfo gameInfo;
    private PlayerInput input;
    private float aspeed = 2f;
    private ShipController shipControl;
    private float nextFire;


    void Start()
    {
        input = this.transform.GetComponentInParent<PlayerInput>();
        gameInfo = GameObject.FindGameObjectWithTag("GameInfo").transform.GetComponent<GameInfo>();
        controller = gameInfo.GetComponent<LaserController>();
    }

    void Awaken()
    {
        nextFire = 0f;
    }

    void FixedUpdate()
    {
  
        if (input._isFiring)
        {
            if (Time.time > nextFire)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 pPos = transform.position;
                controller.FireLaser(pPos, mousePos);
                nextFire = Time.time + controller.cooldown;
            }
            
        }

    }
}
