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
    GameObject[] UIElements;
    GameObject healthBarUIElement;
    GameObject scoreUIElement;

    //Enemy Variables
    public GameObject _enemySpawn;
    public int enemyHealth;
    public int enemyDamage;
    public int enemySpeed;
    public int enemyScore;

    //Bullet Variables
    public float bulletSpeed;
    public float bulletDamage;
    public float bulletCooldown;
    
    //Laser Variables
    public float laserSpeed;
    public float laserDamage;
    public float laserCooldown;

    //Rocket Variables
    public float rocketSpeed;
    public float rocketDamage;
    public float targetAcquisitionTime;


    //Player Variables
    public float shipHSpeed;
    public float shipVSpeed;
    public float playerScore;
    public float playerHealth;
    public int playerCurrency;


    void Awake() {
        //Game Variables
        _scrollSpeed = 1;
        _difficultyLevel = 1;

        //Enemy Variables
        enemySpeed = 4;
        enemyHealth = 15;
        enemyDamage = 1;
        enemyScore = 2;

        //PlayerVariables
        bulletDamage = 5;
        bulletSpeed = 80;
        bulletCooldown = 1;
        shipHSpeed = 40f;
        shipVSpeed = 20f;
        playerScore = 0;
        playerHealth = 100;
        playerCurrency = 0;

        //Laser Variables
        laserSpeed = 40;
        laserDamage = 30;
        laserCooldown = 0.5f;

    }

    public void scrollSpeed(int speed = 1)
    {
        _scrollSpeed = speed;
    }

    // Update is called once per frame
    void Update() {

    }

    void Start()
    {
        UIElements = GameObject.FindGameObjectsWithTag("UI");
        
        foreach(GameObject Element in UIElements)
        {
            switch (Element.name)
            {
                case "Score":
                    scoreUIElement = Element; break;
                case "HealthBar":
                    healthBarUIElement = Element; break;
            }
        }
        healthBarUIElement.GetComponent<UnityEngine.UI.Slider>().value = playerHealth;
        healthBarUIElement.GetComponentsInChildren<UnityEngine.UI.Text>()[0].text = playerHealth.ToString();
        scoreUIElement.GetComponent<UnityEngine.UI.Text>().text = playerScore.ToString();
    }

    public void addPoints(Enemy e)
    {
        playerScore += e.pointValue;
        playerCurrency += e.pointValue;
        scoreUIElement.GetComponent<UnityEngine.UI.Text>().text = playerScore.ToString();
    }
    public void adjustHealth(Enemy e)
    {
        playerHealth -= e.damage;
        healthBarUIElement.GetComponent<UnityEngine.UI.Slider>().value = playerHealth;
        healthBarUIElement.GetComponentsInChildren<UnityEngine.UI.Text>()[0].text = playerHealth.ToString();
    }

    public float relativeAngle(Vector2 from, Vector2 to)
    {
        Vector2 diff = (from - to).normalized;
        float angle = Vector2.Angle(diff, Vector2.down);
        float cross = Vector3.Cross(diff, Vector2.down).normalized.z;
        if (cross > 0)
        {
            angle = 360 - angle;
        }
        return angle;
    }
    
}
