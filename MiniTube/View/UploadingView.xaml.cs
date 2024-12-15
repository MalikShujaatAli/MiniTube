using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Media;
using MiniTube.ModelsEAD;

namespace MiniTube.View
{
    /// <summary>
    /// Interaction logic for UploadingView.xaml
    /// This view allows users to upload videos along with thumbnails and metadata.
    /// </summary>
    public partial class UploadingView : Window
    {
        private byte[]? _thumbnail;
        private byte[]? _video;
        private string? _videoPath;
        private int Id;
        private int Vid;
        private bool edit = false;

        // ----- Constructor -----
        public UploadingView()
        {
            InitializeComponent();
        }

        public UploadingView(int userId)
        {
            InitializeComponent();
            Id = userId;
        }

        public UploadingView(int userId, int videoid)
        {
            InitializeComponent();
            Id = userId;
            Vid = videoid;
            edit = true;
            LoadVideoDetails();
        }

        // ----- Window Mouse Down Event -----
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        // ----- Minimize Button Click -----
        private void btn_minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        // ----- Close Button Click -----
        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // ----- Upload Button Click -----
        private void btn_upload_Click(object sender, RoutedEventArgs e)
        {
            // Validate input and upload video
            if (ValidateInput())
            {
                try
                {
                    UploadVideo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred during upload: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all data.");
            }
        }

        // ----- Validate Input -----
        private bool ValidateInput()
        {
            return _thumbnail != null && _video != null &&
                   !string.IsNullOrEmpty(txt_title.Text) &&
                   !string.IsNullOrEmpty(txt_description.Text) &&
                   !string.IsNullOrEmpty(txt_k1.Text) &&
                   !string.IsNullOrEmpty(txt_k2.Text) &&
                   !string.IsNullOrEmpty(txt_k3.Text);
        }

        // ----- Upload Video to Database -----
        // ----- Upload Video to Database -----
        private void UploadVideo()
        {
            string title = txt_title.Text;
            string description = txt_description.Text;
            string keyword1 = txt_k1.Text;
            string keyword2 = txt_k2.Text;
            string keyword3 = txt_k3.Text;

            using (var context = new MiniTubeContext())
            {
                // Check if user exists
                if (!context.Users.Any(u => u.UserId == Id))
                {
                    MessageBox.Show("The specified User does not exist.");
                    return;
                }

                // Check if video exists
                var video = context.Videos.FirstOrDefault(v => v.VideoId == Vid);

                if (video != null)
                {
                    // Update existing video
                    video.Title = title;
                    video.Description = description;
                    video.Thumbnail = _thumbnail;
                    video.VideoFile = _video;
                    video.Keyword1 = keyword1;
                    video.Keyword2 = keyword2;
                    video.Keyword3 = keyword3;
                    video.UploadDate = DateTime.Now;

                    context.SaveChanges();
                    MessageBox.Show("Video updated successfully!");
                }
                else
                {
                    // Create and save new video
                    video = new Video
                    {
                        UserId = Id,
                        Title = title,
                        Description = description,
                        Thumbnail = _thumbnail,
                        VideoFile = _video,
                        Keyword1 = keyword1,
                        Keyword2 = keyword2,
                        Keyword3 = keyword3,
                        UploadDate = DateTime.Now
                    };

                    context.Videos.Add(video);
                    context.SaveChanges();
                    MessageBox.Show("Video uploaded successfully!");
                }

                ResetForm();
                NavigateToUploadingView();
            }
        }
        // ----- Reset Form Fields -----
        private void ResetForm()
        {
            txt_title.Clear();
            txt_description.Clear();
            txt_k1.Clear();
            txt_k2.Clear();
            txt_k3.Clear();
            _thumbnail = null;
            _video = null;
            _videoPath = string.Empty;
            media_video.Source = null;
            img_thumb.Source = null;
            btn_stack.Visibility = Visibility.Hidden;
        }

        // ----- Navigate to Uploading View -----
        private void NavigateToUploadingView()
        {
            UploadingView uv = new UploadingView(Id);
            uv.Show();
            this.Close();
        }

        // ----- Back Button Click -----
        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to the Studio View
            StudioView studioView = new StudioView(Id);
            studioView.Show();
            this.Close();
        }
        // ----- Thumbnail Upload Button Click -----
        private void btn_thumbupload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg ;*.png"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    _thumbnail = File.ReadAllBytes(openFileDialog.FileName);
                    img_thumb.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                    btn_thumbupload.Opacity = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while uploading the thumbnail: {ex.Message}");
                }
            }
        }

        // ----- Video Upload Button Click -----
        private void btn_vidupload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Video files (*.mp4;*.mov;*.avi)|*.mp4;*.mov;*.avi"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    _video = File.ReadAllBytes(openFileDialog.FileName);
                    _videoPath = openFileDialog.FileName;
                    media_video.Source = new Uri(_videoPath);
                    media_video.LoadedBehavior = MediaState.Manual;
                    media_video.Play();
                    btn_vidupload.Opacity = 0;
                    btn_stack.Visibility = Visibility.Visible;
                    Play.Visibility = Visibility.Hidden;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while uploading the video: {ex.Message}");
                }
            }
        }

        // ----- Play Button Click -----
        private void Play_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                media_video.Play();
                Play.Visibility = Visibility.Hidden;
                Pause.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while playing the video: {ex.Message}");
            }
        }

        // ----- Pause Button Click -----
        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                media_video.Pause();
                Pause.Visibility = Visibility.Hidden;
                Play.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while pausing the video: {ex.Message}");
            }
        }

        // ----- Stop Button Click -----
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                media_video.Stop();
                Pause.Visibility = Visibility.Hidden;
                Play.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while stopping the video: {ex.Message}");
            }
        }

        // ----- Load Video Details -----
        // ----- Load Video Details -----
        private void LoadVideoDetails()
        {
            using (var context = new MiniTubeContext())
            {
                var video = context.Videos.FirstOrDefault(v => v.VideoId == Vid);

                if (video != null)
                {
                    // Log video details
                    Console.WriteLine($"Video found: Title={video.Title}, Description={video.Description}");

                    txt_title.Text = video.Title;
                    txt_description.Text = video.Description;
                    txt_k1.Text = video.Keyword1;
                    txt_k2.Text = video.Keyword2;
                    txt_k3.Text = video.Keyword3;

                    // Load thumbnail
                    if (video.Thumbnail != null && video.Thumbnail.Length > 0)
                    {
                        try
                        {
                            _thumbnail = video.Thumbnail;
                            img_thumb.Source = ConvertByteArrayToBitmapImage(_thumbnail);
                            btn_thumbupload.Opacity = 0;
                            Console.WriteLine("Thumbnail loaded successfully.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error loading thumbnail: {ex.Message}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thumbnail is null or empty.");
                        Console.WriteLine("Thumbnail is null or empty.");
                    }

                    // Load video
                    if (video.VideoFile != null && video.VideoFile.Length > 0)
                    {
                        try
                        {
                            _video = video.VideoFile;
                            var tempFilePath = Path.GetTempFileName();
                            File.WriteAllBytes(tempFilePath, _video);

                            // Check if the video file was saved correctly
                            if (File.Exists(tempFilePath))
                            {
                                media_video.Source = new Uri(tempFilePath);
                                media_video.LoadedBehavior = MediaState.Manual;

                                // Wait for the video file to be loaded before trying to play it
                                media_video.MediaOpened += (sender, e) =>
                                {
                                    media_video.Play();
                                    btn_stack.Visibility = Visibility.Visible;
                                    Play.Visibility = Visibility.Hidden;
                                    Console.WriteLine("Video is playing.");
                                };

                                // Delete the temporary file when the video ends
                                media_video.MediaEnded += (sender, e) =>
                                {
                                    File.Delete(tempFilePath);
                                    Console.WriteLine("Temporary video file deleted.");
                                };
                            }
                            else
                            {
                                MessageBox.Show("Error saving video file to temporary location.");
                                Console.WriteLine("Error saving video file to temporary location.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error loading video: {ex.Message}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Video file is null or empty.");
                        Console.WriteLine("Video file is null or empty.");
                    }
                }
                else
                {
                    MessageBox.Show("Video not found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Console.WriteLine("Video not found in the database.");
                }
            }
        }        // ----- Convert Byte Array to Bitmap Image -----
        private BitmapImage ConvertByteArrayToBitmapImage(byte[] array)
        {
            using (var ms = new MemoryStream(array))
            {
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = ms;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }
    }
}