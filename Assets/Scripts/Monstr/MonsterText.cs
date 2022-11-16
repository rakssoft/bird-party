
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MonsterText : MonoBehaviour
{
    [SerializeField] private Text _coinsText;
    public int _coins;
    void Start()
    {
        _coinsText.text = _coins.ToString();
        transform.DOMove (transform.position + transform.up, 1f);
        Destroy(gameObject, 0.5f);
    }

}
