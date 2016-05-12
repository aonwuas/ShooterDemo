using UnityEngine;
using System.Collections;

public class SpawnAreaController : MonoBehaviour {
    private Bounds _boundingSpace;
    private GameObject _spawner, chaseSpawner;
    float vertExtent, horzExtent;
	// Use this for initialization
	void Start () {
        vertExtent = Camera.main.orthographicSize;
        horzExtent = vertExtent * Screen.width / Screen.height;
        this._spawner = (GameObject)Resources.Load("Prefabs/Enemy/Spawner");
        this.chaseSpawner = (GameObject)Resources.Load("Prefabs/Enemy/ChaserSpawn");
        InvokeRepeating("Spawn", 2f, 6f);
    }

    void Awake()
    {
        this._boundingSpace = GetComponent<BoxCollider2D>().bounds;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Spawn()
    {
        float f = Random.value;
        if (f >=0.2f)
        {
            Vector2 spawnPoint = new Vector2(Random.Range(-horzExtent + 12, horzExtent -12), Random.Range(vertExtent +1, vertExtent + 10));
            GameObject spawn = Instantiate(_spawner, spawnPoint, Quaternion.identity) as GameObject;
        }
        else
        {
            float randx = Random.Range(horzExtent + 1, horzExtent + 10);
            float negRandx = Random.Range(-horzExtent - 1, -horzExtent - 10);
            Vector2 spawnA = new Vector2(randx, Random.Range(0, vertExtent + 10));
            GameObject spawnedA = Instantiate(chaseSpawner, spawnA, Quaternion.identity) as GameObject;
            
            
            Vector2 spawnB = new Vector2(negRandx, Random.Range(0, vertExtent + 10));
            GameObject spawnedB = Instantiate(chaseSpawner, spawnB, Quaternion.identity) as GameObject;
        }
    }
}
