using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp.Models;
using WpfApp.ViewModel;

namespace WpfApp.Views
{
    /// <summary>
    /// Interaction logic for ProductDetailsView.xaml
    /// </summary>
    public partial class ProductDetailsView : Window
    {
        private List<ProductImage> _images;
        private int _currentIndexPath = 0;
        private BitmapImage _currentImage;
        public ProductDetailsView(Product selectedProduct)
        {
            InitializeComponent();
            this.DataContext = new ProductDetailsViewModel(selectedProduct);
            // Initialize fields
            _images = new List<ProductImage>();
            _currentIndexPath = 0;
            _currentImage = new BitmapImage();
            Name.IsReadOnly = true;
            Description.IsReadOnly = true;
            //
            string rateImageSource = "/Images/StarRates/Star_rating_0_of_5.png";
            switch (selectedProduct.Rate)
            {
                case 0:
                    rateImageSource = "/Images/StarRates/Star_rating_0_of_5.png";
                    break;
                case 0.5:
                    rateImageSource = "/Images/StarRates/Star_rating_0.5_of_5.png";
                    break;
                case 1:
                    rateImageSource = "/Images/StarRates/Star_rating_1_of_5.png";
                    break;
                case 1.5:
                    rateImageSource = "/Images/StarRates/Star_rating_1.5_of_5.png";
                    break;
                case 2:
                    rateImageSource = "/Images/StarRates/Star_rating_2_of_5.png";
                    break;
                case 2.5:
                    rateImageSource = "/Images/StarRates/Star_rating_2.5_of_5.png";
                    break;
                case 3:
                    rateImageSource = "/Images/StarRates/Star_rating_3_of_5.png";
                    break;
                case 3.5:
                    rateImageSource = "/Images/StarRates/Star_rating_3.5_of_5.png";
                    break;
                case 4:
                    rateImageSource = "/Images/StarRates/Star_rating_4_of_5.png";
                    break;
                case 4.5:
                    rateImageSource = "/Images/StarRates/Star_rating_4.5_of_5.png";
                    break;
                case 5:
                    rateImageSource = "/Images/StarRates/Star_rating_5_of_5.png";
                    break;
            }
            var uriSource = new Uri($@"/ClientWPF;component{rateImageSource}", UriKind.Relative);
            RateImageSource.Source = new BitmapImage(uriSource);
            // Gallery Logic
            if (selectedProduct.ProductImage.Count() > 0)
            {
                _images.AddRange(selectedProduct.ProductImage);
                imageProduct.ImageSource = ConvertByteArrayToBitMapImage(_images[0].Image);
            }
            else
            {
                // Hide arrows for image gallery and set default image to image source
                prevImage.Visibility = Visibility.Hidden;
                nextImage.Visibility = Visibility.Hidden;
                imageProduct.ImageSource = new BitmapImage(new Uri(@"../../Images/Icons/defaultProductImage.png", UriKind.Relative));
            }

            deleteProductButton.Visibility = Visibility.Collapsed;
            saveChangesButton.Visibility = Visibility.Collapsed;
            AdminStackPanel.Visibility = Visibility.Collapsed;
            this.Height = 840;
            
        }
        private BitmapImage ConvertByteArrayToBitMapImage(byte[] imageByteArray)
        {
            BitmapImage img = new BitmapImage();
            using (MemoryStream memStream = new MemoryStream(imageByteArray))
            {
                img.BeginInit();
                img.CacheOption = BitmapCacheOption.OnLoad;
                img.StreamSource = memStream;
                img.EndInit();
                img.Freeze();
            }
            return img;
        }

        private void prevImage_Click(object sender, RoutedEventArgs e)
        {
            if (_currentIndexPath < _images.Count && _currentIndexPath > 0)
                imageProduct.ImageSource = ConvertByteArrayToBitMapImage(_images[--_currentIndexPath].Image);
            else
            {
                _currentIndexPath = _images.Count - 1;
                imageProduct.ImageSource = ConvertByteArrayToBitMapImage(_images[_currentIndexPath].Image);
            }
        }

        private void nextImage_Click(object sender, RoutedEventArgs e)
        {
            if (_currentIndexPath < _images.Count - 1)
                imageProduct.ImageSource = ConvertByteArrayToBitMapImage(_images[++_currentIndexPath].Image);
            else
            {
                _currentIndexPath = 0;
                imageProduct.ImageSource = ConvertByteArrayToBitMapImage(_images[_currentIndexPath].Image);
            }
        }
    }
}
