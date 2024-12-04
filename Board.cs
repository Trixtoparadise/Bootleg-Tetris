using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootlegTetris;

namespace BootlegTetris
{
    class Board
    {
        private const int BOARD_LINE_WIDTH = 6;
        private const int BLOCK_SIZE = 16;
        private const int BOARD_POSITION = 320;
        private const int BOARD_WIDTH = 10;
        private const int BOARD_HEIGHT = 20;
        private const int MIN_VERTICAL_MARGIN = 20;
        private const int MIN_HORIZONTAL_MARGIN = 20;
        private const int PIECE_BLOCKS = 5;

        private enum Position
        {
            POS_FREE,
            POS_FILLED
        }
        private int[,] mBoard = new int[BOARD_WIDTH, BOARD_HEIGHT];
        private BootlegTetris.Pieces mPieces;
        private int mScreenHeight;

        public Board(BootlegTetris.Pieces pPieces, int pScreenHeight)
        {
            mScreenHeight = pScreenHeight;

            mPieces = pPieces;

            InitBoard();
        }

        private void InitBoard()
        {
            for (int i = 0; i < BOARD_WIDTH; i++)
            {
                for (int j = 0; j < BOARD_HEIGHT; j++)
                {
                    mBoard[i, j] = (int)Position.POS_FREE;
                }
            }
        }

        public void StorePiece(int pX, int pY, int pPiece, int pRotation)
        {
            for (int i1 = pX, i2 = 0; i1 < pX + PIECE_BLOCKS; i1++, i2++)
            {
                for (int j1 = pY, j2 = 0; j1 < pY + PIECE_BLOCKS; j1++, j2++)
                {
                    if (mPieces.GetBlockType(pPiece, pRotation, j2, i2) != 0)
                    {
                        mBoard[i1, j1] = (int)Position.POS_FILLED;
                    }
                }
            }
        }

        public bool IsGameOver()
        {
            for (int i = 0; i < BOARD_WIDTH; i++)
            {
                if (mBoard[i, 0] == (int)Position.POS_FILLED)
                {
                    return true;
                }
            }

            return false;
        }

        private void DeleteLine(int pY)
        {
            for (int j = pY; j > 0; j--)
            {
                for (int i = 0; i < BOARD_WIDTH; i++)
                {
                    mBoard[i, j] = mBoard[i, j - 1];
                }
            }
        }

        public void DeletePossibleLines()
        {
            for (int j = 0; j < BOARD_HEIGHT; j++)
            {
                int i = 0;
                while (i < BOARD_WIDTH)
                {
                    if (mBoard[i, j] != (int)Position.POS_FILLED)
                    {
                        break;
                    }
                    i++;
                }

                if (i == BOARD_WIDTH)
                {
                    DeleteLine(j);
                }
            }
        }

        public bool IsFreeBlock(int pX, int pY)
        {
            if (mBoard[pX, pY] == (int)Position.POS_FREE)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public int GetXPosInPixels(int pPos)
        {
            return ((BOARD_POSITION - (BLOCK_SIZE * (BOARD_WIDTH / 2))) + (pPos * BLOCK_SIZE));
        }

        public int GetYPosInPixels(int pPos)
        {
            return ((mScreenHeight - (BLOCK_SIZE * BOARD_HEIGHT)) + (pPos * BLOCK_SIZE));
        }

        public bool IsPossibleMovement(int pX, int pY, int pPiece, int pRotation)
        {
            for (int i1 = pX, i2 = 0; i1 < pX + PIECE_BLOCKS; i1++, i2++)
            {
                for (int j1 = pY, j2 = 0; j1 < pY + PIECE_BLOCKS; j1++, j2++)
                {
                    if (i1 < 0 || i1 > BOARD_WIDTH - 1 || j1 > BOARD_HEIGHT - 1)
                    {
                        if (mPieces.GetBlockType(pPiece, pRotation, j2, i2) != 0)
                        {
                            return false;
                        }
                    }

                    if (j1 >= 0)
                    {
                        if ((mPieces.GetBlockType(pPiece, pRotation, j2, i2) != 0) && (!IsFreeBlock(i1, j1)))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
