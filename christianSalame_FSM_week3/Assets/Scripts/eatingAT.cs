using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class eatingAT : ActionTask {

        public Blackboard agentBlackboard;
        public float hunger;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {

            agentBlackboard = agent.GetComponent<Blackboard>();

            hunger = agentBlackboard.GetVariableValue<float>("hunger");
            
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

            float hunger = agentBlackboard.GetVariableValue<float>("hunger");

            hunger += 25;

            agentBlackboard.SetVariableValue("hunger", hunger);
			
			Debug.Log(hunger);

			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}