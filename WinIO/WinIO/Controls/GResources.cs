using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WinIO.Controls
{
    public static class GResources
    {
        public static string AssetPath = "/Assets/";
        public static string IconPath = AssetPath + "Icons/";
        public static IEnumerable<Image> Images => GetImages();

        private static List<string> _imageStrings = new List<string>
        {
            "folder",
            "medium",
            "plus",
            "ui"
        };

        private static Dictionary<string, Image> _images;

        private static Dictionary<string, Image> GetImageDict()
        {
            // 在这里获得所有的图片
            if(_images == null)
            {
                _images = new Dictionary<string, Image>();

                foreach (var item in _imageStrings)
                {
                    Image img = new Image() {Source = new BitmapImage(new Uri(IconPath + item + ".png", UriKind.Relative)) };
                    _images.Add(item, img);
                }
            }
            return _images;
        }

        public static IEnumerable<string> GetImageStrings()
        {
            return _imageStrings;
        }

        public static string GetImageStringPath(string str)
        {
            return IconPath + str;
        }

        public static IEnumerable<Image> GetImages()
        {
            var images = GetImageDict();
            return images.Values.ToList();
        }

        public static Image GetImage(string name)
        {
            var images = GetImageDict();
            Image outImage;
            images.TryGetValue(name, out outImage);
            return outImage;
        }

        public static Image GetUriImage(string uri)
        {
            Image image = null;
            if (!string.IsNullOrEmpty(uri))
            {
                Uri imageUri;
                if (Uri.IsWellFormedUriString(uri, UriKind.Relative))
                {
                    imageUri = new Uri(uri, UriKind.Relative);
                } else
                {
                    imageUri = new Uri(uri, UriKind.Absolute);
                }

                image = new Image()
                {
                    Source = new BitmapImage(imageUri)
                };
            };
            return image;
        }
    }
}
