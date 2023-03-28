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
        
        if(Mathf.Abs(x) < 8  && isFacingPlayer())
            return targetPlayer;
        return null;
    }

    public bool isFacingPlayer(){
        float x = targetPlayer.transform.position.x;
        float y = targetPlayer.transform.position.y;
        float enemyX = transform.position.x;
        float enemyY = transform.position.y;

        float diffInHeight = Mathf.Abs(y-enemyY);
        float rotation = transform.rotation.y;
        //Debug.Log(rotation);
        if( diffInHeight < 0.1 && ((x < enemyX && Mathf.Abs(rotation) != 0) || (x > enemyX && Mathf.Abs(rotation) % 360 == 0))){
            //Debug.Log("it works!");
            return true;
        }
        return false;
    }

    public Vector3 getPosition(){
        return transform.position;
    }

}
