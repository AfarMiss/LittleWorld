﻿using ParadoxNotion.Design;
using NodeCanvas.Framework;

namespace FlowCanvas.Nodes
{

    [Name("Get Other Of Type")]
    [Category("Variables/Blackboard")]
    [Description("Use this to get a variable value from blackboards other than the one this flowscript is using")]
    [ContextDefinedOutputs(typeof(Wild))]
    [ContextDefinedInputs(typeof(IBlackboard))]
    public class GetOtherVariable<T> : FlowNode
    {
        public override string name { get { return "Get Variable"; } }
        protected override void RegisterPorts() {
            var bb = AddValueInput<IBlackboard>("Blackboard");
            var varName = AddValueInput<string>("Variable");
            AddValueOutput<T>("Value", () => { return bb.value.GetVariableValue<T>(varName.value); });
        }
    }
}