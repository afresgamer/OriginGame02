using UnityEngine;
public class FishS : MonoBehaviour {
    //魚種
    public enum Fish_Type { None , Whale, Shake , ChoShake }
    public Fish_Type fish_Type;
    [SerializeField] private Enemy enemy;
    Rigidbody2D rb2D;
    [SerializeField] private Player player;
    //playerの発見フラグ
    bool target_Move;

    void Awake()
    {
        //Enemy初期化
        if (enemy == null) Debug.LogError("Enemy情報がありません。アタッチしてください。");
		if (player == null) Debug.LogError ("player情報ありません。アタッチしてください。");
    }

    void Start () {
        target_Move = false;
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        int ran_index = Random.Range(-45, 45);
        float myRot = transform.rotation.z;
        //移動
        Enemy.Move(rb2D, -transform.right * 10 / enemy.Speed);
        if (target_Move)
        {
            rb2D.MovePosition(
                Vector2.Lerp(transform.position, player.transform.position, enemy.smoothing * Time.deltaTime));
        }

        switch (fish_Type)
        {
            case Fish_Type.Shake:
                break;
            case Fish_Type.ChoShake:             
                break;
            case Fish_Type.Whale:
                break;
            default:
                break;
        }
    }

    //衝突判定
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Player.P_Hp -= enemy.damage;
        }
    }
    //視界や敵のplayerが近くにいるかどうか判定
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player is enter");
            target_Move = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player is exit");
            target_Move = false;
        }
    }
}
