using UnityEngine;

public class ManagerEffects : MonoBehaviour
{
    [SerializeField] private GameObject _vfxMergeMonster, _vfxExplosionEgg, _vfxFeather;
    [SerializeField] private Transform _parentEffects;


    private void OnEnable()
    {
        MonsterDragMerge.MonsterID += VFXMerge;
    }
    private void OnDisable()
    {
        MonsterDragMerge.MonsterID -= VFXMerge;
    }

    private void VFXMerge(int ID, Vector2 pos)
    {
        GameObject vfx = Instantiate(_vfxMergeMonster, pos, Quaternion.identity, _parentEffects);
        Destroy(vfx, 1.5f);
    }

    public void VFXEscapeEgg(Vector2 pos)
    {
        GameObject vfx = Instantiate(_vfxExplosionEgg, pos, Quaternion.identity, _parentEffects);
        Destroy(vfx, 1.5f);
    } 
    public void VFXFeather(Vector2 pos)
    {
        GameObject vfx = Instantiate(_vfxFeather, pos, Quaternion.identity, _parentEffects);
        Destroy(vfx, 1f);
    }
}
