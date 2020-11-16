using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public Animator animator;

    private Transform target;
    private int wavePointIndex = 0;

    void Start()
    {
        target = WayPoints.points[0];
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
            Destroy(gameObject);
            return;
        }
        //Debug.Log(target.position.x + " " + target.position.y);
        Transform prevTarget = WayPoints.points[wavePointIndex];
        wavePointIndex++;
        
        target = WayPoints.points[wavePointIndex];
        Animate(target, prevTarget);
        
    }

    private void Animate(Transform target, Transform prevTarget)
    {
        if (target.position.x < prevTarget.position.x)
        {
            animator.SetInteger("Horizontal", -1);
            animator.SetInteger("Vertical", 0);
        }
        else if(target.position.y < prevTarget.position.y)
        {
            animator.SetInteger("Horizontal", 0);
            animator.SetInteger("Vertical", -1);
        }
        else if(target.position.x > prevTarget.position.x)
        {
            animator.SetInteger("Horizontal", 1);
            animator.SetInteger("Vertical", 0);
        }
        else if(target.position.y > prevTarget.position.y)
        {
            animator.SetInteger("Horizontal", 0);
            animator.SetInteger("Vertical", 1);
        }
    }
    public void Spawn()
    {
        transform.position = LevelManager.Instance.SpawnPit.transform.position;
    }
}
