using UnityEngine;
using System.Collections;


public class BulletGun : MonoBehaviour {

	private BulletController controller;
	private GameInfo gameInfo;
	private PlayerInput input;
	private Animator animator;
	private float aspeed = 2f;
	private ShipController shipControl;
	private float nextFire;


	void Start(){
		input = this.transform.GetComponentInParent<PlayerInput>();
		shipControl = this.transform.GetComponentInParent<ShipController>();
		this.animator = this.GetComponent<Animator>();
		gameInfo = GameObject.FindGameObjectWithTag("GameInfo").transform.GetComponent<GameInfo>();
		controller = gameInfo.GetComponent<BulletController>();
		this.animator.speed =aspeed;
	}

	void Awaken () {
		nextFire = 0;
	}

	void FixedUpdate () {

		this.animator.speed = aspeed;
		if(input._isFiring){
			this.animator.speed = aspeed;
			aspeed = Mathf.Clamp(aspeed + 2, 0, 12f);
			if(Time.time > nextFire && shipControl._hMoveSpeed == 0 && shipControl._vMoveSpeed == 0){

				controller.FireBullet(this.transform.position);
				nextFire = Time.time + controller.cooldown;
			}
			else{
				shipControl._hMoveSpeed = Mathf.Clamp(shipControl._hMoveSpeed - 0.5f, 0, gameInfo._shipBaseHSpeed);
				shipControl._vMoveSpeed = Mathf.Clamp(shipControl._vMoveSpeed - 0.5f, 0, gameInfo._shipBaseVSpeed);
			}
		}
		else{

			aspeed = Mathf.Clamp(aspeed - 2, 0, 12f);
			/*if(shipControl._hMoveSpeed == gameInfo._shipBaseHSpeed && shipControl._vMoveSpeed == gameInfo._shipBaseVSpeed){
				this.animator.speed = 0f;
			}
			else{
				this.animator.speed = 2f;
			}*/
			shipControl._hMoveSpeed = Mathf.Clamp(shipControl._hMoveSpeed + 0.1f, 0, gameInfo._shipBaseHSpeed);
			shipControl._vMoveSpeed = Mathf.Clamp(shipControl._vMoveSpeed + 0.1f, 0, gameInfo._shipBaseVSpeed);
		}

	}
}
