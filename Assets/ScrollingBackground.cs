using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour {
    GameObject backgroundObject = (GameObject)Resources.Load("Prefabs/BackGround");



    private class Background
    {
        Rigidbody2D parent;
        GameObject thisGameObject;
        public Background(Rigidbody2D parent, GameObject g)
        {
            this.parent = parent;
            thisGameObject = g;
        }
        float getTopY()
        {
            return thisGameObject.GetComponent<SpriteRenderer>().bounds.max.y;
        }
        float getHalfHeight()
        {
            return thisGameObject.GetComponent<SpriteRenderer>().bounds.extents.y;
        }
    }





    bool alreadySpawned;
	// Use this for initialization

    void Awake()
    {

        alreadySpawned = false;
    }
	void Start () {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.down * 30;

    }
	
	// Update is called once per frame

        /*
	void Update () {
        SpriteRenderer rend = this.GetComponent<SpriteRenderer>();
       
        float b = rend.bounds.max.y;
        if (b <= 45 && !alreadySpawned)
        {
            alreadySpawned = true;
            background = GameObject.Instantiate(background);
            background.GetComponent<Rigidbody2D>().position = new Vector2(0, b + rend.bounds.extents.y);
        }
        if (b <= -90)
        {
            Destroy(this.gameObject);
        }
    }
    */
}
