using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using System.Collections.Generic;

public class FSMEngine : MonoBehaviour {

  private int mIndex;
  private int mPersistenIndex;
  public List<string> Behaviours;

  private FSMC_Base mCurrentState;

  // Use this for initialization
  void Start () {
    mIndex = 0;
    mPersistenIndex = -1;
  }

  private void ChangeState(Dictionary<string, object> dict) {
    string stateType = (string)dict ["type"];

    FSMC_Base newState = null;

    switch (stateType) {
      case "idle":
        newState = new FSMC_Idle (this.gameObject);
        ((FSMC_Idle)newState).Wait((float)dict["time"]);
        break;
      case "move":
        Vector3 target = Vector3.zero;
        target.x = (float)dict["x"];
        target.y = (float)dict["y"];

        float moveSpeed = (float)dict["speed"];

        newState = new FSMC_Move (this.gameObject);
        ((FSMC_Move)newState).MoveTo(target, moveSpeed);
        break;
    }

    if (newState != null) {
      newState.StateType = stateType;

      mCurrentState = newState;
    }
  }

  // Update is called once per frame
  void Update () {
    if (this.Behaviours.Count > 0) {
      if (mPersistenIndex != mIndex) {
        string rawScript = this.Behaviours [mIndex];
        Dictionary<string, object> dict = Util.ParseScript (rawScript);

        mPersistenIndex = mIndex;
        // cambiar estado
        this.ChangeState (dict);
      }

      if (mCurrentState != null) {
        mCurrentState.Update (Time.deltaTime);

        if (!mCurrentState.IsActive) {
          mIndex++;

          if (mIndex == this.Behaviours.Count) {
            mIndex = 0;
          }
        }
      }

      /*if (!fsmc.IsActive) {
        this.Behaviours.RemoveAt (0);
        }*/
    }
  }
}
