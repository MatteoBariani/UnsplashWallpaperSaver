using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class UnsplashTopics
    {
        public string id { get; set; }
        public string slug { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public long totalPhotos { get; set; }
    }
    public class UnsplashAPI
    {
        private string baseUrl;
        private string clientKey;
        private string folderPath;
        private string clientIdParam;
        private int photoCount;
        private int perPageCount;
        private string selectedOrientation;
        private string orderBy;
        private static UnsplashAPI api;
        private List<UnsplashTopics> topicsList;
        private List<string> selectedTopics;

        private const string randomPhoto = "/photos/random";
        private const string topics = "/topics";
        private const string photos = "/photos";
        private const string clientParameter = "?client_id=";
        private const string orientation = "&orientation=";
        private const string order_by = "&order_by=";
        private const string per_page = "&per_page=";
        private const string logFile = "\\log.txt";

        private UnsplashAPI()
        {
            baseUrl = Utils.GetSetting("apiUrl");
            clientKey = Utils.GetSetting("apiAccessKey");
            folderPath = Utils.GetSetting("defaultFolder");
            
            string count = Utils.GetSetting("photoCount");
            int.TryParse(count, out photoCount);

            count = Utils.GetSetting("perPageCount");
            int.TryParse(count, out perPageCount);

            orderBy = Utils.GetSetting("sortBy");
            selectedOrientation = Utils.GetSetting("orientation");
            selectedTopics = Utils.GetSetting("topicsSelected").Split(',').ToList();
            clientIdParam = "/" + clientParameter + clientKey;
            topicsList = GetTopicsList();
        }

        public static UnsplashAPI GetInstance()
        {
            if (api == null)
            {
                api = new UnsplashAPI();
            }

            return api;
        }

        private string ComposeUrl(string topic)
        {
            string url = topics;

            UnsplashTopics topicSlug = topicsList.FirstOrDefault(x => x.title == topic);

            if (topicSlug != null)
            {
                url = url + "/" + topicSlug.slug + photos;
            }

            url = url + clientIdParam;

            if (selectedOrientation != string.Empty)
            {
                url = url + orientation + selectedOrientation;
            }

            if (orderBy != string.Empty)
            {
                url = url + order_by + orderBy;
            }

            if (perPageCount > 0)
            {
                url = url + per_page + perPageCount;
            }

            return url;
        }

        public void GetPhotos()
        {
            if (!Directory.Exists(Utils.GetSetting("defaultFolder")))
            {
                MessageBox.Show("Save folder missing in configuration", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (selectedTopics == null || selectedTopics.Count == 0)
            {
                MessageBox.Show("No topics specified in configuration", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var client = new HttpClient { BaseAddress = new Uri(baseUrl) })
                {
                    foreach (string topic in selectedTopics)
                    {
                        string url = ComposeUrl(topic);
                        HttpResponseMessage response = client.GetAsync(url).Result;
                        response.EnsureSuccessStatusCode();
                        string json = response.Content.ReadAsStringAsync().Result;

                        if (!string.IsNullOrEmpty(json))
                        {
                            var res = JsonConvert.DeserializeObject<dynamic>(json);
                            int idx = 0;
                            // default 10 elements from Unsplash
                            foreach (var item in res)
                            {
                                if (IsPictureAlreadySaved(item.id.ToString()))
                                    continue;
                                
                                SaveImage(folderPath + "\\" + Path.GetRandomFileName().Replace(".", string.Empty), item.urls.raw.Value, ImageFormat.Jpeg, item.id.ToString());
                                idx++;

                                if (idx >= photoCount)
                                {
                                    break;
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Runtime error! Error at: " + e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsPictureAlreadySaved(string id)
        {
            string path = folderPath + logFile;

            if (!File.Exists(path))
            {
                return false;
            }

            List<string> lines = File.ReadAllLines(path).ToList();

            string item = lines.FirstOrDefault(x => x == id);

            if (!string.IsNullOrEmpty(item))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void LogPictureId(string id)
        {
            File.AppendAllText(folderPath + logFile, id);
            File.AppendAllText(folderPath + logFile, Environment.NewLine);
        }

        public List<UnsplashTopics> GetTopicsList()
        {
            if (topicsList != null && topicsList.Count > 0)
            {
                return topicsList;
            }

            topicsList = new List<UnsplashTopics>();

            try
            {
                using (var client = new HttpClient { BaseAddress = new Uri(baseUrl) })
                {
                    HttpResponseMessage response = client.GetAsync(topics + clientIdParam).Result;
                    response.EnsureSuccessStatusCode();
                    string json = response.Content.ReadAsStringAsync().Result;

                    if (!string.IsNullOrEmpty(json))
                    {
                        var res = JsonConvert.DeserializeObject<dynamic>(json);

                        foreach (var topic in res)
                        {
                            topicsList.Add(new UnsplashTopics
                            {
                                id = topic.id.Value,
                                slug = topic.slug.Value,
                                title = topic.title.Value,
                                description = topic.description.Value,
                                totalPhotos = topic.total_photos.Value
                            });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Communication error! Error at: " + e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return topicsList;
        }

        public void GetRandomPhoto()
        {
            try
            {
                using (var client = new HttpClient { BaseAddress = new Uri(baseUrl) })
                {
                    HttpResponseMessage response = client.GetAsync(randomPhoto + clientIdParam).Result;
                    response.EnsureSuccessStatusCode();
                    string json = response.Content.ReadAsStringAsync().Result;

                    if (string.IsNullOrEmpty(json))
                    {
                        return;
                    }

                    var res = JsonConvert.DeserializeObject<dynamic>(json);
                    SaveImage(folderPath + "\\" + Path.GetRandomFileName().Replace(".", string.Empty), res.urls.raw.Value, ImageFormat.Jpeg, res.id.ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Communication error! Error at: " + e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SaveImage(string filename, string imageUrl, ImageFormat format, string imageId)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    using (Stream stream = client.OpenRead(imageUrl))
                    {
                        Bitmap bitmap = new Bitmap(stream);

                        if (bitmap != null)
                        {
                            bitmap.Save(filename + ".jpg", format);
                            LogPictureId(imageId);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Communication error! Error at: " + e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
