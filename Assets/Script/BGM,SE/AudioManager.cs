using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

    public static AudioManager instanace = null;

    public enum GameState { Title,Main,Result }
    public GameState gameState;
    public static int SceneNum;

    [SerializeField]
    private AudioClip[] bgm;

    void Awake()
    {
        if(instanace == null)
        {
            instanace = this;
        }
        else if(instanace != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start () {
        
	}
	
	void Update () {
        SceneNum = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(SceneNum);
    }

    public void SetVolume()
    {

    }

    void Music_Select(int S_num)
    {
        switch (S_num)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            default:
                break;
        }
    }
}
