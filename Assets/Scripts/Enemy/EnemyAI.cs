using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        Roaming
    }

    private State state;
    private EnemyPathFinding enemyPathFinding;


    private void Awake()
    {
        state = State.Roaming;
        enemyPathFinding = GetComponent<EnemyPathFinding>();
    }

    private void Start()
    {
        StartCoroutine(RoamingRoute());
    }



    private IEnumerator RoamingRoute()
    {
        while(state == State.Roaming)
        {
            Vector2 movePosition = GetRoamingPosition();
            enemyPathFinding.SetMovePosition(movePosition);
            yield return new WaitForSeconds(2f);

        }
    }

    private Vector2 GetRoamingPosition()
    {
        Vector2 randomPosition = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        return randomPosition;
    }



}
