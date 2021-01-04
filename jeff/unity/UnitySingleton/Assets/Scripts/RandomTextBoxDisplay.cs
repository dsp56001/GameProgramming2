using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RandomTextBoxDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    RandomSingle rs;

    public Text text;
    public UnityAction UpdateAction;

    [SerializeField]
    private int randSingle;

    public int RandSingle
    {
        get { return randSingle = rs.Rand; }
    }

    void Start()
    {
        rs = this.gameObject.AddComponent<RandomSingle>();
        UpdateAction += UpdateRandom;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = rs.Rand.ToString();
    }

    public void UpdateRandom()
    {
        rs.UpdateRandom();
    }
}
