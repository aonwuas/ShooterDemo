using UnityEngine;
using System.Collections;



/*
 * Store basic info like base stats and difficulty levels
 * Current variables:
 * _difficultyLevel - controls in game scaling
 * _enemyBaseHealth - base health of enemy
 */
public class GameInfo : MonoBehaviour {
    //Game Variables
	public int _difficultyLevel;
    public int _scrollSpeed;

    //Enemy Variables
    public GameObject _enemySpawn;
    public int _enemyBaseHealth;
	public int _enemyBaseDamage;
    public int _enemyBaseSpeed;
	public int _enemyBaseScore;

    //Player Variables
    public int _bulletBaseDamage;
    public int _bulletLevel;
	public int _bulletSpeed;
    public int _bulletFireRate;
	public float _shipBaseHSpeed;
	public float _shipBaseVSpeed;
	public int _playerScore;
    
	void Start () {
	}

	void Awake(){
        //Game Variables
        _scrollSpeed = 1;
        _difficultyLevel = 1;

        //Enemy Variables
        _enemyBaseSpeed = 4;
		_enemyBaseHealth = 15;
		_enemyBaseDamage = 1;
		_enemyBaseScore = 2;

        //PlayerVariables
		_bulletBaseDamage = 5;
		_bulletLevel = 1;
		_bulletSpeed = 9;
        _bulletFireRate = 10;
		_shipBaseHSpeed = 40f;
		_shipBaseVSpeed = 20f;
		_playerScore = 0;

	}

    public void scrollSpeed(int speed = 1)
    {
        _scrollSpeed = speed;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
