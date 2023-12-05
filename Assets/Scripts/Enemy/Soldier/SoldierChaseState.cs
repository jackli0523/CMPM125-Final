using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoldierChaseState : BaseState
{
    public override void OnEnter(Enemy enemy)
    {
        currentEnemy = enemy;
        currentEnemy.currentSpeed = currentEnemy.chaseSpeed;
    }

    public override void LogicUpdate()
    {
        if (((Soldier)currentEnemy).triggerDodge && ((Soldier)currentEnemy).dodgeTimer == 0)
        {
            currentEnemy.SwitchState(EnemyState.dodge);
            return;
        }
        if (currentEnemy.targetInAttackRange && currentEnemy.targetChaseable)
        {
            currentEnemy.SwitchState(EnemyState.attack);
            return;
        }
        if (!currentEnemy.physicsCheck.isGrounded || currentEnemy.physicsCheck.touchLeftWall ||
         currentEnemy.physicsCheck.touchRightWall || currentEnemy.lostTargetTimeCounter <= 0)
        {
            currentEnemy.SwitchState(EnemyState.patrol);
            return;
        }
    }
    public override void PhysicsUpdate() { }
    public override void OnExit()
    {
    }
}