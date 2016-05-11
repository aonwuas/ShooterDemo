using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LineUIController : MonoBehaviour {
    
    public GameObject linePrefab;
    GameInfo gameInfo;


    void Start()
    {
        gameInfo = GameObject.FindGameObjectWithTag("GameInfo").transform.GetComponent<GameInfo>();
        linePrefab = (GameObject)Resources.Load("Prefabs/UI/LineUpgrade");
    }


    public class UILine
    {
        public GameObject newLineObject;
        public Upgrades upgrade;
        public Text upgradeName;
        private Text upgradeEffect;
        private Text upgradeCost;
        private Text targetLevel;
        private Upgrades.upgrade_type uType;
        public int level;

        public UILine(Upgrades.upgrade_type upgradeType, Vector2 position, GameObject prefab, GameInfo g, Transform parent)
        {
            upgrade = new Upgrades(g, upgradeType);
            newLineObject = GameObject.Instantiate(prefab, position, Quaternion.identity) as GameObject;
            newLineObject.transform.SetParent(parent, false);
            foreach (Text t in newLineObject.GetComponentsInChildren<Text>(true))
            {
                switch (t.name.ToString())
                {
                    case "Name":
                        upgradeName = t;
                        break;
                    case "Upgrade Effect":
                        upgradeEffect = t;
                        break;
                    case "Cost":
                        upgradeCost = t;
                        break;
                    case "Level":
                        targetLevel = t;
                        break;
                }
            }
            uType = upgradeType;
            SetName(upgradeType, g);
            SetEffect(upgradeType, g);
            SetLevel(upgradeType, g);
            SetCost("123");
        }

        void SetName(Upgrades.upgrade_type type, GameInfo g)
        {
            switch (type)
            {
                case Upgrades.upgrade_type.LDamage:
                    this.upgradeName.text = "Laser Damage";
                    break;
                case Upgrades.upgrade_type.LCooldown:
                    this.upgradeName.text = "Laser Cooldown";
                    break;
                case Upgrades.upgrade_type.LSpeed:
                    this.upgradeName.text = "Laser Speed";
                    break;
                case Upgrades.upgrade_type.BDamage:
                    this.upgradeName.text = "Bullet Damage";
                    break;
                case Upgrades.upgrade_type.BCooldown:
                    this.upgradeName.text = "Bullet Cooldown";
                    break;
                case Upgrades.upgrade_type.BSpeed:
                    this.upgradeName.text = "Bullet Speed";
                    break;
                case Upgrades.upgrade_type.SHealth:
                    this.upgradeName.text = "Ship Health";
                    break;
                case Upgrades.upgrade_type.SSpeed:
                    this.upgradeName.text = "Ship Speed";
                    break;
                case Upgrades.upgrade_type.RArea:
                    this.upgradeName.text = "Rocket AOE";
                    break;
                case Upgrades.upgrade_type.RCooldown:
                    this.upgradeName.text = "Rocket Cooldown";
                    break;
                case Upgrades.upgrade_type.RTurn:
                    this.upgradeName.text = "Rocket Turn";
                    break;
            }
        }

        void SetEffect(Upgrades.upgrade_type type, GameInfo g)
        {
            switch (type)
            {
                case Upgrades.upgrade_type.LDamage:
                    this.upgradeEffect.text = "Increase Laser Damage";
                    break;
                case Upgrades.upgrade_type.LCooldown:
                    this.upgradeEffect.text = "Increase Laser Fire Rate";
                    break;
                case Upgrades.upgrade_type.LSpeed:
                    this.upgradeEffect.text = "Increase Laser Projectile Speed";
                    break;
                case Upgrades.upgrade_type.BDamage:
                    this.upgradeEffect.text = "Increase Bullet Damage";
                    break;
                case Upgrades.upgrade_type.BCooldown:
                    this.upgradeEffect.text = "Increase Bullet Fire Rate";
                    break;
                case Upgrades.upgrade_type.BSpeed:
                    this.upgradeEffect.text = "Increase Bullet Projectile Speed";
                    break;
                case Upgrades.upgrade_type.SHealth:
                    this.upgradeEffect.text = "Increase Ship Health";
                    break;
                case Upgrades.upgrade_type.SSpeed:
                    this.upgradeEffect.text = "Increase Ship Speed";
                    break;
                case Upgrades.upgrade_type.RArea:
                    this.upgradeEffect.text = "Larger Explosion Radius";
                    break;
                case Upgrades.upgrade_type.RCooldown:
                    this.upgradeEffect.text = "Increase Rocket Fire Rate";
                    break;
                case Upgrades.upgrade_type.RTurn:
                    this.upgradeEffect.text = "Increase Rocket Turning Capibilities";
                    break;
            }
        }
        void SetLevel(Upgrades.upgrade_type type, GameInfo g)
        {
            switch (type)
            {
                case Upgrades.upgrade_type.LDamage:
                    this.targetLevel.text = g.laserDamageLevel.ToString();
                    break;
                case Upgrades.upgrade_type.LCooldown:
                    this.targetLevel.text = g.laserCooldownLevel.ToString();
                    break;
                case Upgrades.upgrade_type.LSpeed:
                    this.targetLevel.text = g.laserSpeedLevel.ToString();
                    break;
                case Upgrades.upgrade_type.BDamage:
                    this.targetLevel.text = g.bulletDamageLevel.ToString();
                    break;
                case Upgrades.upgrade_type.BCooldown:
                    this.targetLevel.text = g.bulletCooldownLevel.ToString();
                    break;
                case Upgrades.upgrade_type.BSpeed:
                    this.targetLevel.text = g.bulletSpeedLevel.ToString();
                    break;
                case Upgrades.upgrade_type.SHealth:
                    this.targetLevel.text = g.shipHealthLevel.ToString();
                    break;
                case Upgrades.upgrade_type.SSpeed:
                    this.targetLevel.text = g.shipSpeedLevel.ToString();
                    break;
                case Upgrades.upgrade_type.RArea:
                    this.targetLevel.text = g.rocketAreaLevel.ToString();
                    break;
                case Upgrades.upgrade_type.RCooldown:
                    this.targetLevel.text = g.rocketCooldownLevel.ToString();
                    break;
                case Upgrades.upgrade_type.RTurn:
                    this.targetLevel.text = g.rocketTurnLevel.ToString();
                    break;
            }
        }





        void SetEffect(string effect) { this.upgradeEffect.text = effect; }
        void SetCost(string cost) { this.upgradeCost.text = cost; }
        void SetLevel(string level) { this.targetLevel.text = level; }


        public void buttonClick(Upgrades.upgrade_type type)
        {
            upgrade.upgradeFunction(1);
            //int currentLevel = 
            //SetLevel(currentLevel.ToString());
        }

    }

    public UILine newLineElement(Upgrades.upgrade_type upgradeType, Vector2 position, Transform parent)
    {
        return new UILine( upgradeType,  position, linePrefab, gameInfo, parent);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
