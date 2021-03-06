﻿using SokoBomber2;
using SokoBomber2.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokoBomber2.Engine.States
{
    class StatePlay : IState
    {
		string _lvlGen = "";
		public StatePlay()
		{
			SBGenerator gen = new SBGenerator();
			_lvlGen = gen.SeedGen("1");
		}

        public void Draw(ISpriteBatch _spriteBatch)
        {
            for (int x = 0; x < levelWidth; x++)
            {
                for (int y = 0; y < levelHeight; y++)
                {
                    switch (levelTiles[x,y])
                    {
                        case 0: break;
                        case 1:
                            // Wall
                            _spriteBatch.Draw(0, 0, "tWall", x * 32 + 390 - playerTileX * 32, y * 32 + 210 - playerTileY * 32);
                            break;
                        case 3: // Player starts on a tile too
                        case 2:
                            // Floor
                            _spriteBatch.Draw(0, 0, "tGround", x * 32 + 390 - playerTileX * 32, y * 32 + 210 - playerTileY * 32);
                            break;
                    }
                }
            }

            _spriteBatch.Draw(0, 0, "tPlayerIdle", 390, 210);

            _spriteBatch.Draw("mouse", SokoBomber2Engine.Instance.MouseX, SokoBomber2Engine.Instance.MouseY);
        }

        uint[,] levelTiles;
        uint levelWidth, levelHeight;
        int playerTileX, playerTileY;
        public void Load(IContentManager _content)
        {
            // Art
            _content.Load("tBomb");
            _content.Load("tDiamond");
            _content.Load("tFragments");
            _content.Load("tFuseLit");
            _content.Load("tGround");
            _content.Load("tIce");
            _content.Load("tPlayerDead");
            _content.Load("tPlayerDown");
            _content.Load("tPlayerIdle");
            _content.Load("tPlayerLeft");
            _content.Load("tPlayerUp");
            _content.Load("tTriggerPosition");
            _content.Load("tWall");

            // Level
            Random r = new Random();
            levelWidth = (uint)(5 + r.Next(10));
            levelHeight = (uint)(5 + r.Next(10));
            levelTiles = new uint[levelWidth, levelHeight];
            for (int x = 0; x < levelWidth; x++)
            {
                for (int y = 0; y < levelHeight; y++)
                {
                    if ((x == 0) || (x == levelWidth - 1) || (y == 0) || (y == levelHeight - 1))
                    {
                        levelTiles[x, y] = 1;
                    }
                    else
                    {
                        levelTiles[x, y] = 2;
                    }
                }
            }
            levelTiles[1, 1] = 3;
            playerTileX = 1;
            playerTileY = 1;
            // TODO - enum tile types
        }
        
        public void Update()
        {
            if (SokoBomber2Engine.Instance.KeyRightPressed)
            {
                playerTileX++;
            }
            else if (SokoBomber2Engine.Instance.KeyLeftPressed)
            {
                playerTileX--;
            }
            else if (SokoBomber2Engine.Instance.KeyUpPressed)
            {
                playerTileY--;
            }
            else if (SokoBomber2Engine.Instance.KeyDownPressed)
            {
                playerTileY++;
            }
        }
    }
}
