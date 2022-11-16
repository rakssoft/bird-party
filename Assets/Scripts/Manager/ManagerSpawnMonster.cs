using TMPro;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;


public class ManagerSpawnMonster : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerSpawnMonsterText; 
    [SerializeField] private GameObject[] _monsters;
    [SerializeField] private Transform _spawnMonsterParent;
    [SerializeField] private float _timerSpawnMonster;
    [SerializeField] private List<MonsterOutCoins> _listMonstrSpawn;
    private GameObject[] _spawnPositions;
    private int bufferMonsterInt = 0;
    private bool _listFull = true;
    private int limitMonstr = 10;                        // лимит монстров на уровне  
    private float timer;

    public UnityAction<float> TotalCoinMonster;  //эфент дл€ отправки количества денег в секунду
   
    private void OnEnable()  
    {
        MonsterDragMerge.MonsterID += RemoveMonster;
        MonsterDragMerge.MonsterRecal += RecalListMonstr;
    }
    private void OnDisable()
    {
        MonsterDragMerge.MonsterID -= RemoveMonster;
    }
    private void Awake()
    {
        _spawnPositions = GameObject.FindGameObjectsWithTag("Spawn");
        timer = _timerSpawnMonster;
    }
    public void Start()
    {
        if (limitMonstr > CheckListmonstr())   // проверка на колличество монстров на уровне ≈сли много то спавн не идет. 
        {
            _listFull = false;
            GameObject spawnPos = SpawnPositions();
            SpawnMonster(0, spawnPos.transform.position);        
        }
         
    }
    private void Update()
    {
        _timerSpawnMonster -= Time.deltaTime;
        _timerSpawnMonsterText.text = _timerSpawnMonster.ToString("F0");
        if(_timerSpawnMonster <= 0 && _listFull == false)
        {
            _timerSpawnMonster = timer;
            GameObject spawnPos = SpawnPositions();
            SpawnMonster(0, spawnPos.transform.position);
            CheckListmonstr();
        }
        else if(_timerSpawnMonster <= 0 && _listFull == true)
        {
            _timerSpawnMonster = 0;
            _timerSpawnMonsterText.text = "FULL";
        }
    }
    /// <summary>
    /// –адномный выбор позиции дл€ спавна монстра из списка _spawnPositions
    /// </summary>
    /// <returns></returns>
    public GameObject SpawnPositions()
    {
        return _spawnPositions[Random.Range(0, _spawnPositions.Length)];
    }

    /// <summary>
    /// ‘ункци€ спавна монстров  передаетс€ IDмонстра и его позици€
    /// </summary>
    public void SpawnMonster(int monster, Vector2 spawnPositions)
    {   
        if (_listFull == false)
        {
            if (monster < _monsters.Length)
            {
                GameObject monstrGO = Instantiate(_monsters[monster], spawnPositions, Quaternion.identity, _spawnMonsterParent);                            
            }
            // придумать как сделать когда ID монстра станет больше чем общее их количество.  ѕока они просто исчезнут.            
        }
    } 

    /// <summary>
    /// ѕроверка узнает колличество монстров на уровне
    /// отправл€ет эвент сколько коинов в секунду
    /// </summary>
    /// <returns></returns>
    private int CheckListmonstr()
    {
        float totalCoinMonstr = 0;
        _listMonstrSpawn.Clear();
       MonsterOutCoins[] monstr = FindObjectsOfType<MonsterOutCoins>();
        for (int i = 0; i < monstr.Length; i++)
        {
            _listMonstrSpawn.Add(monstr[i]);
            totalCoinMonstr += monstr[i].CoinMonster / monstr[i].TimerCoinMonster;
        }
        TotalCoinMonster?.Invoke(totalCoinMonstr);
        int countList = _listMonstrSpawn.Count;
        if(countList >= limitMonstr)
        {
            _listFull = true;
        }
        else
        {
            _listFull = false;
        }
        bufferMonsterInt = countList;
        return countList;
    }
    /// <summary>
    /// через событие удал€ет двух монстров из списка на сцене
    /// </summary>
    private void RemoveMonster(int IDMonster, Vector2 PositionMonstr)
    {
        RecalListMonstr(-2);
        SpawnMonster(IDMonster++, PositionMonstr);
       
    }

    /// <summary>
    /// ѕересчитывает количества монстров на уровне, если больше то запрет на добавление.
    /// </summary>
    /// <param name="monstrCount"></param>
    public void RecalListMonstr(int monstrCount) /// ѕротестировать колличество чтобы было впор€дке и не забивалось больше
    {     
        bufferMonsterInt += monstrCount;
        if(bufferMonsterInt >= limitMonstr)
        {
            _listFull = true;
            bufferMonsterInt = limitMonstr;
        }
        else
        {
            _listFull = false;
        }
    }


}
