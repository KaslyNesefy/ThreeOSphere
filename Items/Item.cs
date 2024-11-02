using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private protected Characteristics _characteristics;
    private static byte _id = 0;
    private void Awake() => Initialize();

    private protected virtual void Initialize() => _characteristics = new Characteristics();
    public virtual short GetValue(byte index) => _characteristics.GetValue(index);
    public virtual short GetValue(CharacteristicsIndexes index) => _characteristics.GetValue(index);
    public virtual byte GetCharacteristicsAmount() => _characteristics.GetCharacteristicsAmount();
    public virtual byte GetId() => _id;
    private protected virtual void SetId() => _id++;
}
