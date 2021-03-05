using System;
using System.Collections.Generic;
using System.Text;

namespace Goban.src {
    /// <summary>
    /// Represents a set of positions with shared properties
    /// </summary>
    abstract class PositionSet : IPositionSet {
        /// <summary> The positions contained in this set </summary>
        private ISet<Position> aPositions = new HashSet<Position>();
        /// <summary> The type of positions this set contains </summary>
        public abstract PositionType Type { get; }

        /// <summary> The positions contained in this set </summary>
        public ISet<Position> Positions {
            get {
                var newSet = new HashSet<Position>();
                newSet.UnionWith(aPositions);
                return newSet;

            }
        }


        public void Add(Position pPos) {
            aPositions.Add(pPos);

        }


        public void AddAll(ISet<Position> pPositions) {
            aPositions.UnionWith(pPositions);

        }


        public void Remove(Position pPos) {
            aPositions.Remove(pPos);

        }


        public bool Contains(Position pPos) {
            return aPositions.Contains(pPos);

        }


        public abstract bool CanCapture(IPositionSet pTarget);

    }
}
