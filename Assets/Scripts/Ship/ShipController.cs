using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {
	public PlayerInput _playerInput;
    static GameInfo _gameInfo;
	public static float _hMoveSpeed;
	public static float _vMoveSpeed;
	public float _scrollSpeed;
    float vertExtent;
    float horzExtent;


	// Use this for initialization

	void Awake(){

	}
	void Start () {
        vertExtent = Camera.main.orthographicSize;
        horzExtent = vertExtent * Screen.width / Screen.height;
		_gameInfo = GameObject.FindGameObjectWithTag("GameInfo").transform.GetComponent<GameInfo>();
		_playerInput = transform.GetComponent<PlayerInput>();
		_hMoveSpeed = _gameInfo.shipHSpeed;
		_vMoveSpeed = _gameInfo.shipVSpeed;
		_scrollSpeed = _gameInfo._scrollSpeed;
	}

    public static void recalcSpeed()
    {
        _hMoveSpeed = _gameInfo.shipHSpeed;
        _vMoveSpeed = _gameInfo.shipVSpeed;
    }


	void FixedUpdate () {
        float playerHMove = _playerInput._hMove;
        float playerVMove = _playerInput._vMove;
        Vector2 thing = GetComponent<Rigidbody2D>().position.normalized/20f;
        if (GetComponent<Rigidbody2D>().position.y > vertExtent -1 || GetComponent<Rigidbody2D>().position.y < -vertExtent + 1)
        {
            playerVMove = -thing.y;
        }


        if (GetComponent<Rigidbody2D>().position.x > horzExtent - 1 || GetComponent<Rigidbody2D>().position.x < -horzExtent + 1)
        {
            playerHMove = -thing.x;
        }
            
		GetComponent<Rigidbody2D>().velocity = new Vector2(playerHMove * _hMoveSpeed, playerVMove * _vMoveSpeed);
	}


	// Update is called once per frame
	void Update () {
	
	}
}
