using UnityEngine.UI;
using UnityEngine;

public class ManagerShop : MonoBehaviour
{
    [SerializeField] Button _buttonBuyEgg;
    [SerializeField] Text _priceEggText;
    [SerializeField] Slider _crystalSlider;
    [SerializeField] GameObject _imageFillSlider, _SliderBonusGame;
    [SerializeField] GameObject _buttonBonusGame;
    [SerializeField] GameObject _vfxbonusGame;

    private ManagerSpawnMonster spawnMonster;
    private ManagerCoins managerCoins;
    private int _priceEgg = 1;
    private int _countCrystal = 0;

    private void Awake()
    {
        managerCoins = GetComponent<ManagerCoins>();
        spawnMonster = GetComponent<ManagerSpawnMonster>();
    }

    private void Start()
    {
        RecalCrystal(_countCrystal);
    }

    private void OnEnable()
    {
        MonsterDragMerge.MonsterRecal += RecalCrystal;
    }
    private void OnDisable()
    {
        MonsterDragMerge.MonsterRecal -= RecalCrystal;
    }

    private void Update()
    {
        _priceEggText.text = _priceEgg.ToString();
        if(PlayerPrefs.GetInt("coins") >= _priceEgg)
        {
            _buttonBuyEgg.interactable = true;
        }
        else if (PlayerPrefs.GetInt("coins") < _priceEgg)
        {
            _buttonBuyEgg.interactable = false;
        }
    }
    public void BuyEgg()
    {       
        if(PlayerPrefs.GetInt("coins") >= _priceEgg)
        {
            managerCoins.RecalTotalCoins(_priceEgg * -1);
            _priceEgg *= 2;
            spawnMonster.Start();
           
        }
    }

    /// <summary>
    /// ѕри мерге монстров отправл€етс€ событие дл€ увелечени€ колличества кристалов.
    /// </summary>
    /// <param name="count"></param>
    private void RecalCrystal(int count)
    {
        _countCrystal += count;
        _crystalSlider.value = _countCrystal;
        if (_countCrystal > 0 && _countCrystal < 5)
        {
            _imageFillSlider.SetActive(true);           
        }
        else if (_countCrystal >= 5)
        {
            _countCrystal = 5;
            _crystalSlider.value = 5;
            _SliderBonusGame.SetActive(false);
            _buttonBonusGame.SetActive(true);
        }
        else if(_countCrystal <= 0)
        {
            _countCrystal = 0;
            _SliderBonusGame.SetActive(true);
            _buttonBonusGame.SetActive(false);
            _imageFillSlider.SetActive(false);
        }
    }
}
