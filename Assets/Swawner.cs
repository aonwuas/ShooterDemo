using UnityEngine;
using System.Collections;

public class Swawner : MonoBehaviour {
	private GameObject _enemy;
    private float _duration;
    private float _delay;
	// Use this for initialization
	void Start () {
        this._enemy = (GameObject)Resources.Load("Prefabs/Enemy/Enemy");
        Destroy(this, _duration + _delay);
        InvokeRepeating("SpawnEnemy", _delay, _duration/10);
	}
	
    void Awake()
    {
        this._delay = 0f;
        this._duration = 5;
    }

	// Update is called once per frame
	void Update () {

	}
	void SpawnEnemy(){
		Rigidbody2D enemyInstance = Instantiate(_enemy, this.transform.position, Quaternion.identity) as Rigidbody2D;
	}
}
