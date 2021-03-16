﻿using UnityEngine;
using System.Collections.Generic;


public enum PacManState { Spawning, Still, Chomping, SuperPacMan }

public class PacMan
{
    protected PacManState _state;
    public PacManState State { 
        get { return _state; } 
        set {
                if (_state != value)
                {
                    this.Log (string.Format("{0} was: {1} now {2}", this.ToString(), _state, value));
                    
                    _state = value;
                }
            } 
    }

    public PacMan()
    {
       
        //Set default state will call notify so make sure this.Ghosts is intitialized first
        this.State = PacManState.Still;
        
    }

    public virtual void Log(string s)
    {
        //nothing
    }
    

}

