using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LineUIController : MonoBehaviour {
    
    public GameObject linePrefab;
    GameInfo gameInfo;

    void Awake()
    {
        this.linePrefab = (GameObject)Resources.Load("Prefabs/UI/LineUpgrade");
        gameInfo = GameObject.FindGameObjectWithTag("GameInfo").transform.GetComponent<GameInfo>();
    }
    void Start()
    {
        gameInfo = GameObject.FindGameObjectWithTag("GameInfo").transform.GetComponent<GameInfo>();
        this.linePrefab = (GameObject)Resources.Load("Prefabs/UI/LineUpgrade");
    }


    public class UILine
    {
        public GameObject newLineObject;
        public Upgrades upgrade;
        public Text upgradeName;
        private Text upgradeEffect;
        private Text upgradeCost;
        private Text targetLevel;
        private Text upgrade_type;
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
                    case "upgrade_type":
                        upgrade_type = t;
                        break;
                }
            }
            uType = upgradeType;
            SetName(upgradeType, g);
            SetEffect(upgradeType, g);
            SetLevel(upgradeType, g);
            upgrade_type.text =  upgradeType.ToString();
            SetCost("5");
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
                case Upgrades.upgrade_type.SRestore:
                    this.upgradeName.text = "Repair Ship";
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
                case Upgrades.upgrade_type.SRestore:
                    this.upgradeEffect.text = "Repair Your Ship";
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
                case Upgrades.upgrade_type.SRestore:
                    this.targetLevel.text = g.getMissingHealth().ToString();
                    break;
            }
        }
           
        void SetEffect(string effect) { this.upgradeEffect.text = effect; }
        void SetCost(string cost) { this.upgradeCost.text = cost; }
        void SetLevel(string level) { this.targetLevel.text = level; }
    }

    public UILine newLineElement(Upgrades.upgrade_type upgradeType, Vector2 position, Transform parent)
    {
        return new UILine( upgradeType,  position, this.linePrefab, gameInfo, parent);
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void buttonClick()
    {

        string typeAsString = this.transform.FindChild("upgrade_type").GetComponent<UnityEngine.UI.Text>().text;
        Upgrades.upgrade_type typeAsEnum = (Upgrades.upgrade_type)System.Enum.Parse(typeof(Upgrades.upgrade_type), typeAsString);
        UnityEngine.UI.Text costTextBox = this.transform.FindChild("Cost").GetComponent<UnityEngine.UI.Text>();
        int cost = System.Int32.Parse(costTextBox.text);
        if (gameInfo.playerCurrency >= cost)
        {
            gameInfo.playerCurrency -= cost;
            costTextBox.text = Mathf.FloorToInt(cost*3.5f).ToString();
            MenuController.UpdatePointsText();

            Upgrades u = new Upgrades(gameInfo, typeAsEnum);
            u.upgradeFunction(1);

            switch (typeAsEnum)
            {
                case Upgrades.upgrade_type.LCooldown:
                    gameInfo.laserCooldownLevel += 1;
                    this.transform.FindChild("Level").GetComponent<UnityEngine.UI.Text>().text = gameInfo.laserCooldownLevel.ToString();
                    break;
                case Upgrades.upgrade_type.LDamage:
                    gameInfo.laserDamageLevel += 1;
                    this.transform.FindChild("Level").GetComponent<UnityEngine.UI.Text>().text = gameInfo.laserDamageLevel.ToString();
                    break;
                case Upgrades.upgrade_type.LSpeed:
                    gameInfo.laserSpeedLevel += 1;
                    this.transform.FindChild("Level").GetComponent<UnityEngine.UI.Text>().text = gameInfo.laserSpeedLevel.ToString();
                    break;
                case Upgrades.upgrade_type.BCooldown:
                    gameInfo.bulletCooldownLevel += 1;
                    this.transform.FindChild("Level").GetComponent<UnityEngine.UI.Text>().text = gameInfo.bulletCooldownLevel.ToString();
                    break;
                case Upgrades.upgrade_type.BDamage:
                    gameInfo.bulletDamageLevel += 1;
                    this.transform.FindChild("Level").GetComponent<UnityEngine.UI.Text>().text = gameInfo.bulletDamageLevel.ToString();
                    break;
                case Upgrades.upgrade_type.BSpeed:
                    gameInfo.bulletSpeedLevel += 1;
                    this.transform.FindChild("Level").GetComponent<UnityEngine.UI.Text>().text = gameInfo.bulletSpeedLevel.ToString();
                    break;
                case Upgrades.upgrade_type.RCooldown:
                    gameInfo.rocketCooldownLevel += 1;
                    this.transform.FindChild("Level").GetComponent<UnityEngine.UI.Text>().text = gameInfo.rocketCooldownLevel.ToString();
                    break;
                case Upgrades.upgrade_type.RTurn:
                    gameInfo.rocketTurnLevel += 1;
                    this.transform.FindChild("Level").GetComponent<UnityEngine.UI.Text>().text = gameInfo.rocketTurnLevel.ToString();
                    break;
                case Upgrades.upgrade_type.RArea:
                    gameInfo.rocketAreaLevel += 1;
                    this.transform.FindChild("Level").GetComponent<UnityEngine.UI.Text>().text = gameInfo.rocketAreaLevel.ToString();
                    break;
                case Upgrades.upgrade_type.SSpeed:
                    gameInfo.shipSpeedLevel += 1;
                    break;
                case Upgrades.upgrade_type.SHealth:
                    gameInfo.shipHealthLevel += 1;
                    break;
                case Upgrades.upgrade_type.SRestore:
                    break;
            }
            
        }
    }
}
