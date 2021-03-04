using System;
using System.Collections.Generic;
using System.Text;

namespace Goban.src {
    class SpaceSet : IPositionSet {
        public PositionType Type { get; } = PositionType.Empty;
        private ISet<Position> aPositions = new HashSet<Position>();

        public SpaceSet(ISet<Position> pPositions) {
            aPositions.UnionWith(pPositions);

        }

        public bool CanCapture(IPositionSet pTarget) {
            return false;

        }
    }
}
