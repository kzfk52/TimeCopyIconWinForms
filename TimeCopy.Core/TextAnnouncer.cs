namespace TimeCopy.Core;

public static class TextAnnouncer
{
    public static string WrapAsParagraph(string source)
    {
        var trimmed = source.Trim();
        var withBreaks = trimmed.Replace(Environment.NewLine, "<br/>" + Environment.NewLine);
        return $"<p>\n{withBreaks}\n</p>";
    }
}
