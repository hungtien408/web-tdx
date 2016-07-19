using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for FCKEditorFix
/// </summary>
public class FCKEditorFix
{
    public static string Fix(string input)
    {
        string sPartern = @"\<!--\[if gte((.|\n)*)endif\]--\>";

        if (Regex.IsMatch(input, sPartern))
            input = Regex.Replace(input, sPartern, "");

        return input;
    }
}