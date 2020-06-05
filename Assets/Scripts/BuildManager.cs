using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject standardTurretPrefab;

    public GameObject missileLauncherPrefab;

    public GameObject buildEffect;
    private TurretBlueprint turretToBuild;
    
    void Awake(){
        if(instance != null){
            Debug.LogError("A reference to the BuildManager was already found. Expected only 1 instance!");
            return;
        }
        instance = this;
    }

    public bool CanBuild{ get {return turretToBuild != null; } }
    public bool HasMoney{ get {return PlayerStats.Money >= turretToBuild.cost ; } }

    public void BuildTurretOn(ConcreteTile tile){
        if(PlayerStats.Money < turretToBuild.cost){
            Debug.Log("Not enough money!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = Instantiate(turretToBuild.prefab, tile.GetBuildPosition(), Quaternion.identity);
        tile.turret = turret;

        GameObject effect = Instantiate(buildEffect, tile.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Money left: " + PlayerStats.Money);
    }

    public void SelectTurretToBuild(TurretBlueprint turretBlueprint){
        turretToBuild = turretBlueprint;
    }
}
