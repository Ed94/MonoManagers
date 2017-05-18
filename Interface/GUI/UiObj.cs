using AbstractRealm.Realm_Space;
using System;


namespace AbstractRealm.Interface
{
    public class UIObj
    {
        string name;

        public RigidBillboard billboard;

        public Tuple<int, int> position;

        Delegate instruction;

        public UIObj(RigidBillboard passedBillboard, Delegate passedInstruction, Tuple<int, int> passedTuple)
        {
            billboard = passedBillboard;

            instruction = passedInstruction;

            position = passedTuple;
        }

        public UIObj(string passedName, RigidBillboard passedBillboard, Delegate passedInstruction, Tuple<int, int> passedTuple)
        {
            name = passedName;

            billboard = passedBillboard;

            instruction = passedInstruction;

            position = passedTuple;
        }

        public void runInstruction()
        {
            if (name == null)
            {
                instruction.DynamicInvoke();
            }
            else
            {
                instruction.DynamicInvoke(name);
            }
        }
    }
}
