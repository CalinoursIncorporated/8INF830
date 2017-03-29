using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUpgradeManager : MonoBehaviour
{
    #region Gauge preparation
    private List<GameObject> healthGaugeGrads = new List<GameObject>();
    private List<GameObject> armorGaugeGrads = new List<GameObject>();
    private List<GameObject> damageGaugeGrads = new List<GameObject>();
    private List<GameObject> fireRateGaugeGrads = new List<GameObject>();
    private List<GameObject> topSpeedGaugeGrads = new List<GameObject>();
    private List<GameObject> handlingGaugeGrads = new List<GameObject>();
    private BaseStats stats;
    private static int healthUp = 0;
    private static int armorUp = 0;
    private static int damageUp = 0;
    private static int fireRateUp = 0;
    private static int topSpeedUp = 0;
    private static int handlingUp = 0;
    private static int defensePoints = 0;
    private static int attackPoints = 0;
    private static int mobilityPoints = 0;

    public InventoryController inventoryController;

    #endregion

    public void Start()
    {
        #region Gauge init
        GameObject healthGauge = GameObject.Find("HealthUpgradeGauge");
        GameObject armorGauge = GameObject.Find("ArmorUpgradeGauge");
        GameObject damageGauge = GameObject.Find("DamageUpgradeGauge");
        GameObject fireRateGauge = GameObject.Find("FireRateUpgradeGauge");
        GameObject topSpeedGauge = GameObject.Find("TopSpeedUpgradeGauge");
        GameObject handlingGauge = GameObject.Find("HandlingUpgradeGauge");
        //invControl = GameObject.Find("ShipInventoryC").GetComponent<InventoryController>();
        if (inventoryController == null)
        {
            Debug.LogError("InventoryController not attached !", this);
        }
        UpdateUpgradeCount();

        stats = GameObject.Find("Stats").GetComponent<BaseStats>();
        foreach (Transform child in healthGauge.transform)
        {
            healthGaugeGrads.Add(child.gameObject);
        }
        foreach (Transform child in armorGauge.transform)
        {
            armorGaugeGrads.Add(child.gameObject);
        }
        foreach (Transform child in damageGauge.transform)
        {
            damageGaugeGrads.Add(child.gameObject);
        }
        foreach (Transform child in fireRateGauge.transform)
        {
            fireRateGaugeGrads.Add(child.gameObject);
        }
        foreach (Transform child in topSpeedGauge.transform)
        {
            topSpeedGaugeGrads.Add(child.gameObject);
        }
        foreach (Transform child in handlingGauge.transform)
        {
            handlingGaugeGrads.Add(child.gameObject);
        }

        int i = 0;
        foreach (GameObject grad in healthGaugeGrads)
        {
            if (i < stats.scanRangeStat)
            {
                grad.GetComponent<RawImage>().color = Color.green;
                i++;
            }
            else
            {
                i = 0;
                break;
            }
        }
        foreach (GameObject grad in armorGaugeGrads)
        {
            if (i < stats.printerStat)
            {
                grad.GetComponent<RawImage>().color = Color.green;
                i++;
            }
            else
            {
                i = 0;
                break;
            }
        }
        foreach (GameObject grad in damageGaugeGrads)
        {
            if (i < stats.numberDronesStat)
            {
                grad.GetComponent<RawImage>().color = Color.green;
                i++;
            }
            else
            {
                i = 0;
                break;
            }
        }
        foreach (GameObject grad in fireRateGaugeGrads)
        {
            if (i < stats.fireDroneStat)
            {
                grad.GetComponent<RawImage>().color = Color.green;
                i++;
            }
            else
            {
                i = 0;
                break;
            }
        }
        foreach (GameObject grad in topSpeedGaugeGrads)
        {
            if (i < stats.shieldStat)
            {
                grad.GetComponent<RawImage>().color = Color.green;
                i++;
            }
            else
            {
                i = 0;
                break;
            }
        }
        foreach (GameObject grad in handlingGaugeGrads)
        {
            if (i < stats.chargeStat)
            {
                grad.GetComponent<RawImage>().color = Color.green;
                i++;
            }
            else
            {
                i = 0;
                break;
            }
        }
        #endregion
    }

    private void UpdateUpgradeCount()
    {

        defensePoints = inventoryController.GetQuantity(210);
        GameObject.Find("DefenseCounter").GetComponent<Text>().text = defensePoints.ToString();
        attackPoints = inventoryController.GetQuantity(211);
        GameObject.Find("AttackCounter").GetComponent<Text>().text = attackPoints.ToString();
        mobilityPoints = inventoryController.GetQuantity(212);
        GameObject.Find("MobilityCounter").GetComponent<Text>().text = mobilityPoints.ToString();
    }
    
    #region Button click functions (update the values of the ship's stats)
    public void HealthUpgrade()
    {
        if (defensePoints > 0)
        {
            defensePoints--;
            GameObject.Find("DefenseCounter").GetComponent<Text>().text = defensePoints.ToString();
            healthUp += 1;
            int i = 0;
            if (stats.scanRangeStat + healthUp > 5)
            {
                healthUp = 5 - stats.scanRangeStat;
                defensePoints++;
            }
            foreach (GameObject grad in healthGaugeGrads)
            {
                if (i < healthUp + stats.scanRangeStat)
                {
                    if (grad.GetComponent<RawImage>().color == Color.white)
                    {
                        grad.GetComponent<RawImage>().color = Color.yellow;
                        i++;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }
        else
        {
            Debug.Log("Not enough defense upgrade kits !");
        }
    }

    public void ArmorUpgrade()
    {
        if (defensePoints > 0)
        {
            defensePoints--;
            armorUp += 1;
            GameObject.Find("DefenseCounter").GetComponent<Text>().text = defensePoints.ToString();
            int i = 0;
            if (stats.printerStat + armorUp >= 5)
            {
                armorUp = 5 - stats.printerStat;
                defensePoints++;
            }
            foreach (GameObject grad in armorGaugeGrads)
            {
                if (i < armorUp + stats.printerStat)
                {
                    if (grad.GetComponent<RawImage>().color == Color.white)
                    {
                        grad.GetComponent<RawImage>().color = Color.yellow;
                        i++;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }
        else
        {
            Debug.Log("Not enough defense upgrade kits !");
        }
    }

    public void DamageUpgrade()
    {
        if (attackPoints > 0)
        {
            attackPoints--;
            GameObject.Find("AttackCounter").GetComponent<Text>().text = attackPoints.ToString();
            damageUp += 1;
            int i = 0;
            if (stats.numberDronesStat + damageUp >= 5)
            {
                damageUp = 5 - stats.numberDronesStat;
                attackPoints++;
            }
            foreach (GameObject grad in damageGaugeGrads)
            {
                if (i < damageUp + stats.numberDronesStat)
                {
                    if (grad.GetComponent<RawImage>().color == Color.white)
                    {
                        grad.GetComponent<RawImage>().color = Color.yellow;
                        i++;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }
        else
        {
            Debug.Log("Not enough attack upgrade kits !");
        }
    }

    public void FireRateUpgrade()
    {
        if (attackPoints > 0)
        {
            attackPoints--;
            GameObject.Find("AttackCounter").GetComponent<Text>().text = attackPoints.ToString();
            fireRateUp += 1;
            int i = 0;
            if (stats.fireDroneStat + fireRateUp >= 5)
            {
                fireRateUp = 5 - stats.fireDroneStat;
                attackPoints++;
            }
            foreach (GameObject grad in fireRateGaugeGrads)
            {
                if (i < fireRateUp + stats.fireDroneStat)
                {
                    if (grad.GetComponent<RawImage>().color == Color.white)
                    {
                        grad.GetComponent<RawImage>().color = Color.yellow;
                        i++;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }
        else
        {
            Debug.Log("Not enough attack upgrade kits !");
        }
    }

    public void TopSpeedUpgrade()
    {
        if (mobilityPoints > 0)
        {
            mobilityPoints--;
            GameObject.Find("MobilityCounter").GetComponent<Text>().text = mobilityPoints.ToString();
            topSpeedUp += 1;
            int i = 0;
            if (stats.shieldStat + topSpeedUp >= 5)
            {
                topSpeedUp = 5 - stats.shieldStat;
                mobilityPoints++;
            }
            foreach (GameObject grad in topSpeedGaugeGrads)
            {
                if (i < topSpeedUp + stats.shieldStat)
                {
                    if (grad.GetComponent<RawImage>().color == Color.white)
                    {
                        grad.GetComponent<RawImage>().color = Color.yellow;
                        i++;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }
        else
        {
            Debug.Log("Not enough mobility upgrade kits !");
        }
    }

    public void HandlingUpgrade()
    {
        if (mobilityPoints > 0)
        {
            mobilityPoints--;
            GameObject.Find("MobilityCounter").GetComponent<Text>().text = mobilityPoints.ToString();
            handlingUp += 1;
            int i = 0;
            if (stats.chargeStat + handlingUp >= 5)
            {
                handlingUp = 5 - stats.chargeStat;
                mobilityPoints++;
            }
            foreach (GameObject grad in handlingGaugeGrads)
            {
                if (i < handlingUp + stats.chargeStat)
                {
                    if (grad.GetComponent<RawImage>().color == Color.white)
                    {
                        grad.GetComponent<RawImage>().color = Color.yellow;
                        i++;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }
        else
        {
            Debug.Log("Not enough mobility upgrade kits !");
        }
    }
    #endregion

    #region Upgrade validate/cancel buttons and functions.

    public void Validate()
    {
        stats.scanRangeStat += healthUp;
        stats.printerStat += armorUp;
        stats.numberDronesStat += damageUp;
        stats.fireDroneStat += fireRateUp;
        stats.shieldStat += topSpeedUp;
        stats.chargeStat += handlingUp;

        inventoryController.RemoveItem(210, (healthUp + armorUp));
        inventoryController.RemoveItem(211, (damageUp + fireRateUp));
        inventoryController.RemoveItem(212, (topSpeedUp + handlingUp));

        UpdateUpgradeCount();


        foreach (GameObject grad in healthGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.green;
            }
        }
        foreach (GameObject grad in armorGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.green;
            }
        }
        foreach (GameObject grad in damageGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.green;
            }
        }
        foreach (GameObject grad in fireRateGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.green;
            }
        }
        foreach (GameObject grad in topSpeedGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.green;
            }
        }
        foreach (GameObject grad in handlingGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.green;
            }
        }
    }

    public void Cancel()
    {
        healthUp = 0;
        armorUp = 0;
        damageUp = 0;
        fireRateUp = 0;
        topSpeedUp = 0;
        handlingUp = 0;
        GameObject.Find("DefenseCounter").GetComponent<Text>().text = defensePoints.ToString();
        GameObject.Find("AttackCounter").GetComponent<Text>().text = attackPoints.ToString();
        GameObject.Find("MobilityCounter").GetComponent<Text>().text = mobilityPoints.ToString();
        foreach (GameObject grad in healthGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.white;
            }
        }
        foreach (GameObject grad in armorGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.white;
            }
        }
        foreach (GameObject grad in damageGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.white;
            }
        }
        foreach (GameObject grad in fireRateGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.white;
            }
        }
        foreach (GameObject grad in topSpeedGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.white;
            }
        }
        foreach (GameObject grad in handlingGaugeGrads)
        {
            if (grad.GetComponent<RawImage>().color == Color.yellow)
            {
                grad.GetComponent<RawImage>().color = Color.white;
            }
        }
    }
    #endregion
}
