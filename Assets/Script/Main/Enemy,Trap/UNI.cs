using UnityEngine;

public class UNI : MonoBehaviour {

    [SerializeField]
    private float Rot_Speed = 1;
    [SerializeField]
    private float Gravity_scale = 0.1f;
    Rigidbody2D rb2d;
    //プレイヤーのダメージ数
    int damage = 1;
    //エフェクト
    public GameObject effect;
    AudioSource UNIaudio;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = Gravity_scale;
        UNIaudio = GetComponent<AudioSource>();
    }

    void Update () {
        
        rb2d.AddTorque(Rot_Speed * 10 * Time.deltaTime);
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(effect,
                new Vector3(col.transform.position.x, col.transform.position.y,effect.transform.position.z),
                effect.transform.rotation);
            Player.P_Hp -= damage;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Background")
        {
            //Debug.Log(other.gameObject);
            Destroy(gameObject);
        }
    }
}
