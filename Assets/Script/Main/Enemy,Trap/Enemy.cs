using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class Enemy : ScriptableObject {
    
    public float Speed;
    public int damage;

    public static void Move(Rigidbody2D Fish_rb2D ,Vector3 vec)
    {
        Fish_rb2D.AddForce(vec);
    }

    public static void Move(Transform tran,float Speed, bool playerFind)
    {
        tran.position += -tran.right / 10 * Speed * Time.deltaTime;
    }

}
