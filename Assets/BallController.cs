using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    [SerializeField]
    float distanceSpeedMultiplier = 0.5f;

    Rigidbody2D rigidboby;
    LineRenderer lineRenderer;

    bool launched = false;

	// Use this for initialization
	void Start () {

        rigidboby = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();

        if (rigidboby)
            rigidboby.velocity = new Vector2(5f, 5f);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TurnLineOn() {
        lineRenderer.enabled = true;
    }

    public void TurnLineOff() {
        lineRenderer.enabled = false;
    }

    public void DrawLineFromBall(Vector2 pos) {

        
        Vector3[] positions = new Vector3[2] { transform.position, pos };
        lineRenderer.SetPositions(positions);

    }

    public void LaunchBall(Vector2 pos) {
        rigidboby.constraints = RigidbodyConstraints2D.None;

        float distance = Vector2.Distance(transform.position, pos);


        rigidboby.velocity = new Vector2(-pos.x * distance * distanceSpeedMultiplier, -pos.y * distance * distanceSpeedMultiplier);

    }

    public void ResetBall() {
        transform.position = Vector3.zero;
        rigidboby.constraints = RigidbodyConstraints2D.FreezeAll;
    }

}
