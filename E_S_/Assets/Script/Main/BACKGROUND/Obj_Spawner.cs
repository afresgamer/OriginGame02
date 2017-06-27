using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Spawner : MonoBehaviour {

    SpriteRenderer sr;
    [SerializeField]
    private Sprite[] sprite;
    [SerializeField]
    private Player p;
    Transform AttachPoint;
    [SerializeField]
    private GameObject foam;

    float Timer = 2;
    float Speed = 1;

	void Start () {
        sr = GetComponent<SpriteRenderer>();
        AttachPoint = transform.GetChild(0);
        int Ran_Num = Random.Range(0, sprite.Length);
        sr.sprite = sprite[Ran_Num];
	}

    void Update()
    {
        Timer -= Speed * Time.deltaTime;
        if (Timer < 0) { StartCoroutine(p.CreateFoam(AttachPoint,foam)); Timer = 3; }
    }

}
