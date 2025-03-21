using HtmlAgilityPack;
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
	public HtmlDocument GetMemberHomePage()
	{

        HtmlWeb web = new HtmlWeb();
        HtmlDocument htmlDoc = web.Load(memberHomePage + memberId);
        return htmlDoc;
    }
    public static HtmlNodeCollection getValues()
	{
        return GetMemberHomePage().DocumentNode.SelectNodes("//b");
	}
}
