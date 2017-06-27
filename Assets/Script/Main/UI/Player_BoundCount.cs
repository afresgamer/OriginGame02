using UnityEngine;
using UnityEngine.UI;

public class Player_BoundCount : MonoBehaviour {

    Text text;

	void Start () {
        text = GetComponent<Text>(); 
	}
	
	void Update () {
        //text.text = Player.bound_count.ToString();
	}

    void FixedUpdate()
    {
        text.text = Player.bound_count.ToString();
    }
}
