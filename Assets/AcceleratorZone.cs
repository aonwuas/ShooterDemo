using UnityEngine;
using System.Collections;

public class AcceleratorZone : MonoBehaviour {
    GameInfo _gameInfo;
    int _speedModifier;

    void Awake()
    {
        _gameInfo = GameObject.FindGameObjectWithTag("GameInfo").transform.GetComponent<GameInfo>();
        _speedModifier = 1;
        if(this.name == "SpeedUpZone")
        {
            _speedModifier = 2;
        }
        if (this.name == "SlowDownZone")
        {
            _speedModifier = 0;
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            _gameInfo.scrollSpeed(_speedModifier);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            _gameInfo.scrollSpeed();
        }
    }
}
