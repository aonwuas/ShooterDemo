using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
    bool visible;
    GameObject upgradeMenu;
    GameObject background;
    GameObject laserMenuBackground, gunMenuBackground, shipMenuBackground, rocketMenuBackground;
    LineUIController LineController;
    LineUIController.UILine line;
    static GameInfo gameInfo;
    GameObject player;
    static UnityEngine.UI.Text pointsBox;
    public enum menu_state {GUN, LASER, SHIP, ROCKET};
    menu_state currentState;

	// Use this for initialization
	void Start () {
        visible = false;
        gameInfo = GameObject.FindGameObjectWithTag("GameInfo").transform.GetComponent<GameInfo>();
        player = GameObject.FindGameObjectWithTag("Player");

        upgradeMenu = this.transform.FindChild("UpgradeMenu").gameObject;
        laserMenuBackground = upgradeMenu.transform.FindChild("LaserMenuBackground").gameObject;
        gunMenuBackground = upgradeMenu.transform.FindChild("GunMenuBackground").gameObject;
        rocketMenuBackground = upgradeMenu.transform.FindChild("RocketMenuBackground").gameObject;
        shipMenuBackground = upgradeMenu.transform.FindChild("ShipMenuBackground").gameObject;

        pointsBox = upgradeMenu.transform.FindChild("Points").GetComponent<UnityEngine.UI.Text>();


        LineController = upgradeMenu.GetComponent<LineUIController>();
        createLaserBackground(true);
        createGunBackground(true);
        createRocketBackground(true);
        createShipBackground(true);
        upgradeMenu.SetActive(false);

    }

    public static void UpdatePointsText()
    {
        pointsBox.text = gameInfo.playerCurrency.ToString();
    }


	// Update is called once per frame
	void Update () {
        Pause();
	}

    public void SwitchMenu(string state)
    {
        laserMenuBackground.SetActive(false);
        gunMenuBackground.SetActive(false);
        rocketMenuBackground.SetActive(false);
        shipMenuBackground.SetActive(false);
        switch (state)
        {
            case "gun":
                gunMenuBackground.SetActive(true);

                player.transform.FindChild("BulletGun").gameObject.SetActive(true);
                player.transform.FindChild("LaserGun").gameObject.SetActive(false);
                break;
            case "laser":
                laserMenuBackground.SetActive(true);
                player.transform.FindChild("BulletGun").gameObject.SetActive(false);
                player.transform.FindChild("LaserGun").gameObject.SetActive(true);
                break;
            case "rocket":
                rocketMenuBackground.SetActive(true);
                player.transform.FindChild("BulletGun").gameObject.SetActive(false);
                player.transform.FindChild("LaserGun").gameObject.SetActive(false);
                break;
            case "ship":
                shipMenuBackground.SetActive(true);
                break;
        }
    }


    public void createLaserBackground(bool showing = false)
    {
        
        LineController.newLineElement(Upgrades.upgrade_type.LDamage, new Vector2(0, 100), laserMenuBackground.transform);
        LineController.newLineElement(Upgrades.upgrade_type.LSpeed, new Vector2(0, 0), laserMenuBackground.transform);
        LineController.newLineElement(Upgrades.upgrade_type.LCooldown, new Vector2(0, -100), laserMenuBackground.transform);
        laserMenuBackground.SetActive(showing);

    }
    public void createGunBackground(bool showing = false)
    {
        
        LineController.newLineElement(Upgrades.upgrade_type.BDamage, new Vector2(0, 100), gunMenuBackground.transform);
        LineController.newLineElement(Upgrades.upgrade_type.BSpeed, new Vector2(0, 0), gunMenuBackground.transform);
        LineController.newLineElement(Upgrades.upgrade_type.BCooldown, new Vector2(0, -100), gunMenuBackground.transform);
        gunMenuBackground.SetActive(showing);

    }
    public void createRocketBackground(bool showing = false)
    {
        LineController.newLineElement(Upgrades.upgrade_type.RArea, new Vector2(0, 100), rocketMenuBackground.transform);
        LineController.newLineElement(Upgrades.upgrade_type.RTurn, new Vector2(0, 0), rocketMenuBackground.transform);
        LineController.newLineElement(Upgrades.upgrade_type.RCooldown, new Vector2(0, -100), rocketMenuBackground.transform);
        rocketMenuBackground.SetActive(showing);

    }

    public void createShipBackground(bool showing = false)
    {
        
        LineController.newLineElement(Upgrades.upgrade_type.SHealth, new Vector2(0, 100), shipMenuBackground.transform);
        LineController.newLineElement(Upgrades.upgrade_type.SSpeed, new Vector2(0, 0), shipMenuBackground.transform);
        LineController.newLineElement(Upgrades.upgrade_type.SRestore, new Vector2(0, -100), shipMenuBackground.transform);
        shipMenuBackground.SetActive(showing);

    }




    void Pause()
    {
        if (Input.GetKeyDown("escape"))
        {
            visible = !visible;
            upgradeMenu.SetActive(visible);
            if (visible)
            {
                pointsBox.text = gameInfo.playerCurrency.ToString();
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
}
