using UnityEngine;
using UnityEngine.UI;

public class Player_Score : MonoBehaviour {

    private Text Scoretext;
    GameObject p;
    public static int scoreDistance;

    void Awake()
    {
        scoreDistance = 0;
    }

    void Start () {
        scoreDistance = 0;
        p = GameObject.FindGameObjectWithTag("Player");
        Scoretext = GetComponent<Text>();
	}
	
	void Update () {
        scoreDistance = (int)p.transform.position.x;
        if(p.transform.position.x > 0)
        {
            Scoretext.text = scoreDistance.ToString();
        }
        else { Scoretext.text = "0"; }
	}
}
