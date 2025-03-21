
using HtmlAgilityPack;
using System.Diagnostics.Metrics;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;


var html = @"https://www.uschess.org/msa/MbrDtlMain.php?";
string memberId = "15827994";
HtmlWeb web = new HtmlWeb();
var htmlDoc = web.Load(html + memberId);

HtmlNodeCollection valueNodes = htmlDoc.DocumentNode.SelectNodes("//b");

//int counter = 0;
//foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//b"))
//{
//    Console.WriteLine(counter + ": " + node.InnerHtml);
//    counter++;
//}


//int counter = 1;
//foreach (var nNode in tableNode.Descendants())
//{

//    if (nNode.NodeType == HtmlNodeType.Element)
//    {
//        Console.WriteLine(counter + ": " + nNode.InnerHtml);
//        counter++;
//    }
//}

string regularRatingRaw = valueNodes[2].ChildNodes[0].InnerHtml;
string quickRatingRaw = valueNodes[3].ChildNodes[0].InnerHtml;
Regex ratingRegex = new Regex("([0-9]{3,4})");
Regex dateRegex = new Regex("([0-9]{4}-[0-9]{2})");
Match mDate = dateRegex.Match(regularRatingRaw);
string dateUpdated = mDate.Value;
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
string regularRating = mRating.Value;

// TODO scrape and init more variables for each type of rating on homepage
//string quickRating = regRatingNode.NextSibling.NextSibling.ChildNodes[0].InnerHtml;

Console.WriteLine("REGULAR RATING: " + regularRating);
Console.WriteLine("DATE UPDATED: " + dateUpdated);
//Console.WriteLine(quickRating);
