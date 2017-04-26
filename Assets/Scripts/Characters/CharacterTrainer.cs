using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterTrainer : MonoBehaviour
{
    //Temp for testing. This will be the amount gold the player wants to spend
    public int goldToSpendAmount;

    public int expGainPerTick,
               healthGainPerTick,
               dexterityGainPerTick,
               strengthGainPerTick,
               intelectGainPerTick;

    public float expGainTick,
                 statTrainTick;

    public List<BaseCharacter> charactersTraining;

    private CurrencyManager currencyManager;

    private void Start()
    {
        currencyManager = FindObjectOfType<CurrencyManager>();
    }

    public void AddCharacter(BaseCharacter character, int timeToTrain, int goldToSpend, bool trainHealth,
                             bool trainDexterity, bool trainStrength, bool trainIntelect)
    {
        for (int i = 0; i < charactersTraining.Count; i++)
            if (charactersTraining[i] == character || character.IsPartyMember)
                return;

        if (currencyManager.Gold.Value >= goldToSpend)
        {
            timeToTrain = timeToTrain * 60;

            currencyManager.Gold.Value -= goldToSpend;
            character.IsTraining = true;

            charactersTraining.Add(character);
            StartCoroutine(StartStatTraining(character, timeToTrain, trainHealth, trainDexterity, trainStrength, trainIntelect));
            StartCoroutine(StartExpTraining(character, timeToTrain));
        }
    }

    IEnumerator StartExpTraining(BaseCharacter character, int timeToTrain)
    {
        float currentTime = 0;

        while (currentTime < timeToTrain)
        {
            yield return new WaitForSeconds(expGainTick);

            character.Experience += expGainPerTick;
            currentTime += expGainTick;
        }

        character.IsTraining = false;
        charactersTraining.Remove(character);
    }
    IEnumerator StartStatTraining(BaseCharacter character, int timeToTrain, bool trainHealth,
                                  bool trainDexterity, bool trainStrength, bool trainIntelect)
    {
        float currentTime = 0;

        while (currentTime < timeToTrain)
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
