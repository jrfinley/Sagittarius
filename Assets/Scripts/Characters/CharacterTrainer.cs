using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public struct TrainingCharacter
{
    public BaseCharacter character;

    public DateTime startTime;
    public DateTime endTime;

    public int healthIncrease;
    public int dexterityIncrease;
    public int strengthIncrease;
    public int intelectIncrease;
}

public class CharacterTrainer : MonoBehaviour
{
    public List<TrainingCharacter> trainingCharacters = new List<TrainingCharacter>();

    private CurrencyManager currencyManager;

    private void Start()
    {
        currencyManager = FindObjectOfType<CurrencyManager>();
    }
    private void Update()
    {
        for (int i = 0; i < trainingCharacters.Count; i++)
            if (DateTime.Now > trainingCharacters[i].endTime)
                RemoveCharacter(trainingCharacters[i]);
    }

    public void AddCharacter(BaseCharacter character, float timeToTrain, int goldToSpend, int healthIncrease,
                             int dexterityIncrease, int strengthIncrease, int intelectIncrease)
    {
        for (int i = 0; i < trainingCharacters.Count; i++)
            if (trainingCharacters[i].character == character || character.IsPartyMember)
                return;

        if (currencyManager.Gold.Value >= goldToSpend)
        {
            character.IsTraining = true;
            currencyManager.Gold.Value -= goldToSpend;

            TrainingCharacter _trainingCharacter = new TrainingCharacter();

            DateTime _endTime = DateTime.Now;
            //CHANGE TO HOURS WHEN DONE TESTING
            _endTime = _endTime.AddSeconds(timeToTrain);
            //CHANGE TO HOURS WHEN DONE TESTING

            _trainingCharacter.character = character;
            _trainingCharacter.startTime = DateTime.Now;
            _trainingCharacter.endTime = _endTime;
            _trainingCharacter.healthIncrease = healthIncrease;
            _trainingCharacter.dexterityIncrease = dexterityIncrease;
            _trainingCharacter.strengthIncrease = strengthIncrease;
            _trainingCharacter.intelectIncrease = intelectIncrease;

            trainingCharacters.Add(_trainingCharacter);
        }
    }
    public void LoadCharacter(BaseCharacter character, DateTime endTime, int healthIncrease, int dexterityIncrease, 
                              int strengthIncrease, int intelectIncrease)
    {
        for (int i = 0; i < trainingCharacters.Count; i++)
            if (trainingCharacters[i].character == character || character.IsPartyMember)
                return;

        TrainingCharacter _trainingCharacter = new TrainingCharacter();

        character.IsTraining = true;
        _trainingCharacter.character = character;
        _trainingCharacter.startTime = DateTime.Now;
        _trainingCharacter.endTime = endTime;
        _trainingCharacter.healthIncrease = healthIncrease;
        _trainingCharacter.dexterityIncrease = dexterityIncrease;
        _trainingCharacter.strengthIncrease = strengthIncrease;
        _trainingCharacter.intelectIncrease = intelectIncrease;

        trainingCharacters.Add(_trainingCharacter);
    }

    void RemoveCharacter(TrainingCharacter _trainingCharacter)
    {
        _trainingCharacter.character.IsTraining = false;

        _trainingCharacter.character.MaxHealth += _trainingCharacter.healthIncrease;
        _trainingCharacter.character.Health += _trainingCharacter.healthIncrease;
        _trainingCharacter.character.Dexterity += _trainingCharacter.dexterityIncrease;
        _trainingCharacter.character.Strength += _trainingCharacter.strengthIncrease;
        _trainingCharacter.character.Intelect += _trainingCharacter.intelectIncrease;

        print("Removing " + _trainingCharacter.character.Name);

        trainingCharacters.Remove(_trainingCharacter);
    }
}
