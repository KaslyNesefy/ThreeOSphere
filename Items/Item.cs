using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private protected Characteristics _characteristics;
    private void Awake() => InitializeItem();

    private protected virtual void InitializeItem() => _characteristics = new Characteristics();
    public virtual short GetValue(byte index) => _characteristics.GetValue(index);
    public virtual byte GetCharacteristicsAmount() => _characteristics.GetCharacteristicsAmount();
}
