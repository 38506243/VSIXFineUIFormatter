using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FineUICoder
{
    public class FineUI_cshtml
    {
        string spaceMark = "    ";
        public string Format(string text)
        {
            if (string.IsNullOrEmpty(text))
                return "";
            string[] sources = text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            string[] lines = Format(sources);
            string result = lines[0];
            for(int i = 1; i < lines.Length; i++)
            {
                result += "\r\n" + lines[i];
            }
            return result;
        }
        public string[] Format(string[] lines)
        {
            string[] result = new string[lines.Length];
            SpaceParam spBase = new SpaceParam();
            for (int i = 0; i < lines.Length; i++)
            {
                SpaceParam sp = new SpaceParam();
                string line = CheckLine(lines[i], sp);
                spBase.Razor += sp.Razor;
                int backcount = 0;
                if (spBase.MemoLeft > 0 && sp.MemoRight > 0 && sp.FirstMemo) backcount--;
                if (spBase.MemoLeft == 0 && sp.ParenthesisRight > 0 && sp.FirstParenthesis) backcount--;

                result[i] = GetSpaces(spBase.Razor + spBase.ParenthesisLeft + spBase.MemoLeft + backcount) + line;

                if (spBase.MemoLeft == 0)
                {
                    spBase.MemoLeft += sp.MemoLeft;
                    spBase.ParenthesisLeft += sp.ParenthesisLeft;
                    spBase.ParenthesisLeft -= sp.ParenthesisRight;
                }
                spBase.MemoLeft -= sp.MemoRight;
            }
            return result;
        }
        string GetSpaces(int spaceCount) {
            if (spaceCount < 0)
                return "";
            else
            {
                string result = "";
                for (int i = 0; i < spaceCount; i++)
                {
                    result += spaceMark;
                    if (i >= 10)
                        break;
                }
                return result;
            }
        }
        string CheckLine(string source, SpaceParam sp)
        {
            string txt = source.Trim();

            txt = txt.Replace("\\\"", "");//移除引号转义

            txt = DelString(txt);

            int n;
            n = txt.IndexOf("//");
            if (n > -1)
                txt = txt.Substring(0, n);

            txt = Delstring2(txt);
            txt = Delstring3(txt);

            sp.MemoLeft = GetSubCount(txt, "/*");
            sp.MemoRight = GetSubCount(txt, "*/");

            sp.Razor = GetSubCount(txt, "@(");
            txt = txt.Replace("@(", "");
            sp.ParenthesisLeft = GetSubCount(txt, "(");
            sp.ParenthesisRight = GetSubCount(txt, ")");
            if (sp.ParenthesisRight > 0 && txt.Length > 0 && txt.Substring(0, 1) == ")")
                sp.FirstParenthesis = true;
            if (sp.MemoRight > 0 && txt.Length > 1 && txt.Substring(0,2) == "*/")
                sp.FirstMemo = true;

            return source.TrimStart(' ');
        }
        int GetSubCount(string source,string sub)
        {
            if (string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(sub))
                return 0;
            if (source.Contains(sub))
            {
                string s2 = source.Replace(sub, "");
                return (source.Length - s2.Length) / sub.Length;
            }

            return 0;
        }
        string Delstring2(string source)
        {
            if (string.IsNullOrEmpty(source))
                return source;
            MatchCollection mc = regMemo.Matches(source);
            if (mc.Count == 0)
                return source;

            Match m = mc[mc.Count - 1];
            string result = source.Remove(m.Index - 2, m.Length + 4);
            for(int i = mc.Count - 2; i >= 0; i--)
            {
                result = result.Remove(m.Index - 2, m.Length + 4);
            }
            return result;
        }
        string Delstring3(string source)
        {
            if (string.IsNullOrEmpty(source))
                return source;
            MatchCollection mc = regParentheses.Matches(source);
            if (mc.Count == 0)
                return source;

            Match m = mc[mc.Count - 1];
            string result = source.Remove(m.Index, m.Length);
            for (int i = mc.Count - 2; i >= 0; i--)
            {
                result = result.Remove(mc[i].Index, mc[i].Length);
            }
            return result;
        }
        string DelString(string source)
        {
            if (string.IsNullOrEmpty(source))
                return source;
            string[] lines = source.Split('"');
            string result = "";
            for(int i = 0; i < lines.Length; i++)
            {
                if (i % 2 == 0)
                {
                    result += lines[i];
                }
            }
            return result;
        }
        Regex regMemo = new Regex(@"(?<=/\*)((?:(?!/\*).)*?)(?=\*/)");
        Regex regParentheses = new Regex(@"\([^\(\)]*\)");
        public class SpaceParam
        {
            int _Razor = 0;

            public int Razor
            {
                get { return _Razor; }
                set
                {
                    _Razor = value;
                    if (_Razor < 0)
                        _Razor = 0;
                }
            }

            public int MemoLeft = 0;
            public int MemoRight = 0;
            public int ParenthesisLeft = 0;
            public int ParenthesisRight = 0;

            public bool FirstMemo = false;
            public bool FirstParenthesis = false;
            public override string ToString()
            {
                return string.Format("R={0},ML={1},MR={2},PL={3},PR={4}", this.Razor, this.MemoLeft, this.MemoRight, this.ParenthesisLeft, this.ParenthesisRight);
                //return base.ToString();
            }
        }
    }
}
