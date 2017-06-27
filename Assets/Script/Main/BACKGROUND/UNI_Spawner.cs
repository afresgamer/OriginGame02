using UnityEngine;

public class UNI_Spawner : MonoBehaviour {

    public GameObject uni;
    private float Now;

    void Start()
    {
        Now = 0;
    }

    void Update () {
        Now += Time.time;
        //Debug.Log(Now);
        if(Now >= 4000)
        {
            Instantiate(uni,transform.position, Quaternion.identity);
            Now = 0;
        }
	}
}
