// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using VRTK;
using VRTK.UnityEventHelper;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK Interaction")]
	[Tooltip("Pointer Destination info returns the values of the location and gameobject that you select with your pointer. This action requires the VRTK Destination Marker Unity Events script to be attached to a controller along with the pointer script.")]

	public class  pointerDestinationInfo : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.UnityEventHelper.VRTK_DestinationMarker_UnityEvents))]    
		public FsmOwnerDefault gameObject;

		[UIHint(UIHint.Variable)]
		[TitleAttribute("Vector 3")]
		public FsmVector3 hitObjectVector3;

		[UIHint(UIHint.Variable)]
		[TitleAttribute("Normal")]
		public FsmVector3 normal;

		[UIHint(UIHint.Variable)]
		public FsmFloat distance;

		[UIHint(UIHint.Variable)]
		public FsmGameObject hitObject;

		[UIHint(UIHint.Variable)]
		[ObjectType(typeof(Transform))]
		[TitleAttribute("Transform")]
		public FsmObject target;

		[UIHint(UIHint.Variable)]
		public FsmInt controllerIndex;

		private VRTK.UnityEventHelper.VRTK_DestinationMarker_UnityEvents controlEvents;
		public override void Reset()
		{

			gameObject = null;
			hitObjectVector3 = null;
			hitObject = null;
			distance = null;
			target = null;
			controllerIndex = null;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			controlEvents = go.GetComponent<VRTK.UnityEventHelper.VRTK_DestinationMarker_UnityEvents>();

			if (controlEvents == null)
			{
				controlEvents = go.AddComponent<VRTK.UnityEventHelper.VRTK_DestinationMarker_UnityEvents>();
			}

			controlEvents.OnDestinationMarkerEnter.AddListener(DestinationChange);

		}

		private void DestinationChange(object sender, DestinationMarkerEventArgs e)
		{

			hitObjectVector3.Value = e.destinationPosition;
			distance.Value = e.distance;
			hitObject.Value = e.raycastHit.collider.gameObject;
			normal.Value = e.raycastHit.normal;
			target.Value = e.target as Object;
			controllerIndex.Value = (int)e.controllerIndex;

		}

	}

}


