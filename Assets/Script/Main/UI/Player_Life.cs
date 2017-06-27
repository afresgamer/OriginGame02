using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Life : MonoBehaviour {

    public Image[] image;
    private string result = "Result";
    //プレイヤーHP
    public static int P_Hp = 3;

    private void Update()
    {
        Tick_Life(Player.P_Hp);
        if(Player.P_Hp == 0) { SceneManager.LoadScene(result); }
    }

    public void Tick_Life(int life)
    {
        for (int i = 0; i < image.Length; i++)
        {
            if (i < life) { image[i].enabled = true; }
            else { image[i].enabled = false; }
        }
    }
}
