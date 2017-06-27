using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour {

    public static int count = 0;

    void Awake()
    {
        count = 0;
    }

    //goto enemyのタイプに加算量を調整
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            count++;
            //Debug.Log(count);
        }
    }
}
