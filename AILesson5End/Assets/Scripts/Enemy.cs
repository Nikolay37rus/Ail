using UnityEngine;

public class Enemy : IEnemy
{
    private string _name;

    private int _moneyPlayer;
    private int _healthPlayer;
    private int _powerPlayer;
    private int _armorPlayer;
    private int _crimePlayer;

    public int Power
    {
        get 
        {
            var power = _moneyPlayer + _healthPlayer - _powerPlayer * _armorPlayer;
            return power;
        }
    }

    public Enemy(string name)
    {
        _name = name;
    }

    public void Update(DataPlayer dataPlayer, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Money:
                var dataMoney = (Money)dataPlayer;
                 _moneyPlayer = dataMoney.CountMoney;
                break;

            case DataType.Health:
                var dataHealth = (Health)dataPlayer;
                _healthPlayer = dataHealth.CountHealth;
                break;

            case DataType.Power:
                var dataPower = (Power)dataPlayer;
                _powerPlayer = dataPower.CountPower;
                break;

            case DataType.Armor:
                var dataArmor = (Armor)dataPlayer;
                _powerPlayer = dataArmor.CountArmor;
                break;

            case DataType.Crime:
                var dataCrime = (Crime)dataPlayer;
                _powerPlayer = dataCrime.CountCrime;
                break;

        }

        Debug.Log($"Update {_name}, change {dataType}");
    }  
}
