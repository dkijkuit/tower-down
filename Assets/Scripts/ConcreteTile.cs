using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteTile : MonoBehaviour
{
    public Color hoverColor;

    private GameObject turret;
    private Renderer rend;
    private Color startColor;

    void Start(){
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown(){
        if(turret != null) {
            Debug.Log("Cannot build here!");
            return;
        } 

        //Build a turret
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = Instantiate(turretToBuild, transform.position, transform.rotation);
        turret.transform.position = new Vector3(transform.position.x, transform.position.y + (rend.bounds.size.y/2), transform.position.z);
    }

    void OnMouseEnter(){
        rend.material.color = hoverColor;
    }

    void OnMouseExit(){
        rend.material.color = startColor;
    }
}
