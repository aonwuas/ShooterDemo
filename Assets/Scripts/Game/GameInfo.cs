using UnityEngine;
using System.Collections;



/*
 * Store basic info like base stats and difficulty levels
 * Current variables:
 * _difficultyLevel - controls in game scaling
 * _enemyBaseHealth - base health of enemy
 */
 
public class GameInfo : MonoBehaviour
{


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
    public float bulletSpeedPerLevel;
    public float bulletDamagePerLevel;
    public float bulletCooldownPerLevel;
    public int bulletSpeedLevel;
    public int bulletDamageLevel;
    public int bulletCooldownLevel;
    public struct bulletBase
    {
        public float baseSpeed;
        public float baseDamage;
        public float baseCooldown;
    }
    public bulletBase b;




    //Laser Variables
    public float laserSpeed;
    public float laserDamage;
    public float laserCooldown;
    public float laserSpeedPerLevel;
    public float laserDamagePerLevel;
    public float laserCooldownPerLevel;
    public int laserSpeedLevel;
    public int laserDamageLevel;
    public int laserCooldownLevel;
    public struct laserBase
    {
        public float baseSpeed;
        public float baseDamage;
        public float baseCooldown;
    }
    public laserBase l;




    //Rocket Variables
    public float rocketTurn;
    public float rocketArea;
    public float rocketCooldown;
    public float rocketTurnPerLevel;
    public float rocketAreaPerLevel;
    public float rocketCooldownPerLevel;
    public int rocketTurnLevel;
    public int rocketAreaLevel;
    public int rocketCooldownLevel;
    public struct rocketBase
    {
        public float baseTurn;
        public float baseArea;
        public float baseCooldown;
    }
    public rocketBase r;


    //Player Variables
    public int playerCurrency;
    public float playerScore;

    //Ship Variables
    public float shipHSpeed;
    public float shipVSpeed;
    public float shipHealth;
    public float shipHPerLevel;
    public float shipVPerLevel;
    public float shipHealthPerLevel;
    public int shipSpeedLevel;
    public int shipHealthLevel;
    public struct shipBase
    {
        public float vSpeed;
        public float hSpeed;
        public int baseHealth;
    }
    public shipBase s;


    void Awake()
    {
        //Game Variables
        _scrollSpeed = 1;
        _difficultyLevel = 1;

        //Enemy Variables
        enemySpeed = 4;
        enemyHealth = 15;
        enemyDamage = 1;
        enemyScore = 2;

        //Ship Variables
        shipHSpeed = s.hSpeed = 40f;
        shipVSpeed = s.vSpeed = 20f;
        shipHealth = s.baseHealth = 100;
        shipHPerLevel = 4f;
        shipVPerLevel = 2f;
        shipHealthPerLevel = 10f;
        shipSpeedLevel = 1;
        shipHealthLevel = 1;



        //Player Variables
        playerScore = 0;
        playerCurrency = 0;


        //Bullet Variables
        bulletSpeed = b.baseSpeed = 40;
        bulletDamage = b.baseDamage = 5f;
        bulletCooldown = b.baseCooldown = 1;
        bulletSpeedPerLevel = 4f;
        bulletDamagePerLevel = 1f;
        bulletCooldownPerLevel = 0.9f;
        bulletSpeedLevel = 1;
        bulletDamageLevel = 1;
        bulletCooldownLevel = 1;




        //Laser Variables
        laserSpeed = l.baseSpeed = 80;
        laserDamage = l.baseDamage = 30;
        laserCooldown = l.baseCooldown = 0.5f;
        laserSpeedPerLevel = 8f;
        laserDamagePerLevel = 3f;
        laserCooldownPerLevel = 0.6f;
        laserSpeedLevel = 1;
        laserDamageLevel = 1;
        laserCooldownLevel = 1;

        //Rocket Variables
        rocketTurn = r.baseTurn = 1;
        rocketArea = r.baseArea = 1;
        rocketCooldown = r.baseCooldown = 1;
        rocketTurnPerLevel = 1;
        rocketAreaPerLevel = 1;
        rocketCooldownPerLevel = 1;
        rocketTurnLevel = 1;
        rocketAreaLevel = 1;
        rocketCooldownLevel = 1;

    }

    public void scrollSpeed(int speed = 1)
    {
        _scrollSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Start()
    {
        UIElements = GameObject.FindGameObjectsWithTag("UI");

        foreach (GameObject Element in UIElements)
        {
            switch (Element.name)
            {
                case "Score":
                    scoreUIElement = Element; break;
                case "HealthBar":
                    healthBarUIElement = Element; break;
            }
        }
        healthBarUIElement.GetComponent<UnityEngine.UI.Slider>().value = shipHealth;
        healthBarUIElement.GetComponentsInChildren<UnityEngine.UI.Text>()[0].text = shipHealth.ToString();
        scoreUIElement.GetComponent<UnityEngine.UI.Text>().text = playerScore.ToString();
    }

    public int getMissingHealth()
    {
        Debug.Log(Mathf.RoundToInt(GameObject.Find("HealthBar").GetComponent<UnityEngine.UI.Slider>().maxValue - GameObject.Find("HealthBar").GetComponent<UnityEngine.UI.Slider>().value));
        return Mathf.RoundToInt(GameObject.Find("HealthBar").GetComponent<UnityEngine.UI.Slider>().maxValue - GameObject.Find("HealthBar").GetComponent<UnityEngine.UI.Slider>().value);
    }

    public void addPoints(Enemy e)
    {
        playerScore += e.pointValue;
        playerCurrency += e.pointValue;
        scoreUIElement.GetComponent<UnityEngine.UI.Text>().text = playerScore.ToString();
    }

    public void addPoints(ChaseEnemy e)
    {
        playerScore += e.pointValue;
        playerCurrency += e.pointValue;
        scoreUIElement.GetComponent<UnityEngine.UI.Text>().text = playerScore.ToString();
    }

    public void adjustHealth(Enemy e)
    {
        shipHealth -= e.damage;
        healthBarUIElement.GetComponent<UnityEngine.UI.Slider>().value = shipHealth;
        healthBarUIElement.GetComponentsInChildren<UnityEngine.UI.Text>()[0].text = shipHealth.ToString();
    }

    public void adjustHealth(ChaseEnemy e)
    {
        shipHealth -= e.damage;
        healthBarUIElement.GetComponent<UnityEngine.UI.Slider>().value = shipHealth;
        healthBarUIElement.GetComponentsInChildren<UnityEngine.UI.Text>()[0].text = shipHealth.ToString();
    }

    public void increaseShipHealth(int levels)
    {
        shipHealthLevel += levels;
        shipHealth = shipHealthPerLevel * shipHealthPerLevel;
        healthBarUIElement.GetComponent<UnityEngine.UI.Slider>().value = shipHealth;
        healthBarUIElement.GetComponent<UnityEngine.UI.Slider>().maxValue = shipHealth;
        healthBarUIElement.GetComponentsInChildren<UnityEngine.UI.Text>()[0].text = shipHealth.ToString();
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
