//C#
using System;
//Monogame
using Microsoft.Xna.Framework         ;
using Microsoft.Xna.Framework.Graphics;
//AbstractRealm
using AbstractRealm.Input      ;
using AbstractRealm.Realm_Space;


namespace AbstractRealm.Interface
{
    public class UiMngr
    {
        public static UIObj createUIObj(Texture2D passedText, Delegate passedDel, Tuple<int, int> passedPosition, float passedScale)
        {
            RigidBillboard uiBB = new RigidBillboard(passedText);

            uiBB.scaleBillboard(passedScale                                               );
            uiBB.moveBillboard (new Vector3(passedPosition.Item1, passedPosition.Item2, 0));

            return new UIObj(uiBB, passedDel, passedPosition);
        }

        public static UIObj createUIObj(string name, Texture2D passedText, Delegate passedDel, Tuple<int, int> passedPosition, float passedScale)
        {
            RigidBillboard uiBB = new RigidBillboard(passedText);

            uiBB.scaleBillboard(passedScale                                               );
            uiBB.moveBillboard (new Vector3(passedPosition.Item1, passedPosition.Item2, 0));

            return new UIObj(name, uiBB, passedDel, passedPosition);
        }

        public static void checkInput(UiGrid passedGrid, InputMngr inputMngr)
        {
            if (inputMngr.checkInput(controls.pressEnter))
            {
                UIObj activeObject = passedGrid.getSelObject();

                activeObject.runInstruction();
            }

            if (inputMngr.checkInput(controls.pressUp   ))
                passedGrid.updateGridPos(UiGrid.direction.up);

            if (inputMngr.checkInput(controls.pressLeft ))
                passedGrid.updateGridPos(UiGrid.direction.left);
            
            if (inputMngr.checkInput(controls.pressDown ))
                passedGrid.updateGridPos(UiGrid.direction.down);

            if (inputMngr.checkInput(controls.pressRight))
                passedGrid.updateGridPos(UiGrid.direction.right);

            passedGrid.updateSelected();
        }

        public void drawUi(UiGrid passedGrid, BasicEffect basicEffect)
        {
            for(int posY = 0; posY < passedGrid.edge.Item2; posY++)
            {
                for(int posX = 0; posX < passedGrid.edge.Item1; posX++)
                {
                    if (passedGrid.getObject(posX, posY) != null)
                    {
                        UIObj crtUiObj = passedGrid.getObject(posX, posY);

                        passedGrid.selection.draw(basicEffect);
                        crtUiObj  .billboard.draw(basicEffect);
                    }
                }
            }
        }
    }
}
