using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class hungerSpaceCT : ConditionTask {

        public Blackboard agentBlackboard;
        public BBParameter<float> hunger;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
            return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {

        }

        //Called whenever the condition gets disabled.
        protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {

            if (Input.GetKeyDown("space") && hunger.value < 75)
            {
                Debug.Log("this would start sub fsm");
                return true;
            }
            else 
            {
                return false;

            }
		}
	}
}