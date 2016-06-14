using UnityEngine;
using System.Collections;

public class GrazeBar : MonoBehaviour {

  public RectTransform transform;

  public void setBarScale(float scale)
  {
    transform.localScale = new Vector2(scale, 1);
  }
}
