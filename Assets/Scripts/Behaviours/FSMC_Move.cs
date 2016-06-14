using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class FSMC_Move : FSMC_Base
	{
		private float mSpeed;

		private float mCurrentTime;
		private Vector3	mInitPosition;
		private Vector3	mFinalPosition;

		public FSMC_Move (GameObject go) : base(go)
		{
			mInitPosition = mGO.transform.localPosition;
		}

		public void MoveTo(Vector3 target, float speed) {
			mCurrentTime = 0f;
			mSpeed = speed;
			mFinalPosition = mInitPosition + target;
		}

		public override void Update (float dt)
		{
			base.Update (dt);

			mCurrentTime += dt * mSpeed;

			if (mCurrentTime >= 1f) {
				mCurrentTime = 1f;
				mIsActive = false;
			}

			float x = Mathf.Lerp (mInitPosition.x, mFinalPosition.x, mCurrentTime);
			float y = Mathf.Lerp (mInitPosition.y, mFinalPosition.y, mCurrentTime);

			mGO.transform.localPosition = new Vector3 (x, y);
		}
	}
}

