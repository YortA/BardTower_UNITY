using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDestinationRandom : MonoBehaviour
{
	public Vector3 Size;

	public static TargetDestinationRandom MoveBehave { get; private set; }

	private void Awake()
	{
		if (MoveBehave == null)
		{
			MoveBehave = this;
		}
	}

	public Vector3 TargetPoint
	{
		get
		{
			Vector3 Position = transform.position + new Vector3(Random.Range(-Size.x / 2, Size.x / 2), Random.Range(-Size.y / 2, Size.y / 2), Random.Range(-Size.z / 2, Size.z / 2));
			return Position;
		}
	}
	private void OnDrawGizmosSelected()
	{
		Gizmos.matrix = this.transform.localToWorldMatrix;
		Gizmos.color = new Color(1, 0, 0, 0.7f);
		Gizmos.DrawCube(Vector3.zero, Size);
	}
}
