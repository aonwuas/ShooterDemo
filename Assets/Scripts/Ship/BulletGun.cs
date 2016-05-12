using UnityEngine;
using System.Collections;


public class BulletGun : MonoBehaviour {

	private BulletController controller;
	private GameInfo gameInfo;
	private PlayerInput input;
	private ShipController shipControl;
	private float nextFire;


	void Start(){
		input = this.transform.GetComponentInParent<PlayerInput>();
		shipControl = this.transform.GetComponentInParent<ShipController>();
		gameInfo = GameObject.FindGameObjectWithTag("GameInfo").transform.GetComponent<GameInfo>();
		controller = gameInfo.GetComponent<BulletController>();
	}

	void Awaken () {
		nextFire = 0;
	}

	void FixedUpdate () {
		if(input._isFiring){
            if (Time.time > nextFire)
            {

                controller.FireBullet(this.transform.position);
                nextFire = Time.time + gameInfo.bulletCooldown;
            }

		}
	}
}
