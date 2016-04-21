using UnityEngine;
using System.Collections;



/*
 * Store basic info like base stats and difficulty levels
 * Current variables:
 * _difficultyLevel - controls in game scaling
 * _enemyBaseHealth - base health of enemy
 */
public class GameInfo : MonoBehaviour {
	public int _difficultyLevel;
	public int _enemyBaseHealth;
	public int _enemyBaseDamage;
	public int _bulletBaseDamage;
	public int _bulletLevel;
	// Use this for initialization
	void Start () {
	}

	void Awake(){
		_difficultyLevel = 1;
		_enemyBaseHealth = 15;
		_enemyBaseDamage = 1;
		_bulletBaseDamage = 5;
		_bulletLevel = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
