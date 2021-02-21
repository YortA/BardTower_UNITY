using UnityEngine;

public class SpawnZone : MonoBehaviour
{
	//public Vector3 Center;				// If we want to control the spawn location indivudally -- we can call this variable
	public Vector3 Size;


	public Vector3 SpawnPoint
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
		Gizmos.color = new Color(0, 0, 1, 0.7f);
		//Gizmos.DrawCube(transform.position, Size);
		Gizmos.DrawCube(Vector3.zero, Size);
	}
}
