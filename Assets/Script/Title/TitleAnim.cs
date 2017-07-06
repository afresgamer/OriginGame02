using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleAnim : MonoBehaviour {

    [SerializeField]
    private Button Start_B;
    [SerializeField]
    private Button Option_B;
    [SerializeField]
    private Button Easy;
    [SerializeField]
    private Button Normal;
    [SerializeField]
    private Button Hard;
    [SerializeField]
    private Image option;
    //GameManager確認用
    [SerializeField]
    private GameManager gameManager;

    //GameManagerなかったら生成
    void Awake()
    {
        if(GameManager.instance == null)
        {
            Instantiate(gameManager);
        }
    }

    void Start()
    {
        //Start_B.gameObject.SetActive(true);
        //Option_B.gameObject.SetActive(true);
        //Easy.gameObject.SetActive(false);
        //Normal.gameObject.SetActive(false);
        //Hard.gameObject.SetActive(false);
        //option.gameObject.SetActive(false);
    }

    public void Title_Anim_B()
    {
        Start_B.gameObject.SetActive(false);
        Option_B.gameObject.SetActive(false);
        Easy.gameObject.SetActive(true);
        Normal.gameObject.SetActive(true);
        Hard.gameObject.SetActive(true);
    }

    public void Titie_Anim_B2()
    {
        Start_B.gameObject.SetActive(false);
        Option_B.gameObject.SetActive(false);
        Easy.gameObject.SetActive(false);
        Normal.gameObject.SetActive(false);
        Hard.gameObject.SetActive(false);
        option.gameObject.SetActive(true);
    }

    public void ChangeGameMode(Button b)
    {
        if(b == Easy) { GameManager.gamemode = GameManager.GameMode.EASY; }
        else if(b == Normal) { GameManager.gamemode = GameManager.GameMode.NORMAL; }
        else if(b == Hard) { GameManager.gamemode = GameManager.GameMode.HARD; }
        else { GameManager.gamemode = GameManager.GameMode.NONE; }
        Debug.Log(GameManager.gamemode);
    }

    public void Scene_Change(int Scene)
    {
        SceneManager.LoadScene(Scene);
    }
	
}
