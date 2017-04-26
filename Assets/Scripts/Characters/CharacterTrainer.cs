using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterTrainer : MonoBehaviour
{
    public int expGainPerTick,
               healthGainPerTick,
               dexterityGainPerTick,
               strengthGainPerTick,
               intelectGainPerTick;

    [Header("Tick Time In Seconds")]
    public float expGainTick,
                 statTrainTick;

    public List<BaseCharacter> charactersTraining;

    private CurrencyManager currencyManager;

    private void Start()
    {
        currencyManager = FindObjectOfType<CurrencyManager>();
    }

    public void AddCharacter(BaseCharacter character, float timeToTrain, int goldToSpend, bool trainHealth,
                             bool trainDexterity, bool trainStrength, bool trainIntelect)
    {
        for (int i = 0; i < charactersTraining.Count; i++)
            if (charactersTraining[i] == character || character.IsPartyMember)
                return;

        if (currencyManager.Gold.Value >= goldToSpend)
        {
            //convert hours to seconds
            timeToTrain *= 120;

            currencyManager.Gold.Value -= goldToSpend;
            character.IsTraining = true;

            charactersTraining.Add(character);
            StartCoroutine(StartStatTraining(character, timeToTrain, trainHealth, trainDexterity, trainStrength, trainIntelect));
            StartCoroutine(StartExpTraining(character, timeToTrain));
        }
    }

    IEnumerator StartExpTraining(BaseCharacter character, float timeToTrain)
    {
        float currentTime = 0;

        while (currentTime <= timeToTrain)
        {
            yield return new WaitForSeconds(expGainTick);

            character.Experience += expGainPerTick;
            currentTime += expGainTick;
        }

        character.IsTraining = false;
        charactersTraining.Remove(character);
    }
    IEnumerator StartStatTraining(BaseCharacter character, float timeToTrain, bool trainHealth,
                                  bool trainDexterity, bool trainStrength, bool trainIntelect)
    {
        float currentTime = 0;

        while (currentTime <= timeToTrain)
        {
            yield return new WaitForSeconds(statTrainTick);

            if (trainHealth)
                character.MaxHealth += healthGainPerTick;
            if (trainDexterity)
                character.Dexterity += dexterityGainPerTick;
            if (trainStrength)
                character.Strength += strengthGainPerTick;
            if (trainIntelect)
                character.Intelect += intelectGainPerTick;

            currentTime += statTrainTick;
        }
    }
}
