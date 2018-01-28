using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent(typeof(Seeker))]

public class EnemyAI : MonoBehaviour {

    //What to chase?
    public Transform target;

    //How many times each second we will update path
    public float updateRate = 1f;

    //Caching
    private Seeker seeker;
    private Rigidbody2D rb;

    //The calculated path
    public Path path;

    //The AI's speed per second
    public float speed = 300f;
    public ForceMode2D fmode;

    [HideInInspector]
    public bool pathIsEnded = false;

    //The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWayPointDistance = 3;

    //The waypoint we are currently moving towards
    private int currentWaypoint = 0;

    private bool searchingForPlayer = false;

    private Vector3 direction;

    public Bullet bullprefab;

    void Start()
    {
        InvokeRepeating("increaseMonsterSpeed", 1.0f, 1.0f);
        InvokeRepeating("shoot", 1.0f, 1.0f);

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if (target == null)
        {
            if (!searchingForPlayer)
            {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
            return;
        }

        //Start a new path to the target position, return the result to the OnPathComplete method
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath());
    }

    IEnumerator SearchForPlayer()
    {
        GameObject sResult = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Player").transform;
        if (sResult == null)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(SearchForPlayer());
        }
        else
        {
            target = sResult.transform;
            searchingForPlayer = false;
            StartCoroutine(UpdatePath());
            yield return false;
        }
    }

    IEnumerator UpdatePath()
    {
        if (target == null)
        {
            if (!searchingForPlayer)
            {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
            yield return false;
        }

        seeker.StartPath(transform.position, target.position, OnPathComplete);

        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());
    }

    public void OnPathComplete (Path p)
    {
        Debug.Log("We got a path. Did it have an error? " + p.error);
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {

        if (target == null)
        {
            //TODO: insert player search
            return;
        }

        //TODO: Always look at player 

        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
                return;

            Debug.Log("End of path reached.");
            pathIsEnded = true;
            return;
        }
        pathIsEnded = false;

        //Direction to the next waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        this.direction = dir;
        dir *= speed * Time.fixedDeltaTime;

        //Move the AI
        rb.AddForce(dir, fmode);

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (dist < nextWayPointDistance)
        {
            currentWaypoint++;
            return;
        }
    }

    void increaseMonsterSpeed()
    {
        if (this.speed >= 3000)
        {
            return;
        }
        this.speed += 50;
    }

    void shoot()
    {
        Bullet shootingBullet = Instantiate(bullprefab, transform.position, transform.rotation);
        shootingBullet.GetComponent<Rigidbody2D>().velocity = this.direction * 5;
    }

}
