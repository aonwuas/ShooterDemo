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

    //Player Variables
    public int _bulletBaseDamage;
    public int _bulletLevel;
    
	void Start () {
	}

	void Awake(){

        //Game Variables
        _scrollSpeed = 1;
        _difficultyLevel = 1;

        //Enemy Variables
        _enemyBaseSpeed = 1;
		_enemyBaseHealth = 15;
		_enemyBaseDamage = 1;

        //PlayerVariables
		_bulletBaseDamage = 5;
		_bulletLevel = 1;
	}

    public void scrollSpeed(int speed = 1)
    {
        _scrollSpeed = speed;
        //Debug.Log("Scrollspeed is set to " + _scrollSpeed);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
