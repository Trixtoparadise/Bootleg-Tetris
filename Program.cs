using SDL2;
using System;
using BootlegTetris;
    
int main ()
{
    IO mIO = new IO ();
    int mScreenHeight = mIO.GetScreenHeight();

    Pieces mPieces = new Pieces ();
    Board mBoard = new Board(mPieces, mScreenHeight);
    Game mGame = new Game(mBoard, mPieces, mIO, mScreenHeight);

    UInt64 mTime1 = SDL.SDL_GetTicks();

    while (mIO.IsKeyDown((int) SDL.SDL_Keycode.SDLK_ESCAPE) != 1)
    {
        mIO.ClearScreen();
        mGame.DrawScene();
        mIO.UpdateScreen();

        int mKey = mIO.Pollkey();

        switch (mKey)
        {
            case ((int)SDL.SDL_Keycode.SDLK_RIGHT):
            {
                if (mBoard.IsPossibleMovement(mGame.mPosX + 1, mGame.mPosY, mGame.mPiece, mGame.mRotation))
                {
                    mGame.mPosX++;
                }
                break;
            }

            case ((int)SDL.SDL_Keycode.SDLK_LEFT):
            {
                if (mBoard.IsPossibleMovement(mGame.mPosX - 1, mGame.mPosY, mGame.mPiece, mGame.mRotation))
                {
                    mGame.mPosX--;
                }
                break;
            }

            case ((int)SDL.SDL_Keycode.SDLK_DOWN):
            {
                if (mBoard.IsPossibleMovement (mGame.mPosX, mGame.mPosY + 1, mGame.mPiece, mGame.mRotation))
                {
                    mGame.mPosY++;
                }
                    break;
            }

            case ((int)SDL.SDL_Keycode.SDLK_z):
            {
                if (mBoard.IsPossibleMovement (mGame.mPosX, mGame.mPosY, mGame.mPiece, (mGame.mRotation + 1) % 4))
                {
                        mGame.mRotation = (mGame.mRotation + 1) % 4;
                }

                break;
            }
        }

        UInt64 mTime2 = SDL.SDL_GetTicks();

        if ((mTime2 - mTime1) > 700)
        {
            if (mBoard.IsPossibleMovement (mGame.mPosX, mGame.mPosY + 1, mGame.mPiece, mGame.mRotation))
            {
                mGame.mPosY++;
            }
            else
            {
                mBoard.StorePiece(mGame.mPosX, mGame.mPosY, mGame.mPiece, mGame.mRotation);

                mBoard.DeletePossibleLines();

                if (mBoard.IsGameOver())
                {
                    mIO.Getkey();
                    //exit(0);
                }

                mGame.CreateNewPiece();
            }

            mTime1 = SDL.SDL_GetTicks();
        }
    }

    return 0;
}

main();

