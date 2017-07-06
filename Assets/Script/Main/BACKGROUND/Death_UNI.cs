using UnityEngine;

public class Death_UNI : MonoBehaviour {

    int count = 0;
    //public static int Background_Count;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            count++;
        }
        if(other.gameObject.tag == "Enemy/Fish")
        {
            count++;
            Debug.Log("Fish is Enter");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //Debug.Log("Enemy on Field");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            //Debug.Log("Enemy is exit");
            if(count >= 1)
            {
                Destroy(other.gameObject);
                count = 0;
            }
        }
        if (other.gameObject.tag == "Enemy/Fish")
        {
            Debug.Log("Fish is exit");
            if (count > 2)
            {
                Destroy(other.gameObject);
                count = 0;
            }
        }
    }
}
