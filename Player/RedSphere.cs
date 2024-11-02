using UnityEngine;

public class RedSphere : Player
{
    private protected override void ResetCharacteristics() 
    { 
        base.ResetCharacteristics();

        _characteristics.ChangeValue(CharacteristicsIndexes.Physical, 3);
    }
}