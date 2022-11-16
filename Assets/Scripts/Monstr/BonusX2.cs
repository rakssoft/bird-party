
using UnityEngine;
using DG.Tweening;

public class BonusX2 : MonoBehaviour
{

    private void Start()
    {
        Destroy(gameObject, 15f);
    }

    public void MoveWaypoints(Vector3[] waypoints)
    {
        transform.DOPath(waypoints, 12, PathType.CatmullRom);
    }
}
