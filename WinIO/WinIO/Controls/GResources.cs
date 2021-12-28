using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WinIO.Controls
{
    public static class GResources
    {
        public static string AssetPath = "Assets/";
        public static string IconPath = AssetPath + "Icons/";

        private static List<string> _imageStrings = new List<string>
        {
            "folder",
            "medium",
            "plus",
            "ui"
        };

        private static List<Image> _images;

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
            // 在这里获得所有的图片
            if(_images == null)
            {
                _images = new List<Image>();

                foreach (var item in _imageStrings)
                {
                    Image img = new Image() {Source = new BitmapImage(new Uri(IconPath + item + ".png", UriKind.Relative)) };
                    _images.Add(img);
                }
            }
            return _images;
        }
    }
}
