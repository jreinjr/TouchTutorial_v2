// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTKController")]
	[Tooltip("Get button one pressed event for VRTK.")]

	public class  GetButtonOneTouched : FsmStateAction

	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_ControllerEvents))]    
		public FsmOwnerDefault gameObject;

		[Tooltip("This will be true if button one is being touched.")]
		public FsmBool buttonOneTouched;

		public FsmBool everyFrame;

		VRTK.VRTK_ControllerEvents theScript;

		public override void Reset()
		{

			buttonOneTouched = false;
			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<VRTK.VRTK_ControllerEvents>();

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

			buttonOneTouched.Value = theScript.buttonOneTouched;

		}

	}
}