using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
        }
        instance = this;
    }

    public GameObject MachineGunPrefab;
    public GameObject CannonPrefab;
    

    private TurretBlueprint turretToBuild;
    private BuildTowers selectedTile;

    public SelectUI selectUI;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    

    public void SelectTile(BuildTowers tile)
    {
        if(selectedTile == tile)
        {
            DeselectTile();
            return;
        }
        selectedTile = tile;
        turretToBuild = null;

        selectUI.SetTarget(tile);
    }

    public void DeselectTile()
    {
        selectedTile = null;
        selectUI.Hide();
    }
    
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;

        DeselectTile();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    } 
}
