using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BootlegTetris
{
    class IO
    {
        static IntPtr window = SDL.SDL_CreateWindow(
            "Tetris .NET Prototype",
            SDL.SDL_WINDOWPOS_UNDEFINED,
            SDL.SDL_WINDOWPOS_UNDEFINED,
            648,
            324,
            SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
        
        static IntPtr renderer = SDL.SDL_CreateRenderer(
            window,
            -1,
            SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED |
            SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC);

        public enum Color
        {
            BLACK,
            RED,
            GREEN,
            BLUE,
            CYAN,
            MAGENTA,
            YELLOW,
            WHITE,
            COLOR_MAX
        }

        static UInt32[] mColors = new UInt32[(int)Color.COLOR_MAX]
                                    {
                                        4278190080u,
                                        4294901760u,
                                        4278222848u,
                                        4278190335u,
                                        4278255615u,
                                        4294902015u,
                                        4294967040u,
                                        4294967295u
                                    };

        public IO()
        {
            Initgraph();
        }
        
        public void ClearScreen()
        {
            SDL_gfx.boxColor(renderer, 0, 0, 702, 324, mColors[(int) Color.WHITE]);
        }

        public void DrawRectangle(int pX1, int pY1, int pX2, int pY2, Color pC)
        {
            SDL_gfx.boxColor(renderer, Convert.ToInt16(pX1), Convert.ToInt16(pY1), Convert.ToInt16(pX2), Convert.ToInt16(pY2 - 1), mColors[(int)pC]);
        }

        public int GetScreenHeight()
        {
            return 324;
        }

        public void UpdateScreen()
        {
            SDL.SDL_RenderPresent(renderer);
        }

        public int Pollkey()
        {
            SDL.SDL_Event _event;
            while (SDL.SDL_PollEvent(out _event) == 1)
            {
                switch (_event.type)
                {
                    case SDL.SDL_EventType.SDL_KEYDOWN:
                        return (int) _event.key.keysym.sym;
                    case SDL.SDL_EventType.SDL_QUIT:
                        return 0;

                }
            }
            return -1;
        }

        public int Getkey()
        {
            SDL.SDL_Event _event;
            while (true)
            {
                SDL.SDL_WaitEvent(out _event);
                
                if (_event.type == SDL.SDL_EventType.SDL_KEYDOWN)
                {
                    break;
                }

                if (_event.type == SDL.SDL_EventType.SDL_QUIT)
                {
                    return 0;
                }
            }
            return (int) _event.key.keysym.sym;
        }

        public unsafe int IsKeyDown(int pKey)
        {
            byte* mKeytable;
            int mNumkeys = new int();
            SDL.SDL_PumpEvents();
            mKeytable = (byte*) SDL.SDL_GetKeyboardState(out mNumkeys);
            return mKeytable[pKey];
        }

        public int Initgraph()
        {
            if ( SDL.SDL_Init(SDL.SDL_INIT_VIDEO) < 0 )
            {
                Console.WriteLine($"There was an issue initializing SDL. {SDL.SDL_GetError()}");
                return 1;
            }

            if (window == IntPtr.Zero)
            {
                Console.WriteLine($"There was an issue creating the window. {SDL.SDL_GetError()}");
            }

            if (renderer == IntPtr.Zero)
            {
                Console.WriteLine($"There was an issue creating the renderer. {SDL.SDL_GetError()}");
            }

            return 0;
        }
    }
}
