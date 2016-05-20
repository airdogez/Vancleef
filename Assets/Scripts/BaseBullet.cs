using UnityEngine;
using System.Collections;

public class BaseBullet : MonoBehaviour{
  protected float mSpeed;
  protected float mPower;
  protected Vector2 mDirection;
  protected EnumBullet mBulletType;
  protected SpriteRenderer sr;

  public bool IsAlive;
  //Posicion
  Vector3 leftBottom;
  Vector3 rightTop;

  public EnumBullet BulletType{ get {return mBulletType;}}

  void Start() {
    sr = this.GetComponent<SpriteRenderer>();
    Util.ComputeResponsiveScreenPoints(Camera.allCameras[0], out leftBottom, out rightTop);
    IsAlive = true;
  }

  public void SetConfiguration(float speed, float power, Vector2 direction, EnumBullet bulletType){
    mSpeed = speed;
    mPower = power;
    mDirection = direction;
    mBulletType = bulletType;
  }

  void Update() {
    if(IsAlive){
      Vector2 pos = this.gameObject.transform.localPosition;
      pos.x = (mDirection.y * mSpeed ) * Time.deltaTime;
      pos.y = (mDirection.y * mSpeed ) * Time.deltaTime;
      this.transform.localPosition = pos;
      if (pos.y - sr.bounds.size.y * 0.5f> rightTop.y) {
        this.IsAlive = false;
        GameObject.Destroy(this.gameObject);
      }
    }

  }

}
