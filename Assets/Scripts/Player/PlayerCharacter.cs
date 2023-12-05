using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCharacter : Character
{
    public float defence;

    protected override void Start()
    {
        maxHealth = TransformManager.Instance.maxHealth;
        currentHealth = maxHealth;
    }

    public override void TakeDamage(Attack attacker)
    {
        if (invulnerable)
        {
            return;
        }
        float dmgTaken = Mathf.Max((attacker.damage - defence), 1);
        currentHealth = Mathf.Clamp((currentHealth - dmgTaken), 0, maxHealth);
        if (currentHealth > 0)
        {
            TriggerInvulnerable();
            //触发受伤
            OnTakeDamage?.Invoke(attacker.transform);
        }
        else
        {
            //触发死亡
            OnDeath?.Invoke();
        }
        TransformManager.Instance.currentHealth = currentHealth;
    }

}
