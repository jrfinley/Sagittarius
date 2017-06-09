public struct DropTableElement {
    public EEquipmentType item;
    public float dropChance; //value from  0-1

    public DropTableElement(EEquipmentType item, float dropChance) {
        this.item = item;
        this.dropChance = dropChance;
    }
}