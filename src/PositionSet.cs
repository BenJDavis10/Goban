using System;
using System.Collections.Generic;
using System.Text;

namespace Goban.src {
    abstract class PositionSet : IPositionSet {
        private ISet<Position> aPositions = new HashSet<Position>();
        public PositionType Type { get; }


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
