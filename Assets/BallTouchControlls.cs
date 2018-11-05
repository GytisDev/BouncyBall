using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTouchControlls : MonoBehaviour {

    BallController ballController;

    private bool ballTouched = false;

    private void Start() {
        ballController = GetComponent<BallController>();
    }

    // Update is called once per frame
    void Update () {

        Debug.Log(ballTouched);

        if (Input.touchCount > 0) {
     
            Touch touch = Input.GetTouch(0);

            Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
            pos.z = 0;

            Vector2 pos2D = new Vector2(pos.x, pos.y);

            if (touch.phase == TouchPhase.Began) {

                RaycastHit2D hit = Physics2D.Raycast(pos2D, Camera.main.transform.forward);

                if (hit.collider != null) {
                    switch (hit.collider.gameObject.tag) {
                        case "Ball":
                            ballTouched = true;
                            ballController.TurnLineOn();
                            break;
                        default:

                            break;
                    }
                }

            } else if (touch.phase == TouchPhase.Ended && ballTouched) {
                ballTouched = false;
                ballController.TurnLineOff();
                //Paleisti
                ballController.LaunchBall(pos2D);
            }

            if (ballTouched) {
                ballController.DrawLineFromBall(pos2D);
            }

        }

    }
}
