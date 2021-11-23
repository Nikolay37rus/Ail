using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FightWindowView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _countMoneyText;

    [SerializeField]
    private TMP_Text _countHealthText;

    [SerializeField]
    private TMP_Text _countPowerText;

    [SerializeField]
    private TMP_Text _countPowerEnemyText;

    [SerializeField]
    private TMP_Text _countArmorText;

    [SerializeField]
    private TMP_Text _countCrimeText;


    [SerializeField]
    private Button _addCoinsButton;

    [SerializeField]
    private Button _minusCoinsButton;


    [SerializeField]
    private Button _addHealthButton;

    [SerializeField]
    private Button _minusHealthButton;


    [SerializeField]
    private Button _addPowerButton;

    [SerializeField]
    private Button _minusPowerButton;

    [SerializeField]
    private Button _addArmorButton;

    [SerializeField]
    private Button _minusArmorButton;

    [SerializeField]
    private Button _addCrimeButton;

    [SerializeField]
    private Button _minusCrimeButton;


    [SerializeField]
    private Button _fightButton;

    [SerializeField]
    private Button _passpeacefully;

    private Money _money;
    private Health _health;
    private Power _power;
    private Armor _armor;
    private Crime _crime;

    private int _allCountMoneyPlayer;
    private int _allCountHealthPlayer;
    private int _allCountPowerPlayer;
    private int _allCountArmorPlayer;
    private int _allCountCrimePlayer;

    private Enemy _enemy;

    private void Start()
    {
        _enemy = new Enemy("Enemy");

        _money = new Money();
        _money.Attach(_enemy);

        _health = new Health();
        _health.Attach(_enemy);

        _power = new Power();
        _power.Attach(_enemy);

        _armor = new Armor();
        _armor.Attach(_enemy);

        _crime = new Crime();
        _crime.Attach(_enemy);

        _addCoinsButton.onClick.AddListener(() => ChangeMoney(true));
        _minusCoinsButton.onClick.AddListener(() => ChangeMoney(false));

        _addHealthButton.onClick.AddListener(() => ChangeHealth(true));
        _minusHealthButton.onClick.AddListener(() => ChangeHealth(false));

        _addPowerButton.onClick.AddListener(() => ChangePower(true));
        _minusPowerButton.onClick.AddListener(() => ChangePower(false));

        _addArmorButton.onClick.AddListener(() => ChangeArmor(true));
        _minusArmorButton.onClick.AddListener(() => ChangeArmor(false));

        _addCrimeButton.onClick.AddListener(() => ChangeCrime(true));
        _minusCrimeButton.onClick.AddListener(() => ChangeCrime(false));

        _fightButton.onClick.AddListener(Fight);
        _passpeacefully.onClick.AddListener(Passpeacefully);
    }

    private void OnDestroy()
    {
        _addCoinsButton.onClick.RemoveAllListeners();
        _minusCoinsButton.onClick.RemoveAllListeners();

        _addCoinsButton.onClick.RemoveAllListeners();
        _minusCoinsButton.onClick.RemoveAllListeners();

        _addCoinsButton.onClick.RemoveAllListeners();
        _minusCoinsButton.onClick.RemoveAllListeners();

        _addArmorButton.onClick.RemoveAllListeners();
        _minusArmorButton.onClick.RemoveAllListeners();

        _addCrimeButton.onClick.RemoveAllListeners();
        _minusCrimeButton.onClick.RemoveAllListeners();

        _fightButton.onClick.RemoveAllListeners();

        _passpeacefully.onClick.RemoveAllListeners();

        _money.Detach(_enemy);
        _health.Detach(_enemy);
        _power.Detach(_enemy);
        _armor.Detach(_enemy);
        _crime.Detach(_enemy);
    }

    private void Fight()
    {
        Debug.Log(_allCountPowerPlayer > _enemy.Power ? "Win" : "Lose");
    }

    private void Passpeacefully()
    {
        Debug.Log(_allCountCrimePlayer < 3 ? "Wine" : "Lose");
    }
    private void ChangePower(bool isAddCount)
    {
        if (isAddCount)
            _allCountPowerPlayer++;
        else
            _allCountPowerPlayer--;

        ChangeDataWindow(_allCountPowerPlayer, DataType.Power);
    }

    private void ChangeHealth(bool isAddCount)
    {
        if (isAddCount)
            _allCountHealthPlayer++;
        else
            _allCountHealthPlayer--;

        ChangeDataWindow(_allCountHealthPlayer, DataType.Health);
    }

    private void ChangeMoney(bool isAddCount)
    {
        if (isAddCount)
            _allCountMoneyPlayer++;
        else
            _allCountMoneyPlayer--;

        ChangeDataWindow(_allCountMoneyPlayer, DataType.Money);
    }

    private void ChangeArmor(bool isAddCount)
    {
        if (isAddCount)
            _allCountArmorPlayer++;
        else
            _allCountArmorPlayer--;

        ChangeDataWindow(_allCountArmorPlayer, DataType.Armor);
    }

    private void ChangeCrime(bool isAddCount)
    {
        if (isAddCount)
            _allCountCrimePlayer++;
        else
            _allCountCrimePlayer--;

        ChangeDataWindow(_allCountCrimePlayer, DataType.Crime);
    }

    private void ChangeDataWindow(int countChageData, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Money:
                _countMoneyText.text = $"Player Money: {countChageData}";
                _money.CountMoney = countChageData;
                break;

            case DataType.Health:
                _countHealthText.text = $"Player Health: {countChageData}";
                _health.CountHealth = countChageData;
                break;

            case DataType.Power:
                _countPowerText.text = $"Player Power: {countChageData}";
                _power.CountPower = countChageData;
                break;


            case DataType.Armor:
                _countArmorText.text = $"Player Armor: {countChageData}";
                _armor.CountArmor = countChageData;
                break;

            case DataType.Crime:
                _countCrimeText.text = $"Player Crime: {countChageData}";
                _crime.CountCrime = countChageData;
                break;



        }

        _countPowerEnemyText.text = $"Player Enemy: {_enemy.Power}";
    }
}
