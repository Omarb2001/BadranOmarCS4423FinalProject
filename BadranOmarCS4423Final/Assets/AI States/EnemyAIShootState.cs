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
        Transform pos;


        Vector3 enemyPos = enemyAI.getPosition();
        Player ply =  enemyAI.GetTarget();

        if(ply != null){
            pos = ply.transform;
            enemyAI.myEnemy.Chase(pos);
        }else{
            enemyAI.ChangeAIState(enemyAI.patrolState);
        }
    }

}
