using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    [SerializeField]
    private Transform Target;
    [SerializeField]
    private float smoothing = 5;
    [SerializeField]
    private float Max_height = 2;
    
    Vector3 offset;


	void Start () {
        offset = transform.position - Target.position;
	}
	
	void Update () {
        Vector3 targetCampos = Target.position + offset;
        float height = Target.transform.position.y;
        float p_width = Mathf.Lerp(transform.position.x, targetCampos.x, smoothing * Time.deltaTime);
        if (height < Max_height && height > -Max_height)
        { 
            transform.position = Vector3.Lerp(transform.position, targetCampos, smoothing * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3(p_width, transform.position.y, transform.position.z);
        }
        
	}
}
