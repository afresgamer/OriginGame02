using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class Enemy : ScriptableObject {
    
    public float Speed;
    public float smoothing;
    public int damage;

    public static void Move(Rigidbody2D Fish_rb2D ,Vector3 vec)
    {
        Fish_rb2D.AddForce(vec);
    }

}
