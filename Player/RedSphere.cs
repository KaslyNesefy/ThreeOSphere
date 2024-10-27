using UnityEngine;

public class RedSphere : Player
{
    private protected override void InitializePlayer()
    {
        base.InitializePlayer();

        _characteristics[(byte)CharacteristicsIndexes.Physical] += 3;
    }
}
