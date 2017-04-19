using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public float speed = 15.0f;
	float xmin, xmax;
	float padding = 1f;
	float newX;
	public float boxWidth = 10f;
	public float boxHeight = 5f;

	public GameObject enemyPrefab;
	// Use this for initialization
	void Start () {
		foreach (Transform child in transform){
			GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity)as GameObject;
			enemy.transform.parent = child.transform;
		}
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3(1,0,distance));
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
		newX = Mathf.Clamp(transform.position.x,xmin,xmax);
	}
	void OnDrawGizmos(){
		Gizmos.DrawWireCube (transform.position, new Vector3(boxWidth,boxHeight));
	}
	// Update is called once per frame
	void Update () {
		float curX = transform.position.x;
		if ( curX <= xmin) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

	
	}
}
