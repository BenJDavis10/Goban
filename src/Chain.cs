using System;
using System.Collections.Generic;
using System.Text;

namespace Goban.src {
    class Chain : IPositionSet {
        public PositionType Type { get; }
        private ISet<Position> aPositions = new HashSet<Position>();


        /// <summary>
        /// Creates an empty chain of the given type
        /// </summary>
        /// <param name="pType">The type of chain to create</param>
        public Chain(PositionType pType) {
            Type = pType;

        }


        /// <summary>
        /// Creates a new chain from the chains given
        /// </summary>
        /// <param name="pChains">The chains to unify with</param>
        public Chain(params Chain[] pChains) {
            Type = pChains[0].Type;

            foreach (var chain in pChains) {
                if (chain.Type != Type) {
                    throw new InvalidOperationException("Cannot unify chains of different type");

                }

                aPositions.UnionWith(chain.aPositions);

            }
        }


        public bool CanCapture(IPositionSet pTarget) {
            return pTarget.Type != Type;

        }


        /// <summary>
        /// Unifies this chain with the chain given
        /// </summary>
        /// <param name="pOther">The chain to unify with</param>
        public void UnionWith(Chain pOther) {
            aPositions.UnionWith(pOther.aPositions);

        }


        /// <summary>
        /// Finds the set of position sets in the chain's liberties
        /// </summary>
        /// <returns>The set of neighbouring position sets</returns>
        public HashSet<IPositionSet> GetLiberties() {
            var liberties = new HashSet<IPositionSet>();

            foreach (var pos in aPositions) {
                liberties.UnionWith(pos.GetLiberties());

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
