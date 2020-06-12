using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{

    public static CurrencyManager currencyInstance;

    public int currentBalance;
    public int collectedduringRun;
    public Text amountCoinsCollectedduringRun;


    void Start()
    {
        collectedduringRun = Constants.currencyInRun;
        currentBalance = PlayerPrefs.GetInt("currency");
        amountCoinsCollectedduringRun.text =  collectedduringRun.ToString();
    }

    public void CollectCoin()
    {
        collectedduringRun++;
        amountCoinsCollectedduringRun.text = collectedduringRun.ToString();
    }

    public void UpdatetheAmountofMoney()
    {

        currentBalance += collectedduringRun;
        PlayerPrefs.SetInt("currency", currentBalance);
        collectedduringRun = 0;
    }



}
