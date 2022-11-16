
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    private ManagerSpawnBonus managerSpawnBonus;
    private ManagerSpawnMonster managerSpawn;
    private ManagerEffects managerEffects;
    private int _countFeatherEffects = 0;

    private void Awake()
    {
        managerSpawnBonus = GetComponent<ManagerSpawnBonus>();
        managerSpawn = GetComponent<ManagerSpawnMonster>();
        managerEffects = GetComponent<ManagerEffects>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.TryGetComponent(out MonsterOutCoins GO))
                {
                    _countFeatherEffects++;
                    if (_countFeatherEffects >= 5)
                    {
                        _countFeatherEffects = 0;
                        managerEffects.VFXFeather(hit.collider.transform.position);
                    }
                    GO.OutCoins();
                }
                if (hit.collider.gameObject.CompareTag("Egg"))
                {
                    managerEffects.VFXEscapeEgg(hit.collider.gameObject.transform.position);
                    Destroy(hit.collider.gameObject);
                    managerSpawn.RecalListMonstr(-1);
                    managerSpawn.SpawnMonster(1, hit.collider.gameObject.transform.position);

                }  
                if (hit.collider.gameObject.CompareTag("Bonus"))
                {
                    managerEffects.VFXEscapeEgg(hit.collider.gameObject.transform.position);
                    Destroy(hit.collider.gameObject);
                    managerSpawnBonus.OnBonus();

                }
            }
        }

    }
}
