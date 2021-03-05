using System;
using System.Collections.Generic;
using System.Text;

namespace Goban.src {

    /// <summary>
    /// Represents a set of empty positions
    /// </summary>
    class SpaceSet : PositionSet {
        public override PositionType Type {
            get {
                return PositionType.Empty;

            }
        }


        public override bool CanCapture(IPositionSet pTarget) {
            return false;

        }
    }
}
