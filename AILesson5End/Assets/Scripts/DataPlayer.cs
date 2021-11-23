using System.Collections.Generic;

public class DataPlayer
{
    private List<IEnemy> _enimies = new List<IEnemy>();

    public void Attach(IEnemy enemy)
    {
        _enimies.Add(enemy);
    }

    public void Detach(IEnemy enemy)
    {
        _enimies.Remove(enemy);
    }

    protected void Notifier(DataType dataType)
    {
        foreach(var enemy in _enimies)
            enemy.Update(this, dataType);
    }
}

public class Money : DataPlayer
{
    private int _countMoney;

    public int CountMoney
    {
        get => _countMoney;
        set
        {
            if (_countMoney != value)
            {
                _countMoney = value;
                Notifier(DataType.Money);
            }
        }
    }
}

public class Health : DataPlayer
{
    private int _countHealth;

    public int CountHealth
    {
        get => _countHealth;
        set
        {
            if (_countHealth != value)
            {
                _countHealth = value;
                Notifier(DataType.Health);
            }
        }
    }
}

public class Power : DataPlayer
{
    private int _countPower;

    public int CountPower
    {
        get => _countPower;
        set
        {
            if (_countPower != value)
            {
                _countPower = value;
                Notifier(DataType.Power);
            }
        }
    }
}

public class Armor : DataPlayer
{
    private int _countArmor;

    public int CountArmor
    {
        get => _countArmor;
        set
        {
            if (_countArmor != value)
            {
                _countArmor = value;
                Notifier(DataType.Armor);
            }
        }
    }
}

public class Crime : DataPlayer
{
    private int _countCrime;

    public int CountCrime
    {
        get => _countCrime;
        set
        {
            if (_countCrime != value)
            {
                _countCrime = value;
                Notifier(DataType.Crime);
            }
        }
    }
}

