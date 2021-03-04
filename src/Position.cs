using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Goban.src {
    class Position {
        public static readonly int[][] neighbours = new int[][] { new int[]{-1, 0}, 
                                                                    new int[]{0, -1}, 
                                                                    new int[]{1, 0}, 
                                                                    new int[]{0, 1} };     // Constant representing liberties' relative coordinates
        public int x { get; }       // x, y coords
        public int y { get; }
        private Board aBoard;       // Board this position belongs to

        
        /// <summary>
        /// Creates a new position on the given board, with given coordinates
        /// </summary>
        /// <param name="pBoard">The board the position is to belong to</param>
        /// <param name="pX">x-coord</param>
        /// <param name="pY">y-coord</param>
        public Position(Board pBoard, int pX, int pY) {
            Debug.Assert(pX >= 0 && pY >= 0 && pX <= pBoard.Size + 1 && pY <= pBoard.Size + 1);     // Can only be on the board or its boundaries

            aBoard = pBoard;
            x = pX;
            y = pY;

        }


        /// <summary>
        /// Finds the set of adjacent position sets 
        /// </summary>
        /// <returns>The set of neighbouring position sets</returns>
        public HashSet<IPositionSet> GetAdjacent() {
            var adj = new HashSet<IPositionSet>();

            foreach (var dPos in neighbours) {
                var pos = aBoard.GetPosition(x + dPos[0], y + dPos[1]);

                if (pos != null) {
                    adj.Add(aBoard.GetPositionSet(pos));

                }
            }

            return adj;

        }

    }
}
