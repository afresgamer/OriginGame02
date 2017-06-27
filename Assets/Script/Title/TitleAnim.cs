using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleAnim : MonoBehaviour {

    //シーン移動用
    private int SceneNum = 1;
    [SerializeField]
    private Button Start_B;
    [SerializeField]
    private Button Easy;
    [SerializeField]
    private Button Normal;
    [SerializeField]
    private Button Hard;
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

    public void Title_Anim_B()
    {
        Start_B.gameObject.SetActive(false);
        Easy.gameObject.SetActive(true);
        Normal.gameObject.SetActive(true);
        Hard.gameObject.SetActive(true);
    }

    public void ChangeGameMode(Button b)
    {
        if(b == Easy) { GameManager.gamemode = GameManager.GameMode.EASY; }
        else if(b == Normal) { GameManager.gamemode = GameManager.GameMode.NORMAL; }
        else if(b == Hard) { GameManager.gamemode = GameManager.GameMode.HARD; }
        else { GameManager.gamemode = GameManager.GameMode.NONE; }
        Debug.Log(GameManager.gamemode);
    }

    public void Scene_Change()
    {
        SceneManager.LoadScene(SceneNum);
    }
	
}
