using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterTrainer : MonoBehaviour
{
    //Temp for testing. This will be the amount gold the player wants to spend
    public int goldToSpendAmount;

    public int expGainPerTick,
               secondsPerGold;

    public float expGainTick;

    public List<BaseCharacter> charactersTraining;

    private CurrencyManager currencyManager;

    private void Start()
    {
        currencyManager = FindObjectOfType<CurrencyManager>();
    }

    public void AddCharacter(BaseCharacter character, int goldToSpend)
    {
        for (int i = 0; i < charactersTraining.Count; i++)
            if (charactersTraining[i] == character || character.IsPartyMember)
                return;

        if (currencyManager.Gold.Value >= goldToSpend)
        {
            float timeToTrain = goldToSpend * secondsPerGold;

            currencyManager.Gold.Value -= goldToSpend;
            character.IsTraining = true;

            charactersTraining.Add(character);
            StartCoroutine(StartTraining(character, timeToTrain));
        }
    }

    IEnumerator StartTraining(BaseCharacter character, float timeToTrain)
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
}
