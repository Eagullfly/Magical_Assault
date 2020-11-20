using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    [HideInInspector]
    public Animator animator;

    public int startHealth = 100;
    private int health;

    public int value = 20;

    [Header("Unity Stuff")]
    public Image healthBar;

    private bool isDead = false;
    

    private Transform target;
    private int wavePointIndex = 0;

    void Start()
    {
        target = WayPoints.points[0];
        health = startHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if(health <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        PlayerStats.Money += value;
        animator.SetBool("Alive", false);

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject, 0.15f);
    }

    void Update()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector2.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(wavePointIndex >= WayPoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        
        Transform prevTarget = WayPoints.points[wavePointIndex];
        wavePointIndex++;
        
        target = WayPoints.points[wavePointIndex];
        Animate(target, prevTarget);
        
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

    private void Animate(Transform target, Transform prevTarget)
    {
        if (target.position.x < prevTarget.position.x)
        {
            animator.SetInteger("Horizontal", -1);
            animator.SetInteger("Vertical", 0);
            animator.SetBool("Alive", true);
        }
        else if(target.position.y < prevTarget.position.y)
        {
            animator.SetInteger("Horizontal", 0);
            animator.SetInteger("Vertical", -1);
            animator.SetBool("Alive", true);
        }
        else if(target.position.x > prevTarget.position.x)
        {
            animator.SetInteger("Horizontal", 1);
            animator.SetInteger("Vertical", 0);
            animator.SetBool("Alive", true);
        }
        else if(target.position.y > prevTarget.position.y)
        {
            animator.SetInteger("Horizontal", 0);
            animator.SetInteger("Vertical", 1);
            animator.SetBool("Alive", true);
        }
    }

    
    
}
