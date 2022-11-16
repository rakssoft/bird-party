using UnityEngine;

public class MonsterDisplay : MonoBehaviour
{

    [SerializeField] private Monster _monster;   
    public int MonsterID {  get;  private set; }


    private void Start()
    {
        MonsterID = _monster.IDMonster;
    }
}
