using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject standardTurretPrefab;

    public GameObject missileLauncherPrefab;
    private GameObject turretToBuild;
    
    void Awake(){
        if(instance != null){
            Debug.LogError("A reference to the BuildManager was already found. Expected only 1 instance!");
            return;
        }
        instance = this;
    }

    public GameObject GetTurretToBuild(){
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret){
        turretToBuild = turret;
    }
}
