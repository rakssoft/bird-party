using UnityEngine;
using System.Collections;

public class ManagerSpawnBonus : MonoBehaviour
{
    [SerializeField] private Transform _spawnparent;
    [SerializeField] private Vector3[] _waypoints;
    [SerializeField] private GameObject _spawnpositions;
    [SerializeField] private BonusX2 _prefabbonusx2;
    [SerializeField] private float _bonusTimer;
    private ManagerCoins managerCoins;
    private float bufferTimer;

    private void Awake()
    {
        managerCoins = GetComponent<ManagerCoins>();
    }

    private void Start()
    {
        bufferTimer = _bonusTimer;
    }
    private void Update()
    {
        _bonusTimer -= Time.deltaTime;

         if(_bonusTimer <= 0)
        {
            _bonusTimer = bufferTimer;
            BonusX2 bonus = Instantiate(_prefabbonusx2, _spawnpositions.transform.position, Quaternion.identity, _spawnparent);
            bonus.MoveWaypoints(_waypoints);
        }
    }

    /// <summary>
    /// При нажимание на бонус в инпут включается умножение на 2
    /// </summary>
    public void OnBonus()
    {
        managerCoins.MultiplyBonus(2);
        StartCoroutine(TimerBonus());
    }

    IEnumerator TimerBonus()
    {
        yield return new WaitForSeconds(30);
        managerCoins.MultiplyBonus(1);
    }

   


}
