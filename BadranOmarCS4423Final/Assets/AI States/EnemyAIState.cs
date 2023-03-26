using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAIState
{
    protected EnemyAI enemyAI;
    float timer = 0;
    public EnemyAIState(EnemyAI newAI){
        enemyAI = newAI;
        timer = 0;
    }

    //starting state
    public void UpdateStateBase(){
        timer += Time.fixedDeltaTime;
        UpdateState();
    }

    public void BeginStateBase(){
        timer = 0;
        BeginState();
    }
    public abstract void UpdateState();
    //update
    public abstract void BeginState();

}
