using UnityEngine;
using System.Collections;

public class SpawnAreaController : MonoBehaviour {
    private Bounds _boundingSpace;
    private GameObject _spawner;
	// Use this for initialization
	void Start () {
        this._spawner = (GameObject)Resources.Load("Prefabs/Enemy/Spawner");
        InvokeRepeating("Spawn", 2f, 3f);
    }

    void Awake()
    {
        this._boundingSpace = GetComponent<BoxCollider2D>().bounds;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Enemy p = other.GetComponent<Enemy>();
            p._vulnerable = true;
        }
    }

    void Spawn()
    {
        Vector2 spawnPoint = new Vector2(this.transform.position.x, Random.Range(_boundingSpace.min.y, _boundingSpace.max.y));
        GameObject spawn = Instantiate(_spawner, spawnPoint, Quaternion.identity) as GameObject;
    }
}
