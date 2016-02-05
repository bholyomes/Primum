using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject followTarget;
	public float moveSpeed;
	
	private static bool cameraExists;

	private Vector3 targetPos;
	
	void Start()
	{
		if(!cameraExists)
		{
			cameraExists = true;
			DontDestroyOnLoad(transform.gameObject);
		} else {Destroy(gameObject);}
	}

	void Update()
	{
		targetPos = new Vector3 (followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, targetPos, moveSpeed * Time.deltaTime);
	}

   

}
