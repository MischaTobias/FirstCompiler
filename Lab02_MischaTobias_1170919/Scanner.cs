using System;
using System.Collections.Generic;
using System.Text;

namespace Lab02_MischaTobias_1170919
{
    public class Scanner
    {
        private string _regexp = "";
        private int _index = 0;
        private int _state = 0;

        public Scanner(string regexp)
        {
            _regexp = regexp + (char)TokenType.EOF;
            _index = 0;
            _state = 0;
        }

        public Token GetToken()
        {
            Token result = new Token() { Value = (char)0 };
            bool tokenFound = false;
            while (!tokenFound)
            {
                char peek = _regexp[_index];
                switch (_state)
                {
                    case 0:

                        // Whitespace removal
                        while (char.IsWhiteSpace(peek))
                        {
                            _index++;
                            peek = _regexp[_index];
                        }

                        switch (peek)
                        {
                            case '\\':
                                _state = 1;
                                break;
                            case (char)TokenType.LParen:
                            case (char)TokenType.RParen:
                            case (char)TokenType.Optional:
                            case (char)TokenType.Plus:
                            case (char)TokenType.Star:
                            case (char)TokenType.Union:
                            case (char)TokenType.EOF:
                                tokenFound = true;
                                result.Tag = (TokenType)peek;
                                break;

                            default:
                                tokenFound = true;
                                result.Tag = TokenType.Symbol;
                                result.Value = peek;
                                break;
                        } // SWITCH - peek
                        break; // CASE state0

                    case 1:
                        switch (peek)
                        {
                            case (char)TokenType.LParen:
                            case (char)TokenType.RParen:
                            case (char)TokenType.Optional:
                            case (char)TokenType.Plus:
                            case (char)TokenType.Star:
                            case (char)TokenType.Union:
                            case '\\':
                            case ' ':
                                tokenFound = true;
                                result.Tag = TokenType.Symbol;
                                result.Value = peek;
                                break;

                            case 'E':
                                tokenFound = true;
                                result.Tag = TokenType.Null;
                                break;
                            case '0':
                                tokenFound = true;
                                result.Tag = TokenType.Empty;
                                break;

                            default:
                                throw new Exception("Lex Error");
                        }
                        break;

                    default:
                        break;
                } // SWITCH - state

                _index++;
            } // WHILE - tokenFound

            _state = 0;
            return result;
        } //GetToken
    }
}
