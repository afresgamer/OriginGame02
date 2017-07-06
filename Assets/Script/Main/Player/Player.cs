using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {

    public float FollowSpeed = 1;
    Rigidbody2D rb2d;
    //SpriteRenderer sr;
    Transform AttachPoint;
    [SerializeField] private GameObject foam;
    [SerializeField] private float Timer = 1;
    float Speed = 2;
    //Hp
    public static int P_Hp = 3;
    //Androidの入力変数
    float Move_Input_z;
    [SerializeField] private int Input_Move_interval = 3;

    //バウンドする回数
    public static int bound_count = 3;
    const int Max_Bound = 3;
    const int Min_Bound = 0;
    private float Now_timer;//現在の時間フレーム

    void Awake()
    {
        P_Hp = 3;
        Now_timer = 0;
        Move_Input_z = 0;
    }

    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        //sr = GetComponent<SpriteRenderer>();
        AttachPoint = transform.GetChild(0);
	}
	
	void FixedUpdate () {
        Now_timer += Time.time;
        if(Now_timer >= 2000) { Now_timer = 0; }
        //Debug.Log(Now_timer);
        Player_Move();

        //泡発生スピード
        Timer -= Speed * Time.deltaTime;
        if(Timer < 0) { StartCoroutine(CreateFoam(AttachPoint,foam)); Timer = 1; }
	}

    void Player_Move()
    {
        float x = Input.GetAxis("Horizontal");
        Input.gyro.enabled = true;//ジャイロオン
        float And_z = -Input.gyro.rotationRate.z / Input_Move_interval;//Android用の出力
        Move_Input_z += And_z;

        //方向転換
        if (x < 0 || And_z <= -0.1f)
        {
            //sr.flipX = false;
            Quaternion q = new Quaternion(0, 180, 0, 1);
            transform.rotation = q;
        }
        else if (x > 0 || And_z >= 0.1f || And_z == 0)
        {
            //sr.flipX = true;
            Quaternion q = new Quaternion(0, 0, 0, 1);
            transform.rotation = q;
        }

        TouchInfo info = AppUtil.GetTouch();
        if (Input.GetMouseButtonDown(0) || info == TouchInfo.Began)
        {
            if (bound_count > Min_Bound)
            {
                rb2d.AddForce(new Vector2(0, 1000));
                bound_count--;
            }
        }
        //バウンド回復処理
        if (bound_count < Max_Bound && Now_timer > 1000)
        {
            if (bound_count < Max_Bound)
            {
                bound_count++;
                Now_timer = 0;
            }
        }

        //移動 
        Vector3 v = new Vector3(x, 0, 0);
        rb2d.velocity = v;

#if  UNITY_ANDROID
        if (Input.gyro.enabled)
        {
            Vector3 And_v = new Vector3(Move_Input_z, 0, 0);
            rb2d.velocity = And_v;
        }
#endif
    }

    //泡発生処理
    public IEnumerator CreateFoam(Transform tra,GameObject g)
    {
        Instantiate(g, tra.position, Quaternion.identity);
        yield return new WaitForSeconds(2);
    }

}
