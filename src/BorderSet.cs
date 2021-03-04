using System;
using System.Collections.Generic;
using System.Text;

namespace Goban.src {
    class BorderSet : PositionSet {
        public new PositionType Type { 
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
