using UnityEngine;
using System.Collections;
using UnityCommand;
using System;

public class Player : MonoBehaviour, ICommandComponent
{

    
    public Vector2 Direction = new Vector2(1, 0);
    public float Speed = 10;
    public float Angle;

    public UnityPacMan PacMan { get; private set; }

    private Vector3 moveTranslation;
    private Vector2 moveOnNextUpdate;

    public float MoveAmount = 15f;
    
    // Use this for initialization
	void Start () {
        

        PacMan = new UnityPacMan(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
                                                      
        this.moveTranslation = new Vector3(this.moveOnNextUpdate.x, this.moveOnNextUpdate.y);
        this.transform.position += new Vector3(this.moveTranslation.x, this.moveTranslation.y);
        if (moveOnNextUpdate != Vector2.zero)
        {
            Angle = Mathf.Atan2(this.moveTranslation.y, this.moveTranslation.x) * Mathf.Rad2Deg;
            this.transform.eulerAngles = new Vector3 (0, 0, Angle);
        }
        //clear for next move
        moveOnNextUpdate = Vector2.zero;
    }

    public void MoveDown()
    {
        moveOnNextUpdate += new Vector2(0, -MoveAmount * Time.deltaTime);
    }

    public void MoveUp()
    {
        moveOnNextUpdate += new Vector2(0, MoveAmount * Time.deltaTime);

    }

    public void MoveLeft()
    {
        moveOnNextUpdate += new Vector2(-MoveAmount * Time.deltaTime, 0);
    }

    public void MoveRight()
    {
        moveOnNextUpdate += new Vector2(MoveAmount * Time.deltaTime, 0);
    }
}
