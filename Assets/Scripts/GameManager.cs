using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager Instance { get; private set; }
    [HideInInspector] public GameStatus gameStatusValue;
    //[HideInInspector] public ParticleSystem[] confetti;
    void Awake() {
        
        Instance=this;
        gameStatusValue=GameStatus.NONE;

    }

    void Update() {

        /*if(Instance.gameStatusValue==GameStatus.NONE){

            for (int i = 0; i < confetti.Length; i++)
            {
                Instance.confetti[i].Stop();
            }
        }else if(Instance.gameStatusValue==GameStatus.NEXTLEVEL || Instance.gameStatusValue==GameStatus.FINISH){

            for (int i = 0; i < confetti.Length; i++)
            {
                Instance.confetti[i].Play();
            }

        }*/

    }

    public enum GameStatus{
        PLAY,
        FAILED,
        NEXTLEVEL,
        FINISH,
        NONE,
    }
}
