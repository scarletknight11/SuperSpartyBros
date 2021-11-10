using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour {

    public List<Transform> points;
    public Transform platform;
    int goalPoint;
    public float moveSpeed = 2;

    private void Update()
    {
        MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
        //change the position of the platform (move towards the goal point)
        platform.position = Vector2.MoveTowards(platform.position, points[goalPoint].position, Time.deltaTime*moveSpeed);
        //Check if we are in very close proximity of the next point
        if (Vector2.Distance(platform.position, points[goalPoint].position)< 0.1f)
        {
            //If so change goal point to the next one
            if (goalPoint == points.Count - 1)
                goalPoint = 0;
            else
                goalPoint++;
            //Check if we reached the last element, reset to first point
            // 0 1  (total 2)

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

           collision.transform.SetParent(null);
        }
    }

}
