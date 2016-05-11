using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
    bool visible;
    GameObject upgradeMenu;
    GameObject background;
    GameObject laserMenuBackground, gunMenuBackground, shipMenuBackground, rocketMenuBackground;
    LineUIController LineController;
    LineUIController.UILine line;
    GameInfo gameInfo;
    UnityEngine.UI.Text pointsBox;
    public enum menu_state {GUN, LASER, SHIP, ROCKET};
    menu_state currentState;

	// Use this for initialization
	void Start () {
        visible = false;
        gameInfo = GameObject.FindGameObjectWithTag("GameInfo").transform.GetComponent<GameInfo>();
        upgradeMenu = this.transform.FindChild("UpgradeMenu").gameObject;
        pointsBox = upgradeMenu.transform.FindChild("Points").GetComponent<UnityEngine.UI.Text>();
        LineController = upgradeMenu.GetComponent<LineUIController>();
        createLaserBackground();
        createGunBackground();
        createRocketBackground(true);
        createShipBackground();
        Pause();

    }
	
	// Update is called once per frame
	void Update () {
        Pause();
	}

    void SwitchMenu(menu_state state)
    {

    }


    public void createLaserBackground(bool showing = false)
    {
        laserMenuBackground = upgradeMenu.transform.FindChild("LaserMenuBackground").gameObject;
        LineController.newLineElement(Upgrades.upgrade_type.LDamage, new Vector2(0, 100), laserMenuBackground.transform);
        LineController.newLineElement(Upgrades.upgrade_type.LSpeed, new Vector2(0, 0), laserMenuBackground.transform);
        LineController.newLineElement(Upgrades.upgrade_type.LCooldown, new Vector2(0, -100), laserMenuBackground.transform);
        laserMenuBackground.SetActive(showing);

    }
    public void createGunBackground(bool showing = false)
    {
        gunMenuBackground = upgradeMenu.transform.FindChild("GunMenuBackground").gameObject;
        LineController.newLineElement(Upgrades.upgrade_type.BDamage, new Vector2(0, 100), gunMenuBackground.transform);
        LineController.newLineElement(Upgrades.upgrade_type.BSpeed, new Vector2(0, 0), gunMenuBackground.transform);
        LineController.newLineElement(Upgrades.upgrade_type.BCooldown, new Vector2(0, -100), gunMenuBackground.transform);
        gunMenuBackground.SetActive(showing);

    }
    public void createRocketBackground(bool showing = false)
    {
        rocketMenuBackground = upgradeMenu.transform.FindChild("RocketMenuBackground").gameObject;
        LineController.newLineElement(Upgrades.upgrade_type.RArea, new Vector2(0, 100), rocketMenuBackground.transform);
        LineController.newLineElement(Upgrades.upgrade_type.RTurn, new Vector2(0, 0), rocketMenuBackground.transform);
        LineController.newLineElement(Upgrades.upgrade_type.RCooldown, new Vector2(0, -100), rocketMenuBackground.transform);
        rocketMenuBackground.SetActive(showing);

    }

    public void createShipBackground(bool showing = false)
    {
        shipMenuBackground = upgradeMenu.transform.FindChild("ShipMenuBackground").gameObject;
        LineController.newLineElement(Upgrades.upgrade_type.SHealth, new Vector2(0, 100), shipMenuBackground.transform);
        LineController.newLineElement(Upgrades.upgrade_type.SSpeed, new Vector2(0, 0), shipMenuBackground.transform);
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
