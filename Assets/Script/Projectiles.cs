using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public static void Create(Vector3 spawnPosition)
    {
        Instantiate(GameManager.Instance.projectile01, spawnPosition, Quaternion.identity);
    }
}
