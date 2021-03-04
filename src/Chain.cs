using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Goban.src {
    class Chain : PositionSet {
        public new PositionType Type { get; }


        /// <summary>
        /// Creates an empty chain of the given type
        /// </summary>
        /// <param name="pType">The type of chain to create</param>
        public Chain(PositionType pType) {
            Debug.Assert(pType == PositionType.Black || pType == PositionType.White);   // Type must be a stone colour

            Type = pType;

        }


        public override bool CanCapture(IPositionSet pTarget) {
            return pTarget.Type != Type;

        }


        /// <summary>
        /// Unifies this chain with the chain given
        /// </summary>
        /// <param name="pOther">The chain to unify with</param>
        public void UnionWith(Chain pOther) {
            base.AddAll(pOther.Positions);

        }


        /// <summary>
        /// Finds the set of position sets in the chain's liberties
        /// </summary>
        /// <returns>The set of neighbouring position sets</returns>
        public HashSet<IPositionSet> GetLiberties() {
            var liberties = new HashSet<IPositionSet>();

            foreach (var pos in Positions) {
                liberties.UnionWith(pos.GetAdjacent());

            }

            return liberties;

        }


        /// <summary>
        /// Determines whether this chain is surrounded and should be removed as a capture
        /// </summary>
        /// <returns>true if surrounded, false otherwise</returns>
        public bool IsSurrounded() {

            foreach (var set in GetLiberties()) {       // If any sets in the chain's liberties are unable to capture, we are not surrounded
                if (!set.CanCapture(this)) {
                    return false;

                }
            }

            return true;        // All sets in liberties are able to capture; we are surrounded

        }
    }
}
