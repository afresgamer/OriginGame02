using UnityEngine;
public class FishS : MonoBehaviour {
    //魚種
    public enum Fish_Type { None , Whale, Shake , ChoShake }
    public Fish_Type fish_Type;
    [SerializeField] private Enemy enemy;
    Rigidbody2D rb2D;
    private Player player;
    //playerの発見フラグ
    bool target_Move;

    void Awake()
    {
        //Enemy初期化
        if (enemy == null) Debug.LogError("Enemy情報がありません。アタッチしてください。");
    }

    void Start () {
        player = FindObjectOfType<Player>();
        target_Move = false;
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        switch (fish_Type)
        {
            case Fish_Type.Shake:
                Enemy.Move(transform, enemy.Speed,target_Move);
                break;
            case Fish_Type.ChoShake:
                Enemy.Move(rb2D, -transform.right / 10 * enemy.Speed);
                break;
            case Fish_Type.Whale:
                Enemy.Move(rb2D, -transform.right / 10 * enemy.Speed);
                break;
            default:
                break;
        }
        if (target_Move) {
            rb2D.MovePosition(Vector2.MoveTowards
                (transform.position, player.transform.position, enemy.Speed * Time.deltaTime));
        }
    }

    //衝突判定
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Player.P_Hp -= enemy.damage;
            EnemySpawner.spawn = true;
        }
    }
    //視界や敵のplayerが近くにいるかどうか判定
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("Player is enter");
            target_Move = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("Player is exit");
            target_Move = false;
        }
    }
}
