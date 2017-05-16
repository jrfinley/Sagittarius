public interface IStatusEffect
{
    EBuffExpiration ExpireType
    { get; set; }
    EBuffType BuffType
    { get; set; }

    int HealthChange
    { get; set; }
    int StrengthChange
    { get; set; }
    int DexterityChange
    { get; set; }
    int IntelectChange
    { get; set; }
    int ExperienceChange
    { get; set; }
    int EquipmentCapacityChange
    { get; set; }
    int IterationNumber
    { get; set; }

    float ExpireTime
    { get; set; }
    float ExpMultiplierChange
    { get; set; }

    BaseCharacter Character
    { get; set; }
    PlayerEventManager EventManager
    { get; set; }

    void InitializeStatusEffect(BaseCharacter _character, int _iterationNumber);
    void ApplyStatusEffect();
    void ExpireStatusEffect();
}
