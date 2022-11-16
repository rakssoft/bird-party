
using UnityEngine;
using UnityEngine.Events;


public class MonsterDragMerge : MonoBehaviour
{
    [SerializeField] private Monster _monster;
    private Vector2 _monsterPosition;
    private Vector2 mousePositions;
    private float offsetX, offsetY;
    private bool mouseButtonReleased;
    private float timerMergeOff = 0.3f;

    public static UnityAction<int, Vector2> MonsterID;
    public static UnityAction<int> MonsterRecal;

    private void Update()
    {
        if (mouseButtonReleased == true)
        {
            timerMergeOff -= Time.deltaTime;
            if (timerMergeOff <= 0)
            {
                mouseButtonReleased = false;
                timerMergeOff = 0.3f;
            }
        }
    }

    private void OnMouseDown()
    {
        mouseButtonReleased = false;
        offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        _monsterPosition = gameObject.transform.position;
    }

    private void OnMouseDrag()
    {
        mousePositions = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePositions.x - offsetX, mousePositions.y - offsetY);
    }

    private void OnMouseUp()
    {
        mouseButtonReleased = true;    
    }

    /// <summary>
    /// При соприкосновение  коллайдера с нужным айди передается эвент айди монстра
    /// и его позицию чтобы создать улучшеного монстра на тойже позиции а два коснувшихся удаляются
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (mouseButtonReleased && collision.TryGetComponent(out MonsterDisplay monsterGODisplay))
        {
            if (_monster.IDMonster == monsterGODisplay.MonsterID)
            {
                int bufferId = _monster.IDMonster;
                mouseButtonReleased = false;
                MonsterID?.Invoke(bufferId +=1 , gameObject.transform.position);
                MonsterRecal?.Invoke(1);
                Destroy(monsterGODisplay.gameObject);
                Destroy(gameObject);
            }
            else
            {
                gameObject.transform.position = _monsterPosition;
            }
        }
    }
}









