using UnityEngine;

public class Foam : MonoBehaviour {

    [SerializeField]
    private float Timer = 1;
    private float Speed = 1;

    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = -1;
    }

    void Update () {
        Timer -= Speed * Time.deltaTime;
        if(Timer < 0) { Destroy(gameObject); Timer = 1; }
	}
}
