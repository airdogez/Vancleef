using UnityEngine;
using System.Collections;

public class BulletFactory{

  public BulletFactory(){
  }

  public void CreateBullet(float speed, float power, Vector2 direction, EnumBullet bulletType){
    GameObject goBullet = null;
    switch (bulletType){
      case EnumBullet.Enemy:

        break;
      case EnumBullet.Player:
        goBullet = Util.LoadPFab("Prefabs/prefab_player_bullet");
        break;
    }

    BaseBullet bb = goBullet.GetComponent<BaseBullet> ();
    if (goBullet != null)
      bb.SetConfiguration(speed, power, direction, bulletType);
  }

}
