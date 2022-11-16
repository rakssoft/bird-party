
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private Vector2 _speed;


    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            print("GameOwer");
        }
        else if (collision.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }
}
