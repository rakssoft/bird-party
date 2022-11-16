using UnityEngine;
using UnityEngine.UI;

public class ManagerCoins : MonoBehaviour
{
    [SerializeField] private Transform _parentCoinsText;
    [SerializeField] private MonsterText _textPrefab;
    [SerializeField] private Text _totalCoinsText;
    [SerializeField] private Text _perSecondCoinsText;
    private DataSave dataSave;
    private ManagerSpawnMonster managerSpawn;
    private int _totalCoins;
    private int _coinsOut;
    private float _perSecondCoins;
    private int multiply = 1;

    private void Awake()
    {
        dataSave = GetComponent<DataSave>();
        managerSpawn = GetComponent<ManagerSpawnMonster>();
        _totalCoins = PlayerPrefs.GetInt("coins");
    }

    private void OnEnable()
    {
        managerSpawn.TotalCoinMonster += RecalPerSecondCoins;
        MonsterOutCoins.inPositionsCoinsOut += SpawnCoinsText;
    }

    private void OnDisable()
    {
        managerSpawn.TotalCoinMonster -= RecalPerSecondCoins;
        MonsterOutCoins.inPositionsCoinsOut -= SpawnCoinsText;
    }

    private void Update()
    {
  
        _totalCoinsText.text = _totalCoins.ToString();
        _perSecondCoinsText.text = _perSecondCoins.ToString("F2");
    }

    /// <summary>
    /// Пересчет коинов 
    /// </summary>
    /// <param name="coins"></param>
    public void RecalTotalCoins(int coins)
    {
        if (coins < 0)
        {
            _totalCoins += coins;
        }
        else
        {
            _coinsOut = coins * multiply;
            _totalCoins += (coins * multiply);
        }
 
        dataSave.Save(_totalCoins);
    } 

    /// <summary>
    /// пересчет дохода коинов в секунду
    /// </summary>
    /// <param name="coins"></param>    
    public void RecalPerSecondCoins(float coins)
    {
        _perSecondCoins = coins;
    }


    /// <summary>
    /// Создается текст какое коллисество коинов добывается и анимируется 
    /// </summary>
    /// <param name="pos"></param>
    private void SpawnCoinsText(Vector2 pos)
    {
        if (_textPrefab && _coinsOut > 0)
        {
            MonsterText monsterText = Instantiate(_textPrefab, pos, Quaternion.identity, _parentCoinsText);
            monsterText._coins = _coinsOut;
        }
    }


    /// <summary>
    /// Функция множителя бонуса
    /// </summary>
    /// <param name="multiplys"></param>
    public void MultiplyBonus(int multiplybonus)
    {
        multiply = multiplybonus;
    }

}
