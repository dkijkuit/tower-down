using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    // Update is called once per frame
    private Text moneyText;
    void Start(){
        moneyText = gameObject.GetComponent<Text>();
    }

    void Update() {
        moneyText.text = "$" + PlayerStats.Money.ToString();
    }
}
