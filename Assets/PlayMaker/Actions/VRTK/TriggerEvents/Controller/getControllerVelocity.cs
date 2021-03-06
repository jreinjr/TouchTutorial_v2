// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using VRTK;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTKController")]
	[Tooltip("Get controller velocity.")]

	public class  getControllerVelocity : FsmStateAction

	{
		[RequiredField]
		public FsmOwnerDefault gameObject;
		public FsmVector3 controllerVelocity;
		public FsmBool everyFrame;

		public override void Reset()
		{

			controllerVelocity = null;
			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			if (!everyFrame.Value)
			{
				MakeItSo();
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				MakeItSo();
			}
		}


		void MakeItSo()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}

			controllerVelocity.Value = VRTK.VRTK_DeviceFinder.GetControllerVelocity(go);

		}

	}
}