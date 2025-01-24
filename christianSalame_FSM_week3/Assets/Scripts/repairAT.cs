using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    public class RepairAT : ActionTask
    {

        public BBParameter<Transform> targetTransform;
        public float repairRate;
        Blackboard lightTowerBlackboard;
        float maxRepairValue;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit()
        {
            return null;
        }

        //This is called once each time the task is enabled.
        //Call EndAction() to mark the action as finished, either in success or failure.
        //EndAction can be called from anywhere.
        protected override void OnExecute()
        {
            lightTowerBlackboard = targetTransform.value.GetComponentInParent<Blackboard>();

            maxRepairValue = lightTowerBlackboard.GetVariableValue<float>("activeThreshold");
        }

        //Called once per frame while the action is active.
        protected override void OnUpdate()
        {
            float currentRepairValue = lightTowerBlackboard.GetVariableValue<float>("repairValue");
            currentRepairValue += repairRate * Time.deltaTime;
            lightTowerBlackboard.SetVariableValue("repairValue", currentRepairValue);


            if (maxRepairValue < currentRepairValue)
            {
                EndAction(true);
            }

        }

        //Called when the task is disabled.
        protected override void OnStop()
        {

        }

        //Called when the task is paused.
        protected override void OnPause()
        {

        }
    }
}