// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTKController")]
	[Tooltip("Trigger haptic rumble with Controller Actions Script from VRTK with advanced settings.")]

	public class  HapticAdvancedRumble : FsmStateAction

	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_ControllerActions))]    
		public FsmOwnerDefault gameObject;

		[Tooltip("Set strength of haptic rumble between 0 and 1")]
		public FsmFloat hapticStrength;

		[Tooltip("Set duration of haptic rumble")]
		public FsmFloat hapticDuration;

		[Tooltip("Set a pulse interbal of haptic rumble")]
		public FsmFloat hapticPulseInterval;

		public FsmBool everyFrame;

		VRTK.VRTK_ControllerActions theScript;

		public override void Reset()
		{

			hapticDuration = null;
			hapticPulseInterval = null;
			hapticStrength = null;
			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<VRTK.VRTK_ControllerActions>();

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

			theScript.TriggerHapticPulse(hapticStrength.Value, hapticDuration.Value, hapticPulseInterval.Value);
				
		}

	}
}