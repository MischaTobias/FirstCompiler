using System;
using System.Collections.Generic;
using System.Text;

namespace Lab02_MischaTobias_1170919
{
    public class Parser
    {
        Scanner _scanner;
        Token _token;

        private void TP()
        {
            switch (_token.Tag)
            {
                case TokenType.LParen:
                case TokenType.Empty:
                case TokenType.Null:
                case TokenType.Symbol:
                    F();
                    TP();
                    break;
                default:
                    break;
            }
        }

        private void T()
        {
            TP();
        }

        private void FP()
        {
            switch (_token.Tag)
            {
                case TokenType.Plus:
                case TokenType.Star:
                case TokenType.Optional:
                    Match(_token.Tag);
                    FP();
                    break;
                default:
                    break;
            }
        }

        private void F()
        {
            switch (_token.Tag)
            {
                case TokenType.LParen:
                    Match(TokenType.LParen);
                    E();
                    Match(TokenType.RParen);
                    FP();
                    break;

                case TokenType.Symbol:
                case TokenType.Null:
                case TokenType.Empty:
                    Match(_token.Tag);
                    FP();
                    break;
                default:
                    break;
            }
        }

        private void EP()
        {
            switch (_token.Tag)
            {
                case TokenType.Union:
                    Match(TokenType.Union);
                    T();
                    EP();
                    break;
                default:
                    break;
            }
        }

        private void E()
        {
            switch (_token.Tag)
            {
                case TokenType.LParen:
                case TokenType.Empty:
                case TokenType.Null:
                case TokenType.Symbol:
                    T();
                    EP();
                    break;
                default:
                    break;
            }
        }

        private void Match(TokenType tag)
        {
            if (_token.Tag == tag)
            {
                _token = _scanner.GetToken();
            }
            else
            {
                throw new Exception("Error de Sintaxis");
            }
        }
        
        public void Parse(string regexp)
        {
            _scanner = new Scanner(regexp + (char)TokenType.EOF);
            _token = _scanner.GetToken();
            switch (_token.Tag)
            { 
                case TokenType.LParen:
                case TokenType.Empty:
                case TokenType.Null:
                case TokenType.Symbol:
                    E();
                    break;
                default:
                    break;
            }
            Match(TokenType.EOF);
        } // PARSE

    } //PARSER
}
