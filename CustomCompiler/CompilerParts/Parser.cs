using System;
using System.Collections.Generic;
using System.Text;

namespace CustomCompiler
{
    public class Parser
    {
        Scanner _scanner;
        Token _token;

        public double Parse(string regexp)
        {
            _scanner = new Scanner(regexp + (char)TokenType.EOF);
            _token = _scanner.GetToken();

            var result = 0.00;
            switch (_token.Tag)
            {
                case TokenType.Minus:
                case TokenType.LParen:
                case TokenType.Digit:
                    result = E();
                    break;
                default:
                    break;
            }
            Match(TokenType.EOF);
            return result;
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

        private double E()
        {
            switch (_token.Tag)
            {
                case TokenType.Minus:
                case TokenType.LParen:
                case TokenType.Digit:
                    return T() + EP();
                default:
                    throw new Exception("Error de Sintaxis");
            }
        }

        private double EP()
        {
            switch (_token.Tag)
            {
                case TokenType.Plus:
                    Match(TokenType.Plus);
                    return T() + EP();
                case TokenType.Minus:
                    Match(TokenType.Minus);
                    return -T() + EP();
                default:
                    return 0;
            }
        }

        private double T()
        {
            switch (_token.Tag)
            {
                case TokenType.Minus:
                case TokenType.LParen:
                case TokenType.Digit:
                    return F() * TP();
                default:
                    throw new Exception("Error de Sintaxis");
            }
        }

        private double TP()
        {
            switch (_token.Tag)
            {
                case TokenType.Multiplication:
                    Match(TokenType.Multiplication);
                    return F() * TP();
                case TokenType.Division:
                    Match(TokenType.Division);
                    return 1 / F() * TP();
                default:
                    return 1;
            }
        }

        private double F()
        {
            switch (_token.Tag)
            {
                case TokenType.Minus:
                    Match(TokenType.Minus);
                    return -F();
                case TokenType.LParen:
                case TokenType.Digit:
                    return G();
                default:
                    throw new Exception("Error de Sintaxis");
            }
        }

        private double G()
        {
            switch (_token.Tag)
            {
                case TokenType.LParen:
                    Match(TokenType.LParen);
                    var result = E();
                    Match(TokenType.RParen);
                    return result;
                case TokenType.Digit:
                    return Convert.ToInt32(GetNumber());
                default:
                    throw new Exception("Error de Sintaxis");
            }
        }

        private string H()
        {
            switch (_token.Tag)
            {
                case TokenType.Digit:
                    return GetNumber();
                default:
                    return "";
            }
        }

        private string GetNumber()
        {
            var tokenValue = new string(_token.Value, 1);
            Match(TokenType.Digit);
            var num = H();
            return tokenValue + num;
        }
    }
}
