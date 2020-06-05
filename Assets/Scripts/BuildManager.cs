using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject standardTurretPrefab;

    public GameObject missileLauncherPrefab;
    private TurretBlueprint turretToBuild;
    
    void Awake(){
        if(instance != null){
            Debug.LogError("A reference to the BuildManager was already found. Expected only 1 instance!");
            return;
        }
        instance = this;
    }

    public bool CanBuild{ get {return turretToBuild != null; } }

    public void BuildTurretOn(ConcreteTile tile){
        if(PlayerStats.Money < turretToBuild.cost){
            Debug.Log("Not enough money!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = Instantiate(turretToBuild.prefab, tile.GetBuildPosition(), Quaternion.identity);
        tile.turret = turret;

        Debug.Log("Money left: " + PlayerStats.Money);
    }

    public void SelectTurretToBuild(TurretBlueprint turretBlueprint){
        turretToBuild = turretBlueprint;
    }
}
