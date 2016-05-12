using UnityEngine;
using System.Collections;

public class ChaserSpawner : MonoBehaviour {

    private GameObject _enemy;
    private float _duration;
    private float _delay;
    // Use this for initialization
    void Start()
    {
        this._enemy = (GameObject)Resources.Load("Prefabs/Enemy/Chaser");
        Destroy(this, _duration + _delay);
        InvokeRepeating("SpawnEnemy", _delay, _duration/2);
    }

    void Awake()
    {
        this._delay = 0f;
        this._duration = 10;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnEnemy()
    {
        Instantiate(_enemy, this.transform.position, Quaternion.identity);
    }
}
