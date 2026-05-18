using TimeCopy.Core;

namespace TimeCopy.Core.Tests;

public class TextAnnouncerTests
{
    [Fact]
    public void WrapAsParagraph_SingleLine_WrapsInParagraphTags()
    {
        var result = TextAnnouncer.WrapAsParagraph("hello");
        Assert.Equal("<p>\nhello\n</p>", result);
    }

    [Fact]
    public void WrapAsParagraph_MultiLine_InsertsBrBeforeEachNewline()
    {
        var input = $"line1{Environment.NewLine}line2{Environment.NewLine}line3";
        var expected = $"<p>\nline1<br/>{Environment.NewLine}line2<br/>{Environment.NewLine}line3\n</p>";
        Assert.Equal(expected, TextAnnouncer.WrapAsParagraph(input));
    }

    [Fact]
    public void WrapAsParagraph_TrimsLeadingAndTrailingWhitespace()
    {
        var result = TextAnnouncer.WrapAsParagraph("   padded   ");
        Assert.Equal("<p>\npadded\n</p>", result);
    }
}
