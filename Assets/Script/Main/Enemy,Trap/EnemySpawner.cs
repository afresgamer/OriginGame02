using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] FishS;
    [SerializeField]
    private Transform attachPoint;
    public static bool spawn;
    int Fish_num;
    int posNum;

    void Awake()
    {
        spawn = false;
    }

    private void Start()
    {
        if (GameManager.gamemode == GameManager.GameMode.NORMAL || GameManager.gamemode == GameManager.GameMode.HARD)
        { Instantiate(FishS[Ran_FNum()], attachPoint.position, Quaternion.identity); }
    }

    void Update () {
        if (GameManager.gamemode == GameManager.GameMode.HARD && spawn)
        {
            Instantiate(FishS[Ran_FNum()], attachPoint.position, Quaternion.identity);
            spawn = false;
        }
	}

    int Ran_FNum()
    {
        int ranum = Random.Range(0, FishS.Length);
        Fish_num = ranum;
        return Fish_num; 
    }
}
