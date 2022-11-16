
using UnityEngine;

public class DataSave : MonoBehaviour
{
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("coins"))
        {
            PlayerPrefs.SetInt("coins", 0);
        }
    }


    public void Save(int coins)
    {
        PlayerPrefs.SetInt("coins", coins);
    }
}
