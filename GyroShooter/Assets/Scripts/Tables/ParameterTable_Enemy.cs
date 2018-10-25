using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "MyGame/Create ParameterTable_Enemy", fileName = "ParameterTable_Enemy")]

public class ParameterTable_Enemy : ScriptableObject
{
	[SerializeField]
	public int life = 100;
	[SerializeField]
	public int attack = 1;
	[SerializeField]
	public int defense = 0;
	[SerializeField]
	public float speed = 1;

	[SerializeField]
	public Vector3 spawnPos = new Vector3(0, 0, 30);
	[SerializeField]
	public Vector3 scale = new Vector3(1, 1, 1);

	[SerializeField]
	public Color color = new Color(1, 0, 0);
}