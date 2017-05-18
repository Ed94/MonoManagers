using AbstractRealm.Realm_Space;
using AbstractRealm.Assets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace AbstractRealm.Interface
{
    public class UiGrid
    {
        UIObj[,] NaviGrid;

        public Tuple<int, int> edge    ;
        public Tuple<int, int> position;

        public RigidBillboard selection;

        public UiGrid(AssetMngr assetMngr)
        {
            position = new Tuple<int, int>(0, 0);

            assetMngr.LoadStateResource("UI");

            foreach (KeyValuePair<string, Texture2D> texture in AssetMngr.currentTextures)
            {
                if (texture.Key.Contains("uiSelection"))
                {
                    Console.WriteLine("here!");
                    selection = new RigidBillboard(texture.Value);
                }
            }
        }

        public void createGrid(int sizeX, int sizeY)
        {
            NaviGrid = new UIObj[sizeX, sizeY];

            edge = new Tuple<int, int>(sizeX, sizeY);

            Console.WriteLine("Grid Made... Edge: " + edge.Item1 + " " + edge.Item2);
        }

        public void setGrid(UIObj uiObj, int posX, int posY)
        {
            if (NaviGrid[posX, posY] == null)
            {
                NaviGrid[posX, posY] = uiObj;

                Console.WriteLine("Object set:" + uiObj+ "At position: "+ posX+ " "+ posY);
            }
            else if (NaviGrid[posX, posY].Equals(uiObj) == false)
            {
                NaviGrid[posX, posY] = uiObj;

                Console.WriteLine("Object set:" + uiObj + "At position: " + posX + " " + posY);
            }
        }

        public UIObj getSelObject()
        {
            return NaviGrid[position.Item1, position.Item2];
        }

        public UIObj getObject(int posX, int posY)
        {
            return NaviGrid[posX, posY];
        }

        public enum direction { up, down, left, right }
        public void updateGridPos(direction letsAGO)
        {
            switch (letsAGO)
            {
                case direction.up:
                    if (position.Item2 > 0)
                    { position = new Tuple<int, int>(position.Item1, position.Item2 - 1); }
                    break;

                case direction.down:
                    if (position.Item2 < edge.Item2 - 1)
                    { position = new Tuple<int, int>(position.Item1, position.Item2 + 1); }
                    break;

                case direction.left:
                    if (position.Item1 > 0)
                    { position = new Tuple<int, int>(position.Item1 - 1, position.Item2); }
                    break;

                case direction.right:
                    if (position.Item1 < edge.Item1 - 1)
                    { position = new Tuple<int, int>(position.Item1 + 1, position.Item2); }
                    break;
            }
        }

        public void updateSelected()
        {
            Vector3 size = NaviGrid[position.Item1, position.Item2].billboard.getSize();

            size = Vector3.Multiply(size, 1.1f);

            Vector3 selPosition = new Vector3(NaviGrid[position.Item1, position.Item2].position.Item1, NaviGrid[position.Item1, position.Item2].position.Item2, 0);

            selection.setSize      (size       );
            selection.moveBillboard(selPosition);
        }
    }
}