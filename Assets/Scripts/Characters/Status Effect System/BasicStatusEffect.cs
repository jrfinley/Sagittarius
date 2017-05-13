using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicStatusEffect : BaseStatusEffect, IStatusEffect
{
    public void InitializeStatusEffect(BaseCharacter _character, int _iterationNumber)
    {
        IterationNumber = _iterationNumber;
        Character = _character;
        Character.hasStatusEffect = true;
        EventManager = FindObjectOfType<PlayerEventManager>();
        EffectManager = FindObjectOfType<StatusEffectManager>();

        Character.statusEffects.Add(IterationNumber);
        EffectManager.activeStatusEffects.Add(gameObject);

        if (ExpireType == EBuffExpiration.MOVEMENT_BASED)
            EventManager.OnPlayerMove += ExpireStatusEffect;
        else if (ExpireType == EBuffExpiration.BATTLE_BASED)
            EventManager.OnBattleStart += ExpireStatusEffect;
        else if (ExpireType == EBuffExpiration.TIME_BASED)
            StartCoroutine(TimeExpiration());

        ApplyStatusEffect();
    }
    public void ApplyStatusEffect()
    {
        Character.Health += HealthChange;
        Character.Strength += StrengthChange;
        Character.Dexterity += DexterityChange;
        Character.Intelect += IntelectChange;
        Character.Experience += ExperienceChange;
        Character.EquipmentCapacity += EquipmentCapacityChange;
        Character.ExpMultipier += ExpMultiplierChange;
    }
    public void ExpireStatusEffect()
    {
        ExpireTime--;

        if (ExpireTime > 0)
            return;

        EffectManager.activeStatusEffects.Remove(gameObject);
        for (int i = 0; i < Character.statusEffects.Count; i++)
            if (Character.statusEffects[i] == IterationNumber)
            {
                Character.statusEffects.Remove(Character.statusEffects[i]);
                break;
            }

        if (ExpireType == EBuffExpiration.MOVEMENT_BASED)
            EventManager.OnPlayerMove -= ExpireStatusEffect;
        else if (ExpireType == EBuffExpiration.BATTLE_BASED)
            EventManager.OnBattleStart -= ExpireStatusEffect;

        if (Character.statusEffects.Count == 0)
            Character.hasStatusEffect = false;
        Character.Strength -= StrengthChange;
        Character.Dexterity -= DexterityChange;
        Character.Intelect -= IntelectChange;
        Character.EquipmentCapacity -= EquipmentCapacityChange;
        Character.ExpMultipier -= ExpMultiplierChange;

        Destroy(gameObject);
    }

    public IEnumerator TimeExpiration()
    {
        yield return new WaitForSeconds(1f);

        ExpireTime -= 1;

        if (ExpireTime > 0)
            StartCoroutine(TimeExpiration());
        else
            ExpireStatusEffect();
    }
}
