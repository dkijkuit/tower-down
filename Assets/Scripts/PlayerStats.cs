using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    private uint money;    
    public uint startMoney = 400;
    private int health;
    public int startHealth = 100;

    void Awake(){
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        money = startMoney;
        health = startHealth;

        HealthUpdated();
    }

    public uint getMoney(){
        return money;
    }

    public void addMoney(uint amount){
        money += amount;
    }

    public void subtractMoney(uint amount){
        int newAmount = (int)(money - amount);
        if(newAmount < 0){
            money = 0;
        } else {
            money = (uint)newAmount;
        }
    }

    public void TakeLives(int livesToTake){
        int newHealth = health - livesToTake;
        if(newHealth <= 0){
            health = 0;
        } else {
            health = newHealth;
        }
    }

    public event Action<int> onHealthUpdated;
    private void HealthUpdated(){
        if(onHealthUpdated != null){
            onHealthUpdated(health);
        }
    }
}
