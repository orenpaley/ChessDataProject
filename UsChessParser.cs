using HtmlAgilityPack;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

class UsChessParser
{
    public static string memberHomePage = "https://www.uschess.org/msa/MbrDtlMain.php?";
    public required string memberId;

    public UsChessParser(string id)
    {
        memberId = id;
    }
	public HtmlDocument GetMemberHomePage(string memberId)
	{

        HtmlWeb web = new HtmlWeb();
        HtmlDocument htmlDoc = web.Load(memberHomePage + memberId);
        return htmlDoc;
    }
    public HtmlNodeCollection GetValues(string memberId)
	{
        var doc = GetMemberHomePage(memberId);
        return doc.DocumentNode.SelectNodes("//b");
	}
    public static string GetRegularRating(HtmlNodeCollection values)
    {
        string regularRatingRaw = values[2].ChildNodes[0].InnerHtml;
        Regex ratingRegex = new Regex("([0-9]{3,4})");
        string regularRatingBeforeRegex = "";

        foreach (char c in regularRatingRaw)
        {
            if (c.Equals('&'))
            {
                break;
            }
            regularRatingBeforeRegex += c;
        }
        Match mRating = ratingRegex.Match(regularRatingBeforeRegex);
        return mRating.Value;
    }

    public static string GetRegularRatingDateUpdated(string rawRegularRating)
    {
        Regex dateRegex = new Regex("([0-9]{4}-[0-9]{2})");
        Match mDate = dateRegex.Match(rawRegularRating);
        return mDate.Value;
    }
}
