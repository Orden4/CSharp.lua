﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLua.LuaAst {
    public sealed class LuaInvocationExpressionSyntax : LuaExpressionSyntax {
        public LuaArgumentListSyntax ArgumentList { get; } = new LuaArgumentListSyntax();
        public LuaExpressionSyntax Expression { get; set;  }

        internal override void Render(LuaRenderer renderer) {
            renderer.Render(this);
        }
    }
}
