using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour {
    GameObject currentBackground, prevBackground, backgroundObject, scheduledDeleteBackground;
    

    void Awake()
    {
        backgroundObject = (GameObject)Resources.Load("Prefabs/BackGround");
    }

    GameObject createNewBackground(float newY)
    {
        GameObject newBackground = Instantiate(backgroundObject, new Vector3(0, newY, 0), Quaternion.identity) as GameObject;
        newBackground.GetComponent<Rigidbody2D>().velocity = Vector2.down * 30;
        return newBackground;
    }

	void Start () {
        currentBackground = createNewBackground(0);
    }
    void Update()
    {
        Bounds myBounds = currentBackground.GetComponent<SpriteRenderer>().bounds;
        if (myBounds.extents.y + myBounds.center.y < Camera.main.orthographicSize + 20)
        {
            Destroy(prevBackground);
            prevBackground = currentBackground;
            currentBackground = createNewBackground(Camera.main.orthographicSize + myBounds.extents.y + 17);
        }
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
