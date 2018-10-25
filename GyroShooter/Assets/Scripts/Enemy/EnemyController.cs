using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	[SerializeField]
	private ParameterTable_Enemy table = null;
	[SerializeField]
	float deletePosZ = 0;

	Rigidbody rb;
	Vector3 moveForce = Vector3.zero;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		moveForce.z = table.speed;
	}

	// Update is called once per frame
	void Update()
	{
		Move();

		if (this.gameObject.transform.position.z < deletePosZ)
		{
			Delete();
		}
	}
    
	void Move()
	{
		rb.velocity = moveForce;
	}

    void Delete()
	{
		this.gameObject.SetActive(false);
	}
}