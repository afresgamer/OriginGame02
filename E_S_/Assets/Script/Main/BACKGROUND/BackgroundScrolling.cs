using UnityEngine;

public class BackgroundScrolling : MonoBehaviour {

	public float backgroundSize;
	public float ParalaxSpeed;

	private Transform cameraTranform;
	private Transform[] layers;
	private float viewZone = 3;
	private int LeftIndex;
	private int RightIndex;
	private float LastCameraX;

	private void Start()
	{
		cameraTranform = Camera.main.transform;
		LastCameraX = cameraTranform.position.x;
		layers = new Transform[transform.childCount];

		for (int i = 0; i < transform.childCount; i++)
		{
			layers[i] = transform.GetChild(i);
		}

		LeftIndex = 0;
		RightIndex = layers.Length - 1;
	}

	private void Update()
	{
		float deltaX = cameraTranform.position.x - LastCameraX;
		transform.position += Vector3.right * (deltaX * ParalaxSpeed);
		LastCameraX = cameraTranform.position.x;

		if (cameraTranform.position.x < (layers[LeftIndex].transform.position.x + viewZone))
		{ ScrollLeft(); }

		if (cameraTranform.position.x > (layers[RightIndex].transform.position.x - viewZone))
		{ ScrollRight(); }
	}

	private void ScrollLeft()
	{
		//int LastRight = RightIndex;
		layers[RightIndex].position = 
			Vector3.right * (layers[LeftIndex].position.x - backgroundSize);
		LeftIndex = RightIndex;
		RightIndex--;
		if(RightIndex < 0) { RightIndex = layers.Length - 1;}
	}

	private void ScrollRight()
	{
		//int LastLeft = LeftIndex;
		layers[LeftIndex].position =
			Vector3.right * (layers[RightIndex].position.x + backgroundSize);
		RightIndex = LeftIndex;
		LeftIndex++;
		if (LeftIndex == layers.Length) { LeftIndex = 0; }
	}
}
