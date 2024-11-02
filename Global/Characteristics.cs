using System;

public enum CharacteristicsIndexes
{
    Physical,
    Magical,
    Luck,
    LastPower = Luck
}

public class Characteristics
{
    private short _karma;
    private short[] _characteristicsValues;

    public Characteristics() => Initialize();

    public void Initialize() => _characteristicsValues = new short[(byte)CharacteristicsIndexes.LastPower];

    //public void ChangeValue(CharacteristicsIndexes index, short amount)
    //{
    //    if (amount == 0)
    //        return;

    //    if (amount > 0)
    //    {
    //        IncreaseValue(_characteristicsValues[(byte)index], amount);
    //        return;
    //    }

    //    DecreaseValue(_characteristicsValues[(byte)index], amount);
    //}

    public void ResetCharacteristics()
    {
        for (byte i = 0; i < _characteristicsValues.Length; i++)
        {
            _characteristicsValues[i] = 0;
        }
        _karma = 0;
    }

    public void ChangeValue(byte index, short amount)
    {
        if (amount == 0)
            return;

        try
        {
            _characteristicsValues[index] += amount;
        }
        catch
        {
            _characteristicsValues[index] = amount > 0 ? short.MaxValue : short.MinValue;
        }
    }

    public void ChangeValue(CharacteristicsIndexes index, short amount) => ChangeValue((byte)index, amount);
    //public void ChangeKarma(short amount)
    //{
    //    if (amount == 0)
    //        return;

    //    if (amount > 0)
    //    {
    //        IncreaseValue(_karma, amount);
    //        return;
    //    }

    //    DecreaseValue(_karma, amount);
    //}
    public void ChangeKarma(short amount)
    {
        if (amount == 0)
            return;

        try
        {
            _karma += amount;
        }
        catch
        {
            _karma = amount > 0 ? short.MaxValue : short.MinValue;
        }
    }

    //private void IncreaseValue(short value, short amount) => value = (short.MaxValue - amount) >= value ? value += amount : short.MaxValue;
    //private void DecreaseValue(short value, short amount) => value = (short.MinValue + amount) <= value ? value -= amount : short.MinValue;
    public short GetValue(byte index) => _characteristicsValues[index];
    public short GetValue(CharacteristicsIndexes index) => GetValue((byte)index);
    public short GetKarmaValue(byte index) => _karma;
    public byte GetCharacteristicsAmount() => (byte)_characteristicsValues.Length;
}
//private void IncreaseKarma(short amount) => _karma = (short.MaxValue - amount) >= _karma ? _karma += amount : short.MaxValue;
//private void DecreaseKarma(short amount) => _karma = (short.MinValue + amount) >= _karma ? _karma += amount : short.MinValue;