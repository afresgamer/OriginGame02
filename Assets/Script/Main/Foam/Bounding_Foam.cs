using UnityEngine;

public class Bounding_Foam : Foam {

    private CircleCollider2D cc2D;

    private void Awake()
    {
        cc2D = GetComponent<CircleCollider2D>();
        cc2D.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Debug.Log(other.gameObject);
            cc2D.isTrigger = false;
        }
    }

}
