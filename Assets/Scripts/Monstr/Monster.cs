
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster", menuName = "Monster")]
public class Monster : ScriptableObject
{
  [SerializeField]  private int _idMonster;
  [SerializeField]  private string Description;
  [SerializeField] private int _outCoins;
  [SerializeField] public float _timerOutCoins;


    public int IDMonster  { get { return _idMonster; } private set { _idMonster = value; } }
    public int OutCoinsMonster { get { return _outCoins; } private set { _outCoins = value; } }
    public float TimerOutCoins { get { return _timerOutCoins; } private set { _timerOutCoins = value; } }




}
