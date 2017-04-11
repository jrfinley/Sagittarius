using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager : MonoBehaviour
{
    public List<BaseCharacter> allCharacters;

    public List<Warrior> warriors;
    public List<Rogue> rogues;
    public List<Mage> mages;

    private PlayerParty playerParty;

    private void Start()
    {
        playerParty = FindObjectOfType<PlayerParty>();

        //remove this call when saving gets implemented
        FindAllCharacters();
    }

    //Call this when loading all unlocked characters
    public void FindAllCharacters()
    {
        allCharacters.Clear();
        allCharacters.AddRange(GetComponents<BaseCharacter>());
    }

    public void CreateCharacter(ECharacterType characterType, string name, int level)
    {
        BaseCharacter newCharacter = new BaseCharacter();

        switch (characterType)
        {
            case ECharacterType.WARRIOR:
                Warrior newWarrior = gameObject.AddComponent<Warrior>();
                newWarrior.InitializeCharacter(name, level);
                AddCharacter(newWarrior);
                newCharacter = newWarrior;
                break;

            case ECharacterType.ROGUE:
                Rogue newRogue = gameObject.AddComponent<Rogue>();
                newRogue.InitializeCharacter(name, level);
                AddCharacter(newRogue);
                newCharacter = newRogue;
                break;

            case ECharacterType.MAGE:
                Mage newMage = gameObject.AddComponent<Mage>();
                newMage.InitializeCharacter(name, level);
                AddCharacter(newMage);
                newCharacter = newMage;
                break;
        }

        allCharacters.Add(newCharacter);
    }

    void AddCharacter(Warrior newCharacter)
    {
        warriors.Add(newCharacter);
    }
    void AddCharacter(Rogue newCharacter)
    {
        rogues.Add(newCharacter);
    }
    void AddCharacter(Mage newCharacter)
    {
        mages.Add(newCharacter);
    }
}
