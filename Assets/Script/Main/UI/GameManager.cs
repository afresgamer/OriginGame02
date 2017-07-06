using UnityEngine;
public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    //ゲーム難易度
    public enum GameMode
    {
        NONE = 0, EASY = 16, NORMAL = 32, HARD = 64
    }

    public static GameMode gamemode;

    //GameManagerの生成を管理
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        gamemode = GameMode.NONE;
        Debug.Log(gamemode);
    }

    void Update()
    {
        //Debug.Log(gamemode);
    }

    //距離
    public int Distance()
    {
        int distance = Player_Score.scoreDistance;
        return distance;
    }

    //避けた敵の数
    public int Count()
    {
        int count = EnemyCounter.count;
        return count;
    }

    //ゲームモードによってランク加算のコントロール
    public int Score_Rank(GameMode gm)
    {
        int point = (int)GameMode.NONE;
        if(gm == GameMode.EASY){ point = (int)GameMode.EASY; }
        else if(gm == GameMode.NORMAL){ point = (int)GameMode.NORMAL;  }
        else if(gm == GameMode.HARD) { point = (int)GameMode.HARD;  }

        return point;
    }

    //ランク決定
    public string Set_ScoreRank()
    {
        int _rank = Distance() + Count();
        int Score_Point = Score_Rank(gamemode);
        //Debug.Log(_rank);
        
        string[] rank = { "D", "C", "B", "A" ,"S", "SSS"};

        if(0 <= _rank && _rank <= Score_Point) { return rank[0]; }
        else if(Score_Point < _rank && _rank <= Score_Point * 2 ) { return rank[1]; }
        else if(Score_Point * 2 < _rank && _rank <= Score_Point * 3) { return rank[2]; }
        else if(Score_Point * 3 < _rank && _rank <= Score_Point * 4) { return rank[3]; }
        else if(Score_Point * 4 < _rank && _rank <= Score_Point * 5) { return rank[4]; }
        else if(_rank > Score_Point * 5) { return rank[5]; }

        return rank[2];
    }
}
