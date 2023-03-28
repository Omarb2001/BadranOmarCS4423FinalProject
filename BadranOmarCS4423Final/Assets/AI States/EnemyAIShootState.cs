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
        Vector3 pos = new Vector3();


        Vector3 enemyPos = enemyAI.getPosition();
        Player ply =  enemyAI.GetTarget();

        if(ply != null){
            pos = ply.transform.position;
            if(enemyPos.x <= pos.x)
                pos.x -= 3;
            else
                pos.x +=3;
            
            pos.y = enemyPos.y;
            
            enemyAI.myEnemy.MoveToward(pos);
        }else{
            enemyAI.ChangeAIState(enemyAI.patrolState);
        }

        enemyAI.myEnemy.Shoot();
    }

}
