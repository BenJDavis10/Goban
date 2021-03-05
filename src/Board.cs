using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace Goban.src {
    /// <summary>
    /// Represents a Go board (Goban)
    /// </summary>
    class Board {
        /// <summary> Positions on the board </summary>
        private readonly Position[,] aPositions;
        /// <summary> Position sets on the board </summary>
        private readonly ISet<IPositionSet> aPositionSets = new HashSet<IPositionSet>();
        /// <summary> Dimensions of the playable area of the board </summary>
        public int Size { get; }


        /// <summary>
        /// Creates a new board of the given size
        /// </summary>
        /// <param name="pSize">The desired width/height (both same) of the board</param>
        public Board(int pSize) {
            Size = pSize;
            aPositions = new Position[Size, Size];
            var spaces = new SpaceSet();
            var border = new BorderSet();

            for (int x = 0; x <= Size + 1; x++) {
                for (int y = 0; y <= Size + 1; y++) {
                    var pos = new Position(this, x, y);
                    aPositions[x, y] = pos;

                    if (x == 0 || y == 0 || x == Size + 1 || y == Size + 1) {       // On border, so add to border set
                        border.Add(pos);

                    } else {        // Initially, all non-border positions are empty, so add to space set
                        spaces.Add(pos);
                    
                    }
                }
            }

            aPositionSets.Add(spaces);
            aPositionSets.Add(border);

        }


        /// <summary>
        /// Gets the position at the given coords
        /// </summary>
        /// <param name="pX">x-coord</param>
        /// <param name="pY">y-coord</param>
        /// <returns></returns>
        public Position GetPosition(int pX, int pY) {
            return aPositions[pX, pY];

        }


        /// <summary>
        /// Gets the position set the given position belongs to
        /// </summary>
        /// <param name="pPos">The position for which to find the containing set</param>
        /// <returns></returns>
        public IPositionSet GetPositionSet(Position pPos) {
            foreach (var set in aPositionSets) {
                if (set.Contains(pPos)) {
                    return set;

                }
            }

            throw new InvalidOperationException("Can only get position set of positions on this board.");   // If in none, since all positions on the board are in a set, the position must not be on this board

        }

        
        /// <summary>
        /// Attempts to place a stone of the given colour at the given coords
        /// </summary>
        /// <param name="pType">Stone type/colour. Black or White only</param>
        /// <param name="pX">x-coord</param>
        /// <param name="pY">y-coord</param>
        public void Play(PositionType pType, int pX, int pY) {
            Debug.Assert(pType == PositionType.Black || pType == PositionType.White);
            Debug.Assert(pX > 0 && pY > 0 && pX <= Size && pY <= Size);

            var pos = GetPosition(pX, pY);
            var oldSet = GetPositionSet(pos);

            if (oldSet.Type != PositionType.Empty) {
                throw new InvalidOperationException("Cannot play on a non-empty position");

            }

            oldSet.Remove(pos);     // Move position from the old set to a new chain
            var chain = new Chain(pType);
            chain.Add(pos);

            aPositionSets.Add(chain);
            foreach (var set in pos.GetAdjacent()) {
                if (set.Type == pType) {                // If any neighbouring sets are chains of the same colour, unify with them
                    aPositionSets.Remove(set);
                    chain.UnionWith((Chain) set);       // Cast is safe, since pType can only be Black or White

                }
            }
        }

    }
}
