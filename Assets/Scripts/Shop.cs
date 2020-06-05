using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start(){
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandardTurret(){
        Debug.Log("Standard Turret selected");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseMissileLauncher(){
        Debug.Log("Missile Turret selected");
        buildManager.SetTurretToBuild(buildManager.missileLauncherPrefab);
    }
}
