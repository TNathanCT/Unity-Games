using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	GameObject pathGO;

	Transform targetPathNode;
	int pathNodeIndex = 0;
	float speed = 5f;
	public float health = 1f;


	// Use this for initialization
	void Start () {
		pathGO = GameObject.Find("Path");
	}

	void GetNextPathNode() {
		if(pathNodeIndex < pathGO.transform.childCount) {
			targetPathNode = pathGO.transform.GetChild(pathNodeIndex);
			pathNodeIndex++;
		}
		else {
			targetPathNode = null;
			ReachedGoal();
		}
	}
	void Update () {
		if(targetPathNode == null) {
			GetNextPathNode();
			if(targetPathNode == null) {
				ReachedGoal();
				return;
			}
		}

		Vector3 dir = targetPathNode.position - this.transform.localPosition;

		float distThisFrame = speed * Time.deltaTime;

		if(dir.magnitude <= distThisFrame) {
			targetPathNode = null;
		}
		else {
			transform.Translate( dir.normalized * distThisFrame, Space.World );
			Quaternion targetRotation = Quaternion.LookRotation( dir );
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime*5);
		}

	}

	void ReachedGoal() {
	
		Destroy(gameObject);
	}

	public void TakeDamage(float damage) {
		health -= damage;
		if(health <= 0) {
			Die();
		}
	}

	public void Die() {
		Destroy(gameObject);
	}
}
