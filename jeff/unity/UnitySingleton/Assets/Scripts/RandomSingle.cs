using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


/// <summary>
/// Shows the right and wrong way to use a singleton
/// </summary>
public class RandomSingle : Singleton<RandomSingle>
{

    public int Rand;
    public Text text;

    //Only for the Demo will use the wrong value if isRight = false
    public bool isRight;

    protected RandomSingle() { } //unity won't use constuctor be safe and make use nothing else does

    void Start()
    {
        UpdateRandom();
    }

    void Update()
    {
        if (isRight)
            this.text.text = RandomSingle.Instance.Rand.ToString();
        else
            this.text.text = Rand.ToString(); //Wrong this is the local instance.
    }

    public void UpdateRandom()
    {
        //Right
        RandomSingle.Instance.Rand = Random.Range(0, 10);

        UpdateRandomWrong();
    }

    public void UpdateRandomWrong()
    {
        //Wrong
        Rand = Random.Range(0, 10);
    }

}
