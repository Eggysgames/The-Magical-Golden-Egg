using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EggysGamesLogo : MonoBehaviour {




    void Start() {


    }


    void Update() {


    }


    public void eggysgames() {
        Application.ExternalEval("window.open(\"http://www.eggysgames.com\",\"_blank\")");
    }

    public void googleplay() {
        Application.ExternalEval("window.open(\"https://play.google.com/store/apps/dev?id=8230252676182821509\",\"_blank\")");
    }
}
