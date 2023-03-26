using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIPatrolState : EnemyAIState
{

    public EnemyAIPatrolState(EnemyAI enemyAI): base(enemyAI){

    }
    public override void UpdateState()
    {
    
        if(enemyAI.GetTarget() != null){
            enemyAI.ChangeAIState(enemyAI.shootState);
        }
    }

    public override void BeginState()
    {
        
    }
}
