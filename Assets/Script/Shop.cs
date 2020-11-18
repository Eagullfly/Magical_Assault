using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint machineGun;
    public TurretBlueprint cannon;
    
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectMachineGun()
    {
        Debug.Log("Machine gun selected");
        buildManager.SelectTurretToBuild(machineGun);
    }

    public void SelectCannon()
    {
        Debug.Log("Cannon selected");
        buildManager.SelectTurretToBuild(cannon);
    }

    
}
