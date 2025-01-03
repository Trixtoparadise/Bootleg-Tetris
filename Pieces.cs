﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootlegTetris
{
    class Pieces
    {
        int[,,,] mPieces = new int[7, 4, 5, 5]
            {
                {
                    {
                        {0,0,0,0,0},
                        {0,0,0,0,0},
                        {0,0,2,1,0},
                        {0,0,1,1,0},
                        {0,0,0,0,0}
                    },
                    {
                        {0,0,0,0,0},
                        {0,0,0,0,0},
                        {0,0,2,1,0},
                        {0,0,1,1,0},
                        {0,0,0,0,0}
                    },
                    {
                        {0,0,0,0,0},
                        {0,0,0,0,0},
                        {0,0,2,1,0},
                        {0,0,1,1,0},
                        {0,0,0,0,0}
                    },
                    {
                        {0,0,0,0,0},
                        {0,0,0,0,0},
                        {0,0,2,1,0},
                        {0,0,1,1,0},
                        {0,0,0,0,0}
                    }
                },
                {
                    {
                        {0,0,0,0,0},
                        {0,0,0,0,0},
                        {0,1,2,1,1},
                        {0,0,0,0,0},
                        {0,0,0,0,0}
                    },
                    {
                        {0,0,0,0,0},
                        {0,0,1,0,0},
                        {0,0,2,0,0},
                        {0,0,1,0,0},
                        {0,0,1,0,0}
                    },
                    {
                        {0,0,0,0,0},
                        {0,0,0,0,0},
                        {1,1,2,1,0},
                        {0,0,0,0,0},
                        {0,0,0,0,0}
                    },
                    {
                        {0,0,1,0,0},
                        {0,0,1,0,0},
                        {0,0,2,0,0},
                        {0,0,1,0,0},
                        {0,0,0,0,0}
                    }
                },
                {
                    {
                        {0,0,0,0,0},
                        {0,0,1,0,0},
                        {0,0,2,0,0},
                        {0,0,1,1,0},
                        {0,0,0,0,0}
                    },
                    {
                        {0,0,0,0,0},
                        {0,0,0,0,0},
                        {0,1,2,1,0},
                        {0,1,0,0,0},
                        {0,0,0,0,0}
                    },
                    {
                        {0,0,0,0,0},
                        {0,1,1,0,0},
                        {0,0,2,0,0},
                        {0,0,1,0,0},
                        {0,0,0,0,0}
                    },
                    {
                        {0,0,0,0,0},
                        {0,0,0,1,0},
                        {0,1,2,1,0},
                        {0,0,0,0,0},
                        {0,0,0,0,0}
                    }
                },
                {
                    {
                        {0,0,0,0,0},
                        {0,0,1,0,0},
                        {0,0,2,0,0},
                        {0,1,1,0,0},
                        {0,0,0,0,0}
                    },
                    {
                        {0,0,0,0,0},
                        {0,1,0,0,0},
                        {0,1,2,1,0},
                        {0,0,0,0,0},
                        {0,0,0,0,0}
                    },
                    {
                        {0,0,0,0,0},
                        {0,0,1,1,0},
                        {0,0,2,0,0},
                        {0,0,1,0,0},
                        {0,0,0,0,0}
                    },
                    {
                        {0,0,0,0,0},
                        {0,0,0,0,0},
                        {0,1,2,1,0},
                        {0,0,0,1,0},
                        {0,0,0,0,0}
                    }
                },
                {
                    {
                        {0,0,0,0,0},
                        {0,0,0,1,0},
                        {0,0,2,1,0},
                        {0,0,1,0,0},
                        {0,0,0,0,0}
                    },
                    {
                        {0,0,0,0,0},
                        {0,0,0,0,0},
                        {0,1,2,0,0},
                        {0,0,1,1,0},
                        {0,0,0,0,0}
                    },
                    {
                        {0,0,0,0,0},
                        {0,0,1,0,0},
                        {0,1,2,0,0},
                        {0,1,0,0,0},
                        {0,0,0,0,0}
                    },
                    {
                        {0,0,0,0,0},
                        {0,1,1,0,0},
                        {0,0,2,1,0},
                        {0,0,0,0,0},
                        {0,0,0,0,0}
                    }
                },
                {
                    {
                        {0,0,0,0,0},
                        {0,0,1,0,0},
                        {0,0,2,1,0},
                        {0,0,0,1,0},
                        {0,0,0,0,0}
                    },
                    {
                        {0,0,0,0,0},
                        {0,0,0,0,0},
                        {0,0,2,1,0},
                        {0,1,1,0,0},
                        {0,0,0,0,0}
                    },
                    {
                        {0,0,0,0,0},
                        {0,1,0,0,0},
                        {0,1,2,0,0},
                        {0,0,1,0,0},
                        {0,0,0,0,0}
                    },
                    {
                        {0,0,0,0,0},
                        {0,0,1,1,0},
                        {0,1,2,0,0},
                        {0,0,0,0,0},
                        {0,0,0,0,0}
                    }
                },
                {
                    {
                        {0,0,0,0,0},
                        {0,0,0,0,0},
                        {0,0,2,1,0},
                        {0,0,1,1,0},
                        {0,0,0,0,0}
                    },
                    {
                        {0,0,0,0,0},
                        {0,0,1,0,0},
                        {0,0,2,1,0},
                        {0,0,1,0,0},
                        {0,0,0,0,0}
                    },
                    {
                        {0,0,0,0,0},
                        {0,0,1,0,0},
                        {0,1,2,0,0},
                        {0,0,1,0,0},
                        {0,0,0,0,0}
                    },
                    {
                        {0,0,0,0,0},
                        {0,0,1,0,0},
                        {0,1,2,1,0},
                        {0,0,0,0,0},
                        {0,0,0,0,0}
                    }
                }
            };

        int[,,] mPiecesInitialPosition = new int[7, 4, 2]
            {
                {
                    {-2, -3},
                    {-2, -3},
                    {-2, -3},
                    {-2, -3}
                },
                {
                    {-2, -2},
                    {-2, -3},
                    {-2, -2},
                    {-2, -3}
                },
                {
                    {-2, -3},
                    {-2, -3},
                    {-2, -3},
                    {-2, -2}
                },
                {
                    {-2, -3},
                    {-2, -2},
                    {-2, -3},
                    {-2, -3}
                },
                {
                    {-2, -3},
                    {-2, -3},
                    {-2, -3},
                    {-2, -2}
                },
                {
                    {-2, -3},
                    {-2, -3},
                    {-2, -3},
                    {-2, -2}
                },
                {
                    {-2, -3},
                    {-2, -3},
                    {-2, -3},
                    {-2, -2}
                }
            };

        public int GetBlockType(int pPiece, int pRotation, int pX, int pY)
        {
            return mPieces[pPiece, pRotation, pX, pY];
        }

        public int GetXInitialPosition(int pPiece, int pRotation)
        {
            return mPiecesInitialPosition[pPiece, pRotation, 0];
        }

        public int GetYInitialPosition(int pPiece, int pRotation)
        {
            return mPiecesInitialPosition[pPiece, pRotation, 1];
        }
    }
}
