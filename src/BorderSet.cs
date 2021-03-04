using System;
using System.Collections.Generic;
using System.Text;

namespace Goban.src {
    class BorderSet : IPositionSet {
        public PositionType Type { get; }
        private ISet<Position> aPositions = new HashSet<Position>();


        public BorderSet(ISet<Position> pPositions) {
            aPositions.UnionWith(pPositions);

        }


        public bool CanCapture(IPositionSet pTarget) {
            return true;

        }
    }
}
