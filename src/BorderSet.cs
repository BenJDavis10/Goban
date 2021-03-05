using System;
using System.Collections.Generic;
using System.Text;

namespace Goban.src {
    /// <summary>
    /// Represents the set of positions along the border (not part of playable area of board)
    /// </summary>
    class BorderSet : PositionSet {
        public override PositionType Type { 
            get {
                return PositionType.Border;
            }   
        }


        public new void Add(Position pPos) {
            throw new InvalidOperationException("Cannot modify Border Set after creation");

        }


        public new void Remove(Position pPos) {
            throw new InvalidOperationException("Cannot modify Border Set after creation");

        }


        public override bool CanCapture(IPositionSet pTarget) {
            return true;

        }
    }
}
