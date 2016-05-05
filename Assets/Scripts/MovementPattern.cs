using UnityEngine;
using System.Collections;

public class MovementPattern : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public class ZigZagPattern {
        int xAmplitude, yAmplitude, movementSpeed;
        int movingRight;
        Rigidbody2D body;
        Vector2 startPos;
        public ZigZagPattern(int xAmp, int yAmp, int speed, GameObject g)
        {
            this.xAmplitude = xAmp;
            this.yAmplitude = yAmp;
            this.movementSpeed = speed;
            body = g.GetComponent<Rigidbody2D>();
            startPos = body.position;
            this.movingRight = 1;
            body.velocity = new Vector2(movingRight * xAmplitude, -yAmplitude).normalized * movementSpeed;
        }

        public void Move()
        {
            if (body.position.x >= (startPos.x + xAmplitude / 2))
            {
                body.velocity = new Vector2(-xAmplitude, -yAmplitude).normalized * movementSpeed;
                
            }
            else if (body.position.x <= (startPos.x - xAmplitude / 2))
            {
                body.velocity = new Vector2(xAmplitude, -yAmplitude).normalized * movementSpeed;

            }
        }
        
    }

    public class TargetedPattern
    {
        Rigidbody2D thisBody, targetBody;
        Vector2 lastVector;
        int aggression, moveSpeed;
        float acquireTargetTime;
        public TargetedPattern(int moveSpeed, int aggression, GameObject self, GameObject target)
        {
            this.thisBody = self.GetComponent<Rigidbody2D>();
            this.targetBody = target.GetComponent<Rigidbody2D>();
            this.aggression = aggression;
            this.moveSpeed = moveSpeed;
            acquireTargetTime = 0;
        }
        public void Move()
        {
            if (Time.time > acquireTargetTime)
            {
                thisBody.velocity = (targetBody.position - thisBody.position).normalized * moveSpeed;
                acquireTargetTime = Time.time + (1 / aggression);}
        }

    }
}
