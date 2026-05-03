using System.Collections.Generic;
using UnityEngine;

public class ResetTimer : MonoBehaviour
{
    public float maxRemainingTime;
    float remainingTime;

    List<Vector2> oldRecordedPositions = new List<Vector2>();

    GameObject player;
    GameObject ghost;

    GameObject spawnPoint;

    bool firstTime = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ghost = GameObject.FindGameObjectWithTag("Ghost");
        spawnPoint = GameObject.FindGameObjectWithTag("Spawn Point");
    }

    private void FixedUpdate()
    {
        
        if (remainingTime <= 0)
        {
            remainingTime = maxRemainingTime;

            if (!firstTime)
            { 
                Debug.Log("Time is over");
                Reset();
            }
            else
            { 
                firstTime = true;
            }
        }
        else
        {
            if (oldRecordedPositions.Count > 0)
            { 
                ghost.transform.position = oldRecordedPositions[0];
                oldRecordedPositions.RemoveAt(0);
            }

            remainingTime -= Time.fixedDeltaTime;
            Debug.Log(remainingTime);
        }

    }

    private void Reset()
    {
        Movement m = player.GetComponent<Movement>();

        player.transform.position = spawnPoint.transform.position;
        ghost.transform.position = spawnPoint.transform.position;

        oldRecordedPositions.Clear();
        oldRecordedPositions = new List<Vector2>(m.newRecordedPositions); ;
        m.newRecordedPositions.Clear();
    }
}
