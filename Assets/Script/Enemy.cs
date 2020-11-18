using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public Animator animator;

    public int health = 100;

    public int value = 20;

    private Transform target;
    private int wavePointIndex = 0;

    void Start()
    {
        target = WayPoints.points[0];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += value;
        animator.SetBool("Alive", false);
        Destroy(gameObject, 0.25f);
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
        //Debug.Log(target.position.x + " " + target.position.y);
        Transform prevTarget = WayPoints.points[wavePointIndex];
        wavePointIndex++;
        
        target = WayPoints.points[wavePointIndex];
        Animate(target, prevTarget);
        
    }

    void EndPath()
    {
        PlayerStats.Lives--;
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
