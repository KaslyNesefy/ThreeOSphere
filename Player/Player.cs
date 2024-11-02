using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    private protected Characteristics _characteristics;
    private protected List<Item> _items;

    private void Awake() => InitializePlayer();

    private protected virtual void InitializePlayer()
    {
        _characteristics = new Characteristics();
        _items = new List<Item>();
        ResetCharacteristics();
    }
    private protected virtual void ResetCharacteristics() => _characteristics.ResetCharacteristics();

    private protected virtual void RefreshCharacteristics()
    {
        ResetCharacteristics();

        if (_items is null)
            return;

        foreach (Item item in _items)
        {
            for (byte i = 0; i < item.GetCharacteristicsAmount(); i++)
                _characteristics.ChangeValue(i, item.GetValue(i));
        }
    }

    public virtual void GetCharacteristicValue(CharacteristicsIndexes index) => _characteristics.GetValue(index);

    public virtual void AddItem(Item item)
    {
        _items.Add(item);
        RefreshCharacteristics();
    }
    public virtual void LoseItem(Item item)
    {
        if (!_items.Exists(existingItem => existingItem.GetId() == item.GetId()))
            return;
        _items.Remove(item);
        RefreshCharacteristics();
    }
}