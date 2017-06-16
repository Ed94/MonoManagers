//C#
using System;
//AbstractRealm
using AbstractRealm.Realm_Space;


namespace AbstractRealm.Interface
{
    public class UIObj
    {
        //Public
        public UIObj(RigidBillboard passedBillboard, Delegate passedInstruction, Tuple<int, int> passedTuple)
        {
            billboard   = passedBillboard  ;
            instruction = passedInstruction;
            position    = passedTuple      ;
        }

        public UIObj(string passedName, RigidBillboard passedBillboard, Delegate passedInstruction, Tuple<int, int> passedTuple)
        {
            billboard   = passedBillboard  ;
            instruction = passedInstruction;
            name        = passedName       ;
            position    = passedTuple      ;
        }


        public void runInstruction()
        {
            if (name == null)
                instruction.DynamicInvoke    ();
            else
                instruction.DynamicInvoke(name);
        }

        public Tuple<int, int> getPosition()
        { return position; }


        public RigidBillboard billboard;

        //Private
        private string name;

        private Delegate        instruction;
        private Tuple<int, int> position   ;
    }
}
