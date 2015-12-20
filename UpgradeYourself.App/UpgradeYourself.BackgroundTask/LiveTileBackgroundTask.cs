using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.Web.Syndication;

namespace UpgradeYourself.BackgroundTask
{
    public sealed class LiveTileBackgroundTask : IBackgroundTask
    {

        // Although most HTTP servers do not require User-Agent header, others will reject the request or return 
        // a different response if this header is missing. Use SetRequestHeader() to add custom headers. 
        static string customHeaderName = "User-Agent";
        static string customHeaderValue = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";

        static string textElementName = "text";
        static string feedUrl = @"http://blogs.msdn.com/b/MainFeed.aspx?Type=BlogsOnly";

        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            BackgroundTaskDeferral deferral = taskInstance.GetDeferral();

            var feed = await GetMSDNBlogFeed();

            UpdateTile(feed);

            deferral.Complete();
        }

        private static async Task<SyndicationFeed> GetMSDNBlogFeed()
        {
            SyndicationFeed feed = null;

            try
            {
                SyndicationClient client = new SyndicationClient();
                client.BypassCacheOnRetrieve = true;
                client.SetRequestHeader(customHeaderName, customHeaderValue);

                feed = await client.RetrieveFeedAsync(new Uri(feedUrl));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return feed;
        }

        private static void UpdateTile(SyndicationFeed feed)
        {
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            updater.EnableNotificationQueue(true);
            updater.Clear();

            int itemCount = 0;

            foreach (var item in feed.Items)
            {
                XmlDocument tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWideText03);

                var title = item.Title;
                string titleText = title.Text == null ? String.Empty : title.Text;
                tileXml.GetElementsByTagName(textElementName)[0].InnerText = titleText;
                
                updater.Update(new TileNotification(tileXml));

                if (itemCount++ > 5) break;
            }
        }
    }
}
