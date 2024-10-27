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
    }

    private protected virtual void RefreshCharacteristics() 
    {


        if (_items is null)
            return;



        foreach (Item item in _items)
        {
            for (byte i = 0; i < item.GetCharacteristicsAmount(); i++)
                _characteristics.ChangeValue(i, item.GetValue(i));
        }
    }

}