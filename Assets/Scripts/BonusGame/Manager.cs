using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Manager : MonoBehaviour
{
    [SerializeField] private Text _constText;
    [SerializeField] private GameObject _prefabBird;
    [SerializeField] private GameObject _spawnBirds;
    [SerializeField] private GameObject[] _spawnBlocks;
    [SerializeField] private GameObject _prefabBlock;
    public GameObject player;
    private bool gameover;
    private float _coins;
    private float _timerSpawnBlocks = 3;


    private void Start()
    {
      
        gameover = false;        
        _coins = 0;
        Instantiate(_prefabBird, _spawnBirds.transform.position, Quaternion.identity);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        
        if (player)
        {
            _coins += 0.2f;
            _constText.text = _coins.ToString("F0");
            _timerSpawnBlocks -= Time.deltaTime;
            if (_timerSpawnBlocks <= 0)
            {
                _timerSpawnBlocks = 3;
                Instantiate(_prefabBlock, _spawnBlocks[Random.Range(0, 2)].transform.position, Quaternion.identity);
            }
        }
        else if (!player && gameover == false)
        {
            gameover = true;
            GameOver();
        }
    }

    public void GameOver()
    {
       
        StartCoroutine(ExitBonusGame());

    }

    IEnumerator ExitBonusGame()
    {
        yield return new WaitForSeconds(3f);
        int buferCoins = (int)(_coins / 1);
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + buferCoins);
        SceneManager.LoadScene(1);
    }


}
