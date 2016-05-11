using UnityEngine;
using System.Collections;
using System;

public class Upgrades {
    public enum upgrade_type  {LDamage, LSpeed, LCooldown, BDamage, BSpeed, BCooldown, SSpeed, SHealth, RArea, RTurn, RCooldown};
    GameInfo gameInfo;
    public Action<int> upgradeFunction;


    public Upgrades(GameInfo g, upgrade_type type)
    {
        this.gameInfo = g;
        setFunction(type);
    }

    public bool setFunction(upgrade_type type)
    {
        switch (type)
        {
            case upgrade_type.LDamage:
                upgradeFunction = upgradeLaserDamage;
                return true;
            case upgrade_type.LSpeed:
                upgradeFunction = upgradeLaserSpeed;
                return true;
            case upgrade_type.LCooldown:
                upgradeFunction = upgradeLaserCooldown;
                return true;
            case upgrade_type.BDamage:
                upgradeFunction = upgradeBulletDamage;
                return true;
            case upgrade_type.BSpeed:
                upgradeFunction = upgradeBulletSpeed;
                return true;
            case upgrade_type.BCooldown:
                upgradeFunction = upgradeBulletCooldown;
                return true;
            case upgrade_type.SHealth:
                upgradeFunction = upgradeShipHealth;
                return true;
            case upgrade_type.SSpeed:
                upgradeFunction = upgradeShipSpeed;
                return true;
            case upgrade_type.RTurn:
                upgradeFunction = upgradeRocketTurn;
                return true;
            case upgrade_type.RArea:
                upgradeFunction = upgradeRocketArea;
                return true;
            case upgrade_type.RCooldown:
                upgradeFunction = upgradeRocketCooldown;
                return true;
            default:
                return false;
        }
    }




    /*
    System.Func<string, string> b = Upgrades.Upgrade;
    private static string Upgrade(string thing)
    {
        return thing;
    }
    */


    //LASER UPGRADES
    private void upgradeLaserDamage(int levels = 1)
    {
        gameInfo.laserDamageLevel += levels;
        gameInfo.laserDamage = gameInfo.l.baseDamage + gameInfo.laserDamagePerLevel * gameInfo.laserDamageLevel;
    }

    private void upgradeLaserSpeed(int levels = 1)
    {
        gameInfo.laserSpeedLevel += levels;
        gameInfo.laserSpeed = gameInfo.l.baseSpeed + gameInfo.laserSpeedPerLevel * gameInfo.laserSpeedLevel;
    }

    private void upgradeLaserCooldown(int levels = 1)
    {
        gameInfo.laserCooldownLevel += levels;
        gameInfo.laserCooldown = gameInfo.l.baseCooldown * Mathf.Pow(gameInfo.laserCooldownPerLevel, gameInfo.laserCooldownLevel);
    }
    


    //SHIP UPGRADES
    private void upgradeShipSpeed(int levels  = 1)
    {
        gameInfo.shipSpeedLevel += levels;
        gameInfo.shipHSpeed += gameInfo.s.hSpeed + gameInfo.shipSpeedLevel * gameInfo.shipHPerLevel;
        gameInfo.shipVSpeed += gameInfo.s.vSpeed + gameInfo.shipSpeedLevel * gameInfo.shipVPerLevel;
    }

    private void upgradeShipHealth(int levels = 1)
    {
        gameInfo.increaseShipHealth(levels);
    }


    //BULLET UPGRADES
    private void upgradeBulletDamage(int levels = 1)
    {
        gameInfo.bulletDamageLevel += levels;
        gameInfo.bulletDamage = gameInfo.b.baseDamage + gameInfo.bulletDamagePerLevel * gameInfo.bulletDamageLevel;
    }

    private void upgradeBulletSpeed(int levels = 1)
    {
        gameInfo.bulletSpeedLevel += levels;
        gameInfo.bulletSpeed = gameInfo.b.baseSpeed + gameInfo.bulletSpeedPerLevel * gameInfo.bulletSpeedLevel;
    }

    private void upgradeBulletCooldown(int levels = 1)
    {
        gameInfo.bulletCooldownLevel += levels;
        gameInfo.bulletCooldown = gameInfo.b.baseCooldown  * Mathf.Pow(gameInfo.bulletCooldownPerLevel, gameInfo.bulletCooldownLevel);
    }

    //ROCKET UPGRADES
    private void upgradeRocketTurn(int levels = 1)
    {
        gameInfo.rocketTurnLevel += levels;
        gameInfo.rocketTurn = gameInfo.r.baseTurn + gameInfo.rocketTurnPerLevel * gameInfo.rocketTurnLevel;
    }

    private void upgradeRocketArea(int levels = 1)
    {
        gameInfo.rocketAreaLevel += levels;
        gameInfo.rocketArea = gameInfo.r.baseArea + gameInfo.rocketAreaPerLevel * gameInfo.rocketAreaLevel;
    }

    private void upgradeRocketCooldown(int levels = 1)
    {
        gameInfo.rocketCooldownLevel += levels;
        gameInfo.rocketCooldown = gameInfo.r.baseCooldown * Mathf.Pow(gameInfo.rocketCooldownPerLevel, gameInfo.rocketCooldownLevel);
    }
}
