using UnityEngine;

public class MonstrMove : MonoBehaviour
{
    [SerializeField] private float _speed;    //скорость монтстра 
    [SerializeField] private float _timeOutMove;   // с какой частотой он дигается 
    private float timer;
    private bool isMove;
    private Vector3 posTarget;

    private void Start()
    {
        timer = _timeOutMove;
        isMove = false;
    }

    [System.Obsolete]
    private void Update()
    {
        _timeOutMove -= Time.deltaTime;
        if (_timeOutMove <= 0 && isMove == false)
        {
            isMove = true;
            posTarget = TargetPositions();
        }
        if (isMove == true)
        {
            Move();
        }

    }
    /// <summary>
    /// Рандомное движение монстра  типа живой 
    /// </summary>
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, posTarget, _speed * Time.deltaTime);
        if (transform.position == posTarget)
        {
            isMove = false;
            _timeOutMove = timer;
        }
    }

    [System.Obsolete]
    private Vector3 TargetPositions()
    {
        Vector3 pos = new(Random.RandomRange(-2, 2), Random.RandomRange(-2, 2), 0);
        return pos;
    }
}
