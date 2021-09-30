using System;
using System.Collections.Generic;
using System.Text;

namespace Lab02_MischaTobias_1170919
{
    public enum TokenType
    {
        Plus = '+',
        Star = '*',
        Union = '|',
        Optional = '?',
        LParen = '(',
        RParen = ')',
        EOF = (char)0,
        Empty = (char)1,
        Null = (char)2,
        Symbol = (char)3
    }
}
