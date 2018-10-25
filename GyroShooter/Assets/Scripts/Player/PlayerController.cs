using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Vector3 playerPos;
    private Vector3 mousePos;
	private Vector3 offsetPos;

	private Vector3 beforePos;
	private Vector3 nextPos;

	private Vector3 fixedPlayerPos;

	bool getMouse = false;

	GameObject player;

	[SerializeField]
	float playerAcc = 1.0f;

	[SerializeField]
	float motionRangeX;
	[SerializeField]
	float motionRangeY;

	void Start()
	{
		player = this.gameObject;
		beforePos = player.transform.position;
	}

	void Update()
    {
		// PlayerControl();

		PlayerControlDrag();
    }

    private void PlayerControl()
    {
		if (Input.GetMouseButtonDown(0))
		{
			mousePos = Input.mousePosition;
		}

		if (Input.GetMouseButton(0))
		{
			playerPos = -(mousePos - Input.mousePosition) * playerAcc + offsetPos;
		}

		if (Input.GetMouseButtonUp(0))
		{
			offsetPos = playerPos;
		}      

		player.transform.position = playerPos;
    }

    private void PlayerControlDrag()
	{
		if (Input.GetMouseButton(0))
		{
			var x = Input.GetAxis("Mouse X");
			var y = Input.GetAxis("Mouse Y");
			var dir = new Vector3(x, y, 0);
			player.transform.position += playerAcc * dir;
		}

		fixedPlayerPos = player.transform.position;
		if (player.transform.position.x < -motionRangeX) fixedPlayerPos.x = -motionRangeX;
		if (player.transform.position.x > motionRangeX) fixedPlayerPos.x = motionRangeX;
		if (player.transform.position.y < -motionRangeY) fixedPlayerPos.y = -motionRangeY;
		if (player.transform.position.y > motionRangeY) fixedPlayerPos.y = motionRangeY;
		player.transform.position = fixedPlayerPos;
	}
}