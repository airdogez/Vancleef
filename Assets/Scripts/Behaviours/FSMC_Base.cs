using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class FSMC_Base
	{
		protected bool mIsActive;
		protected bool mIsParallel;
		protected GameObject mGO;

		public string mStateType;

		public bool IsActive {
			get { return mIsActive; }
		}

		public string StateType { 
			get { return mStateType; }
			set { mStateType = value; }
		}

		public FSMC_Base(GameObject go) {
			mGO = go;
			mIsActive = true;
			mIsParallel = false;
		}

		public virtual void Update(float dt) {

		}
	}
}

