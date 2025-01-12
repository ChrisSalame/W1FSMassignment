using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.XR;


namespace NodeCanvas.Tasks.Actions {

	public class patchScaredAT : ActionTask {

		public float scaredTimer = 5f;
		private float currentTime = 0f;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}
		
		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			Debug.Log("Patch is now scared");
            agent.transform.localScale = new Vector3 (0.25f,0.25f,0.25f);
            currentTime = 0f;
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			Camera.main.transform.Translate(0, 0, -0.01f); ;

			currentTime += Time.deltaTime;
			if (currentTime >= scaredTimer) 
			{
                EndAction(true);
            }

		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}