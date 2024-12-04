using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootlegTetris
{
    class Game

    {
        private const int WAIT_TIME = 700;
        private const int BOARD_LINE_WIDTH = 1;
        private const int BLOCK_SIZE = 16;
        private const int BOARD_POSITION = 320;
        private const int BOARD_WIDTH = 10;
        private const int BOARD_HEIGHT = 20;
        private const int MIN_VERTICAL_MARGIN = 20;
        private const int MIN_HORIZONTAL_MARGIN = 20;
        private const int PIECE_BLOCKS = 5;

        public int mPosX, mPosY;
        public int mPiece, mRotation;

        private int mScreenHeight;
        private int mNextPosX, mNextPosY;
        private int mNextPiece, mNextRotation;

        private Board mBoard;
        private Pieces mPieces;
        private IO mIO;
        
        public Game (Board pBoard, Pieces pPieces, IO pIO, int pScreenHeight)
        {
            mScreenHeight = pScreenHeight;

            mBoard = pBoard;
            mPieces = pPieces;
            mIO = pIO;

            InitGame();
        }

        private int GetRand (int pA, int pB)
        {
            Random rnd = new Random();
            return rnd.Next(pA, pB);
        }

        private void InitGame()
        {
            mPiece = GetRand(0, 6);
            mRotation = GetRand(0, 3);
            mPosX = (BOARD_WIDTH / 2) + mPieces.GetYInitialPosition(mPiece, mRotation);
            mPosY = mPieces.GetYInitialPosition(mPiece, mRotation);

            mNextPiece = GetRand(0, 6);
            mNextRotation = GetRand(0, 3);
            mNextPosX = BOARD_WIDTH + 5;
            mNextPosY = 5;
        }

        public void CreateNewPiece()
        {
            mPiece = mNextPiece;
            mRotation = mNextRotation;
            mPosX = (BOARD_WIDTH / 2) + mPieces.GetXInitialPosition(mPiece, mRotation);
            mPosY = mPieces.GetYInitialPosition(mPiece, mRotation);

            mNextPiece = GetRand(0, 6);
            mNextRotation = GetRand(0, 3);
        }

        private void DrawPiece (int pX, int pY, int pPiece, int pRotation)
        {
            int mPixelsX = mBoard.GetXPosInPixels (pX);
            int mPixelsY = mBoard.GetYPosInPixels (pY);

            for (int i = 0; i < PIECE_BLOCKS; i++)
            {
                for (int j = 0; j < PIECE_BLOCKS; j++)
                {
                    if (mPieces.GetBlockType (pPiece, pRotation, j, i) != 0)
                    {
                        mIO.DrawRectangle(mPixelsX + i * BLOCK_SIZE,
                                          mPixelsY + j * BLOCK_SIZE,
                                          (mPixelsX + i * BLOCK_SIZE) + BLOCK_SIZE - 2,
                                          (mPixelsY + j * BLOCK_SIZE) + BLOCK_SIZE - 1,
                                          IO.Color.BLACK);
                    }
                }
            }
        }

        private void DrawBoard()
        {
            int mX1 = BOARD_POSITION - (BLOCK_SIZE * (BOARD_WIDTH / 2)) - 1;
            int mX2 = BOARD_POSITION + (BLOCK_SIZE * (BOARD_WIDTH / 2));
            int mY = mScreenHeight - (BLOCK_SIZE * BOARD_HEIGHT);

            mIO.DrawRectangle(mX1 - BOARD_LINE_WIDTH, mY, mX1, mScreenHeight - 1, IO.Color.BLACK);
            mIO.DrawRectangle(mX2, mY, mX2 + BOARD_LINE_WIDTH, mScreenHeight - 1, IO.Color.BLACK);

            mX1 += 1;
            for (int i = 0; i < BOARD_WIDTH; i++)
            {
                for (int j = 0; j < BOARD_HEIGHT; j++)
                {
                    if (!mBoard.IsFreeBlock(i, j))
                    {
                        mIO.DrawRectangle(mX1 + i * BLOCK_SIZE,
                                          mY + j * BLOCK_SIZE,
                                          (mX1 + i * BLOCK_SIZE) + BLOCK_SIZE - 2,
                                          (mY + j * BLOCK_SIZE) + BLOCK_SIZE - 1,
                                          IO.Color.BLACK);

                    }
                }
            }
        }

        public void DrawScene()
        {
            DrawBoard();
            DrawPiece(mPosX, mPosY, mPiece, mRotation);
            DrawPiece(mNextPosX, mNextPosY, mNextPiece, mNextRotation);
        }
    }
}
