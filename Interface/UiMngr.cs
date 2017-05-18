using System;
using Microsoft.Xna.Framework.Graphics;
using AbstractRealm.Realm_Space;
using Microsoft.Xna.Framework;
using AbstractRealm.Input;

namespace AbstractRealm.Interface
{
    public class UiMngr
    {


        public UiMngr()
        {

        }


        public static UIObj createUIObj(Texture2D passedText, Delegate passedDel, Tuple<int, int> passedPosition, float passedScale)
        {
            RigidBillboard uiBB = new RigidBillboard(passedText);

            uiBB.scaleBillboard(passedScale);
            uiBB.moveBillboard(new Vector3(passedPosition.Item1, passedPosition.Item2, 0));

            UIObj uiObj = new UIObj(uiBB, passedDel, passedPosition);

            return uiObj;
        }

        public static UIObj createUIObj(string name, Texture2D passedText, Delegate passedDel, Tuple<int, int> passedPosition, float passedScale)
        {
            RigidBillboard uiBB = new RigidBillboard(passedText);

            uiBB.scaleBillboard(passedScale);
            uiBB.moveBillboard(new Vector3(passedPosition.Item1, passedPosition.Item2, 0));

            UIObj uiObj = new UIObj(name, uiBB, passedDel, passedPosition);

            return uiObj;
        }

        public static void checkInput(UiGrid passedGrid, InputMngr inputMngr)
        {
            if (inputMngr.checkInput(Input.InputMngr.controls.pressEnter))
            {
                UIObj activeObject = passedGrid.getSelObject();

                activeObject.runInstruction();
            }

            if (inputMngr.checkInput(Input.InputMngr.controls.pressUp   ))
            {
                passedGrid.updateGridPos(UiGrid.direction.up);
            }

            if (inputMngr.checkInput(Input.InputMngr.controls.pressLeft ))
            {
                passedGrid.updateGridPos(UiGrid.direction.left);
            }
            
            if (inputMngr.checkInput(Input.InputMngr.controls.pressDown ))
            {
                passedGrid.updateGridPos(UiGrid.direction.down);
            }

            if (inputMngr.checkInput(Input.InputMngr.controls.pressRight))
            {
                passedGrid.updateGridPos(UiGrid.direction.right);
            }

            passedGrid.updateSelected();
        }

        public static void drawUi(UiGrid passedGrid, BasicEffect basicEffect)
        {
            for(int posY = 0; posY < passedGrid.edge.Item2; posY++)
            {
                for(int posX = 0; posX < passedGrid.edge.Item1; posX++)
                {
                    if (passedGrid.getObject(posX, posY) != null)
                    {
                        UIObj crtUiObj = passedGrid.getObject(posX, posY);

                        passedGrid.selection.Draw(basicEffect);

                        crtUiObj.billboard.Draw(basicEffect);
                    }
                }
            }
        }
    }
}
