using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {
    
    private GameManager gameManager;
    [SerializeField]
    private Text ScorePointText;
    [SerializeField]
    private Text distanceText;
    [SerializeField]
    private Text scoreRank;

    void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        ScorePointText.text = gameManager.Count().ToString();
        if(gameManager.Distance() > 0)
        {
            distanceText.text = gameManager.Distance().ToString();
        }
        else { distanceText.text = "0"; }
        scoreRank.text = gameManager.Set_ScoreRank();
        //Debug.Log(scoreRank.text);
	}
	
    public void SceneChange()
    {
        SceneManager.LoadScene(0);
    }


}
