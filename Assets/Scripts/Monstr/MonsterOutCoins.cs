
using UnityEngine;
using UnityEngine.Events;

public class MonsterOutCoins : MonoBehaviour
{     
    [SerializeField] Monster _monster;
    private ManagerCoins managerCoins;
    private AudioSource audioClip;
    private float _timerOutCoins;
    private int _coinsOut;
    private float timer;

    public int CoinMonster { get; private set; }
    public float TimerCoinMonster { get; private set; }
    public static UnityAction<Vector2> inPositionsCoinsOut;

    private void Awake()
    {
        audioClip = GetComponent<AudioSource>();
        managerCoins = FindObjectOfType<ManagerCoins>().GetComponent<ManagerCoins>();
        _coinsOut = _monster.OutCoinsMonster;
        CoinMonster = _coinsOut;
        TimerCoinMonster = _monster.TimerOutCoins;
        _timerOutCoins = _monster.TimerOutCoins;
        timer = _timerOutCoins;
    }

    private void Update()
    {
        _timerOutCoins -= Time.deltaTime;
        if(_timerOutCoins <= 0)
        {
            _timerOutCoins = timer;
            managerCoins.RecalTotalCoins(_coinsOut);
        }
    }

    public void OutCoins()
    {
        audioClip.Play();
        managerCoins.RecalTotalCoins(_coinsOut);
        inPositionsCoinsOut?.Invoke(gameObject.transform.position);


    }


}
