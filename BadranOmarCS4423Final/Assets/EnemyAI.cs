using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    public Enemy myEnemy;
    public Player targetPlayer;
    //state machine
    EnemyAIState currState;

    public EnemyAIPatrolState patrolState{get; private set;}
    public EnemyAIShootState shootState{get; private set;}


    public void ChangeAIState(EnemyAIState newState ){
        currState = newState;
        currState.BeginStateBase();
    }

    void Start()
    {
        patrolState = new EnemyAIPatrolState(this);
        shootState = new EnemyAIShootState(this);
        targetPlayer = Player.FindObjectOfType<Player>();
        currState = patrolState;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPlayer == null)
            targetPlayer = Player.FindObjectOfType<Player>();
    }

    void FixedUpdate(){
        currState.UpdateState();
    }

    public Player GetTarget(){
        float x = transform.position.x - targetPlayer.transform.position.x;
        
        if(Mathf.Abs(x) < 8)
            return targetPlayer;
        return null;
    }


    public Vector3 getPosition(){
        return transform.position;
    }

}
