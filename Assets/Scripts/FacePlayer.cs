using UnityEngine;
using System.Collections;

public class FacePlayer : MonoBehaviour {

	private Animator anim;
	private GameObject player;
	private Animator playerAnim;

	void Start()
	{
		anim = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerAnim = player.GetComponent<Animator> ();
	}

	public void FaceThePlayer()
	{
		if (playerAnim.GetFloat ("LastMoveX") == 1) {
			anim.SetFloat ("LastMoveX", -1);
			anim.SetFloat ("LastMoveY", 0);
		} else if (playerAnim.GetFloat ("LastMoveX") == -1) {
			anim.SetFloat ("LastMoveX", 1);
			anim.SetFloat ("LastMoveY", 0);
		} else if (playerAnim.GetFloat ("LastMoveY") == 1) {
			anim.SetFloat ("LastMoveY", -1);
			anim.SetFloat ("LastMoveX", 0);
		} else if (playerAnim.GetFloat ("LastMoveY") == -1) {
			anim.SetFloat ("LastMoveY", 1);
			anim.SetFloat ("LastMoveX", 0);
		}
	}

	public void ResetFacing()
	{
		anim.SetFloat ("LastMoveX", 0);
		anim.SetFloat ("LastMoveY", 0);
	}
}
