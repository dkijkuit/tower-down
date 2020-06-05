using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ConcreteTile : MonoBehaviour
{
    public Color hoverColor;

    [Header("Optional")]
    public GameObject turret;
    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start(){
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    void OnMouseDown(){
        if (!buildManager.CanBuild) return;

        if(turret != null) {
            Debug.Log("Cannot build here!");
            return;
        } 

        buildManager.BuildTurretOn(this);
    }

    void OnMouseEnter(){
        //Is over UI element? Then return.
        if(EventSystem.current.IsPointerOverGameObject()) return;
        if (!buildManager.CanBuild) return;

        rend.material.color = hoverColor;
    }

    void OnMouseExit(){
        rend.material.color = startColor;
    }

    public Vector3 GetBuildPosition(){
        return new Vector3(transform.position.x, transform.position.y + (rend.bounds.size.y/2), transform.position.z);
    }
}
