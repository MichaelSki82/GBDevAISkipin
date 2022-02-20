using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

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
    private TMP_Text _crimeStatusPlayerText;

    [SerializeField]
    private TMP_Text _countKnifePowerEnemyText;


    [SerializeField]
    private Button _addMoneyButton;

    [SerializeField]
    private Button _minusMoneyButton;


    [SerializeField]
    private Button _addHealthButton;

    [SerializeField]
    private Button _minusHealthButton;


    [SerializeField]
    private Button _addPowerButton;

    [SerializeField]
    private Button _minusPowerButton;

    [SerializeField]
    private Button _addCrimeButton;

    [SerializeField]
    private Button _minusCrimeButton;

    [SerializeField]
    private Button _freeWayButton;

    [SerializeField]
    private Button _fightButton;

    [SerializeField]
    private Button _knifeFightButton;

    private Enemy _enemy;

    private Money _money;
    private Health _health;
    private Power _power;
    private Crime _crime;

    private int _allCountMoneyPlayer;
    private int _allCountHealthPlayer;
    private int _allCountPowerPlayer;
    private int _allCountCrimePlayer;

    private void Start()
    {
        _enemy = new Enemy("Flappy");

        _money = new Money(nameof(Money));
        _money.Attach(_enemy);

        _health = new Health(nameof(Health));
        _health.Attach(_enemy);

        _power = new Power(nameof(Power));
        _power.Attach(_enemy);

        _crime = new Crime(nameof(Crime));
        _crime.Attach(_enemy);

        _addMoneyButton.onClick.AddListener(() => ChangeMoney(true));
        _minusMoneyButton.onClick.AddListener(() => ChangeMoney(false));

        _addHealthButton.onClick.AddListener(() => ChangeHealth(true));
        _minusHealthButton.onClick.AddListener(() => ChangeHealth(false));

        _addPowerButton.onClick.AddListener(() => ChangePower(true));
        _minusPowerButton.onClick.AddListener(() => ChangePower(false));

        _addCrimeButton.onClick.AddListener(() => ChangeCrime(true));
        _minusCrimeButton.onClick.AddListener(() => ChangeCrime(false));


        _knifeFightButton.onClick.AddListener(KnifeFight);
        _freeWayButton.onClick.AddListener(FreeWay);



        _fightButton.onClick.AddListener(Fight);
    }

    private void KnifeFight()
    {
        Debug.Log(_allCountPowerPlayer >= _enemy.KnifePower ? "Win KnifeWar" : "Lose KnifeWar");
    }

    private void FreeWay()
    {
       if(_allCountCrimePlayer <=2)
       {
            _freeWayButton.GetComponent<Image>().color = Color.green;
            Debug.Log("FreeWay");
       }
       else
       {
            _freeWayButton.GetComponent<Image>().color = Color.black;
            Debug.Log("Can't FreeWay");
       }
    }

    private void OnDestroy()
    {
        _addMoneyButton.onClick.RemoveAllListeners();
        _minusMoneyButton.onClick.RemoveAllListeners();

        _addHealthButton.onClick.RemoveAllListeners();
        _minusHealthButton.onClick.RemoveAllListeners();

        _addPowerButton.onClick.RemoveAllListeners();
        _minusPowerButton.onClick.RemoveAllListeners();

        _addCrimeButton.onClick.RemoveAllListeners(); 
        _minusCrimeButton.onClick.RemoveAllListeners();

        _fightButton.onClick.RemoveAllListeners();
        _knifeFightButton.onClick.RemoveAllListeners();

        _money.Detach(_enemy);
        _health.Detach(_enemy);
        _power.Detach(_enemy);
        _crime.Detach(_enemy);
    }

    private void ChangeCrime(bool isAddCount)
    {
        if (isAddCount)
            _allCountCrimePlayer++;
        else
            _allCountCrimePlayer--;

        ChangeDataWindow(_allCountCrimePlayer, DataType.Crime);
    }
    private void Fight()
    {
        Debug.Log(_allCountPowerPlayer >= _enemy.Power ? "<color=#07FFOO>Win</color>" : "<color=#FFOOOO>Lose</color>");
        Debug.Log(_allCountPowerPlayer >= _enemy.KnifePower? "<color=#07FFOO>Win</color>" : "<color=#FFOOOO>Lose</color>");
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

    private void ChangeDataWindow(int countChangeData, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Money:
                _countMoneyText.text = $"Player money: {countChangeData}";
                _money.CountMoney = countChangeData;
                break;

            case DataType.Health:
                _countHealthText.text = $"Player health: {countChangeData}";
                _health.CountHealth = countChangeData;
                break;

            case DataType.Power:
                _countPowerText.text = $"Player power: {countChangeData}";
                _power.CountPower = countChangeData;
                break;

            case DataType.Crime:
                _crimeStatusPlayerText.text = $"Player crime: {countChangeData}";
                _crime.CountCrime = countChangeData;
                break;
        }

        _countPowerEnemyText.text = $"Enemy power: {_enemy.Power}";
        _countKnifePowerEnemyText.text = $"Enemy Knife Power: {_enemy.KnifePower}";
    }
}
