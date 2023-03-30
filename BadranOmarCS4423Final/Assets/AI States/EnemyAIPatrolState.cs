using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIPatrolState : EnemyAIState
{

    public EnemyAIPatrolState(EnemyAI enemyAI): base(enemyAI){

    }

    void start(){

    } 
    public override void UpdateState()
    {
        if(enemyAI.GetTarget() != null){
            enemyAI.ChangeAIState(enemyAI.shootState);
            return;
        }else{
            enemyAI.myEnemy.Patrol();
        }

    }


    public override void BeginState()
    {
        
    }

}
