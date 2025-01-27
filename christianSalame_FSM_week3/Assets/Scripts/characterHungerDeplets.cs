using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class characterHungerDeplets : ActionTask {

		public Blackboard agentBlackboard;
		public float hunger;
		public float hungerDeplet;
		

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

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

            float hunger = agentBlackboard.GetVariableValue<float>("hunger");

            hunger -= hungerDeplet * Time.deltaTime;

			agentBlackboard.SetVariableValue("hunger", hunger);

			Debug.Log(hunger);

			if (hunger < 50) 
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