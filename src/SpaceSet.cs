using System;
using System.Collections.Generic;
using System.Text;

namespace Goban.src {
    class SpaceSet : PositionSet {
        public new PositionType Type {
            get {
                return PositionType.Empty;

            }
        }


        public override bool CanCapture(IPositionSet pTarget) {
            return false;

        }
    }
}
