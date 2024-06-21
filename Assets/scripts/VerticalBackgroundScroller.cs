using UnityEngine;

public class VerticalBackgroundScroller : MonoBehaviour
{
	public Transform target;

	void Start() {

	}

	void Update() {
		Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);

		transform.position = targetPos;
	}
}
