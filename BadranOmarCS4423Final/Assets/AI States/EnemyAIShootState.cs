using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIShootState : EnemyAIState
{

    public EnemyAIShootState(EnemyAI enemyAI): base(enemyAI){

    }
    
    public override void BeginState()
    {
        
    }

    public override void UpdateState()
    {
        Vector3 pos = enemyAI.GetTarget().transform.position;
        pos.x -= 3;
        if(enemyAI.GetTarget() != null)
            enemyAI.myEnemy.MoveToward(pos);
        else 
            enemyAI.ChangeAIState(enemyAI.patrolState);
    }

}
