using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class FSMC_Idle : FSMC_Base
	{
		private float mTimeLimit;
		private float mCurrentTime;

		public FSMC_Idle (GameObject go) : base(go)
		{
			
		}

		public void Wait(float time) {
			mCurrentTime = 0;
			mTimeLimit = time;
		}

		public override void Update (float dt)
		{
			base.Update (dt);

			mCurrentTime += dt;

			if (mCurrentTime >= mTimeLimit) {
				mCurrentTime = mTimeLimit;
				mIsActive = false;
			}
		}
	}
}

