// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK Pointer")]
	[Tooltip("Set Bezier Pointer apperance.")]

	public class SetBezierPointerApperance : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_BezierPointerRenderer))]    
		public FsmOwnerDefault gameObject;

		public FsmFloat maximumLength;
		public FsmInt tracerDensity;
		public FsmFloat cursorRadius;

		public FsmBool everyFrame;

		VRTK.VRTK_BezierPointerRenderer theScript;

		public override void Reset()
		{

			maximumLength = null;
			tracerDensity = null;
			cursorRadius = null;
			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);


			theScript = go.GetComponent<VRTK.VRTK_BezierPointerRenderer>();

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

			theScript.maximumLength.x = maximumLength.Value;
			theScript.tracerDensity = tracerDensity.Value;
			theScript.cursorRadius = cursorRadius.Value;
		}

	}
}