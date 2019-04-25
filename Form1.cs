using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;

namespace Metadata
{
    public partial class Form1 : Form
    {
        ShellObject myFile;
        List<DataGridView> gridViews;

        public Form1()
        {
            InitializeComponent();

            gridViews = new List<DataGridView>()
            {
                AllDataGridView,
                ImageDataGridView,
                AudioDataGridView,
                VideoDataGridView,
                OtherDataGridView
            };
        }

        // Image
        private List<MyProperty> GetImageProperties()
        {
            List<MyKey> keys = new List<MyKey>()
            {
                new MyKey(SystemProperties.System.Image.BitDepth, "Bit Depth"),
                new MyKey(SystemProperties.System.Image.ColorSpace, "Color Space"),
                new MyKey(SystemProperties.System.Image.CompressedBitsPerPixel, "Compressed Bits Per Pixel"),
                new MyKey(SystemProperties.System.Image.Compression, "Compression"),
                new MyKey(SystemProperties.System.Image.Dimensions, "Dimensions"),
                new MyKey(SystemProperties.System.Image.HorizontalResolution, "Horizontal Resolution"),
                new MyKey(SystemProperties.System.Image.HorizontalSize, "Horizontal Size"),
                new MyKey(SystemProperties.System.Image.ResolutionUnit, "Resolution Unit"),
                new MyKey(SystemProperties.System.Image.VerticalResolution, "Vertical Resolution"),
                new MyKey(SystemProperties.System.Image.VerticalSize, "Vertical Size"),
            };

            return GetProperties(keys);
        }
        private List<MyProperty> GetPhotoProperties()
        {
            List<MyKey> keys = new List<MyKey>()
            {
                new MyKey(SystemProperties.System.Photo.Aperture, "Aperture"),
                new MyKey(SystemProperties.System.Photo.Brightness, "Brightness"),
                new MyKey(SystemProperties.System.Photo.CameraManufacturer, "Camera Manufacturer"),
                new MyKey(SystemProperties.System.Photo.CameraModel, "Camera Model"),
                new MyKey(SystemProperties.System.Photo.CameraSerialNumber, "Camera Serial Number"),
                new MyKey(SystemProperties.System.Photo.Contrast, "Contrast"),
                new MyKey(SystemProperties.System.Photo.DateTaken, "Date Taken"),
                new MyKey(SystemProperties.System.Photo.DigitalZoom, "Digital Zoom"),
                new MyKey(SystemProperties.System.Photo.Event, "Event"),
                new MyKey(SystemProperties.System.Photo.ExposureBias, "Exposure Bias"),
                new MyKey(SystemProperties.System.Photo.ExposureIndex, "Exposure Index"),
                new MyKey(SystemProperties.System.Photo.ExposureProgram, "Exposure Program"),
                new MyKey(SystemProperties.System.Photo.ExposureTime, "Exposure Time"),
                new MyKey(SystemProperties.System.Photo.Flash, "Flash"),
                new MyKey(SystemProperties.System.Photo.FNumber, "FNumber"),
                new MyKey(SystemProperties.System.Photo.FocalLength, "Focal Length"),
                new MyKey(SystemProperties.System.Photo.GainControl, "Gain Control"),
                new MyKey(SystemProperties.System.Photo.LensManufacturer, "Lens Manufacturer"),
                new MyKey(SystemProperties.System.Photo.LensModel, "Lens Model"),
                new MyKey(SystemProperties.System.Photo.MaxAperture, "Max Aperture"),
                new MyKey(SystemProperties.System.Photo.Orientation, "Orientation"),
                new MyKey(SystemProperties.System.Photo.ProgramMode, "Program Mode"),
                new MyKey(SystemProperties.System.Photo.Saturation, "Saturation"),
                new MyKey(SystemProperties.System.Photo.Sharpness, "Sharpness"),
                new MyKey(SystemProperties.System.Photo.ShutterSpeed, "Shutter Speed")
            };

            return GetProperties(keys);
        }
        private List<MyProperty> GetGPSProperties()
        {
            List<MyKey> keys = new List<MyKey>()
            {
                new MyKey(SystemProperties.System.GPS.Altitude, "Altitude"),
                new MyKey(SystemProperties.System.GPS.AreaInformation, "Area Information"),
                new MyKey(SystemProperties.System.GPS.Date, "Date"),
                new MyKey(SystemProperties.System.GPS.DestinationBearing, "Destination Bearing"),
                new MyKey(SystemProperties.System.GPS.DestinationDistance, "Destination Distance"),
                new MyKey(SystemProperties.System.GPS.DestinationLatitude, "Destination Latitude"),
                new MyKey(SystemProperties.System.GPS.DestinationLongitude, "Destination Longitude"),
                new MyKey(SystemProperties.System.GPS.Differential, "Differential"),
                new MyKey(SystemProperties.System.GPS.DOP, "DOP"),
                new MyKey(SystemProperties.System.GPS.ImageDirection, "Image Direction"),
                new MyKey(SystemProperties.System.GPS.Latitude, "Latitude"),
                new MyKey(SystemProperties.System.GPS.Longitude, "Longitude"),
                new MyKey(SystemProperties.System.GPS.MapDatum, "Map Datum"),
                new MyKey(SystemProperties.System.GPS.MeasureMode, "Measure Mode"),
                new MyKey(SystemProperties.System.GPS.ProcessingMethod, "Processing Method"),
                new MyKey(SystemProperties.System.GPS.Satellites, "Satellites"),
                new MyKey(SystemProperties.System.GPS.Speed, "Speed"),
                new MyKey(SystemProperties.System.GPS.Status, "Status"),
                new MyKey(SystemProperties.System.GPS.Track, "Track"),
                new MyKey(SystemProperties.System.GPS.VersionID, "Version ID")
            };

            return GetProperties(keys);
        }
        // Video
        private List<MyProperty> GetVideoProperties()
        {
            List<MyKey> keys = new List<MyKey>()
            {
                new MyKey(SystemProperties.System.Video.Compression, "Compression"),
                new MyKey(SystemProperties.System.Video.Director, "Director"),
                new MyKey(SystemProperties.System.Video.EncodingBitrate, "Encoding Bitrate"),
                new MyKey(SystemProperties.System.Video.FrameHeight, "Frame Height"),
                new MyKey(SystemProperties.System.Video.FrameRate, "Frame Rate"),
                new MyKey(SystemProperties.System.Video.FrameWidth, "Frame Width"),
                new MyKey(SystemProperties.System.Video.SampleSize, "Sample Size"),
                new MyKey(SystemProperties.System.Video.StreamName, "Stream Name"),
                new MyKey(SystemProperties.System.Video.StreamNumber, "Stream Number"),
                new MyKey(SystemProperties.System.Video.TotalBitrate, "Total Bitrate"),
                new MyKey(SystemProperties.System.Video.TranscodedForSync, "Transcoded For Sync"),
                new MyKey(SystemProperties.System.Video.VerticalAspectRatio, "Vertical Aspect Ratio")
            };

            return GetProperties(keys);
        }
        // Audio
        private List<MyProperty> GetAudioProperties()
        {
            List<MyKey> keys = new List<MyKey>()
            {
                new MyKey(SystemProperties.System.Audio.ChannelCount, "Channel Count"),
                new MyKey(SystemProperties.System.Audio.Compression, "Compression"),
                new MyKey(SystemProperties.System.Audio.EncodingBitrate, "Encoding Bitrate"),
                new MyKey(SystemProperties.System.Audio.Format, "Format"),
                new MyKey(SystemProperties.System.Audio.IsVariableBitrate, "Is Variable Bitrate"),
                new MyKey(SystemProperties.System.Audio.PeakValue, "Peak Value"),
                new MyKey(SystemProperties.System.Audio.SampleRate, "Sample Rate"),
                new MyKey(SystemProperties.System.Audio.SampleSize, "Sample Size"),
                new MyKey(SystemProperties.System.Audio.StreamName, "Stream Name"),
                new MyKey(SystemProperties.System.Audio.StreamNumber, "Stream Number")
            };

            return GetProperties(keys);
        }
        private List<MyProperty> GetMusicProperties()
        {
            List<MyKey> keys = new List<MyKey>()
            {
                new MyKey(SystemProperties.System.Music.AlbumArtist, "Album Artist"),
                new MyKey(SystemProperties.System.Music.AlbumID, "Album ID"),
                new MyKey(SystemProperties.System.Music.AlbumTitle, "Album Title"),
                new MyKey(SystemProperties.System.Music.Artist, "Artist"),
                new MyKey(SystemProperties.System.Music.BeatsPerMinute, "Beats per Minute"),
                new MyKey(SystemProperties.System.Music.Composer, "Composer"),
                new MyKey(SystemProperties.System.Music.Conductor, "Conductor"),
                new MyKey(SystemProperties.System.Music.DisplayArtist, "Display Artist"),
                new MyKey(SystemProperties.System.Music.Genre, "Genre"),
                new MyKey(SystemProperties.System.Music.IsCompilation, "Is Compilation"),
                new MyKey(SystemProperties.System.Music.Lyrics, "Lyrics"),
                new MyKey(SystemProperties.System.Music.Mood, "Mood"),
                new MyKey(SystemProperties.System.Music.PartOfSet, "Part of Set"),
                new MyKey(SystemProperties.System.Music.Period, "Period"),
                new MyKey(SystemProperties.System.Music.TrackNumber, "Track Number")
            };

            return GetProperties(keys);
        }
        // Other
        private List<MyProperty> GetDocumentProperties()
        {
            List<MyKey> keys = new List<MyKey>()
            {
                new MyKey(SystemProperties.System.Document.ByteCount, "Byte Count"),
                new MyKey(SystemProperties.System.Document.CharacterCount, "Character Count"),
                new MyKey(SystemProperties.System.Document.Contributor, "Contributor"),
                new MyKey(SystemProperties.System.Document.DateCreated, "Date Created"),
                new MyKey(SystemProperties.System.Document.DatePrinted, "Date Printed"),
                new MyKey(SystemProperties.System.Document.DateSaved, "Date Saved"),
                new MyKey(SystemProperties.System.Document.Division, "Division"),
                new MyKey(SystemProperties.System.Document.LastAuthor, "Last Author"),
                new MyKey(SystemProperties.System.Document.LineCount, "Line Count"),
                new MyKey(SystemProperties.System.Document.Manager, "Manager"),
                new MyKey(SystemProperties.System.Document.NoteCount, "Note Count"),
                new MyKey(SystemProperties.System.Document.PageCount, "Page Count"),
                new MyKey(SystemProperties.System.Document.ParagraphCount, "Paragraph Count"),
                new MyKey(SystemProperties.System.Document.PresentationFormat, "Presentation Format"),
                new MyKey(SystemProperties.System.Document.RevisionNumber, "Revision Number"),
                new MyKey(SystemProperties.System.Document.Security, "Security"),
                new MyKey(SystemProperties.System.Document.SlideCount, "Slide Count"),
                new MyKey(SystemProperties.System.Document.Template, "Template"),
                new MyKey(SystemProperties.System.Document.TotalEditingTime, "Total Editing Time"),
                new MyKey(SystemProperties.System.Document.Version, "Version"),
                new MyKey(SystemProperties.System.Document.WordCount, "Word Count")
            };

            return GetProperties(keys);
        }
        private List<MyProperty> GetDRMProperties()
        {
            List<MyKey> keys = new List<MyKey>()
            {
                new MyKey(SystemProperties.System.DRM.DatePlayExpires, "Date Play Expires"),
                new MyKey(SystemProperties.System.DRM.DatePlayStarts, "Date Play Starts"),
                new MyKey(SystemProperties.System.DRM.Description, "Description"),
                new MyKey(SystemProperties.System.DRM.IsProtected, "Is Protected"),
                new MyKey(SystemProperties.System.DRM.PlayCount, "Play Count")
            };

            return GetProperties(keys);
        }
        private List<MyProperty> GetMediaProperties()
        {
            List<MyKey> keys = new List<MyKey>()
            {
                new MyKey(SystemProperties.System.Media.AuthorUrl, "Author URL"),
                new MyKey(SystemProperties.System.Media.AverageLevel, "Average Level"),
                new MyKey(SystemProperties.System.Media.ContentDistributor, "Content Distributor"),
                new MyKey(SystemProperties.System.Media.CreatorApplication, "Creator Application"),
                new MyKey(SystemProperties.System.Media.CreatorApplicationVersion, "Creator Application Version"),
                new MyKey(SystemProperties.System.Media.DateEncoded, "Date Encoded"),
                new MyKey(SystemProperties.System.Media.DateReleased, "Date Released"),
                new MyKey(SystemProperties.System.Media.Duration, "Duration"),
                new MyKey(SystemProperties.System.Media.EncodedBy, "Encoded By"),
                new MyKey(SystemProperties.System.Media.EncodingSettings, "Encoding Settings"),
                new MyKey(SystemProperties.System.Media.FrameCount, "Frame Count"),
                new MyKey(SystemProperties.System.Media.Producer, "Producer"),
                new MyKey(SystemProperties.System.Media.ProtectionType, "Protection Type"),
                new MyKey(SystemProperties.System.Media.ProviderRating, "Provider Rating"),
                new MyKey(SystemProperties.System.Media.Publisher, "Publisher"),
                new MyKey(SystemProperties.System.Media.Subtitle, "Subtitle"),
                new MyKey(SystemProperties.System.Media.UserWebUrl, "User Web URL"),
                new MyKey(SystemProperties.System.Media.Writer, "Writer"),
                new MyKey(SystemProperties.System.Media.Year, "Year")
            };

            return GetProperties(keys);
        }

        private List<MyProperty> GetProperties(List<MyKey> keys)
        {
            if (myFile != null && keys.Count > 0)
            {
                List<MyProperty> properties = new List<MyProperty>();

                foreach (MyKey key in keys)
                {
                    var prop = myFile.Properties.GetProperty(key.Key).ValueAsObject;

                    if (prop != null)
                    {
                        string name = key.Name;
                        string value = "";

                        Console.WriteLine(name + ": " + prop.ToString());

                        if (key.Key == SystemProperties.System.GPS.Latitude || key.Key == SystemProperties.System.GPS.Longitude)
                        {
                            double[] val = (double[])prop;

                            value = val[0].ToString() + "; " + val[1].ToString() + "; " + val[2].ToString();
                        }
                        else if (key.Key == SystemProperties.System.Music.Artist || key.Key == SystemProperties.System.Music.Genre)
                        {
                            string[] val = (string[])prop;

                            value = val[0];
                        }
                        else if (key.Key == SystemProperties.System.Photo.ExposureTime)
                        {
                            double time = 0;
                            double.TryParse(prop.ToString(), out time);
                            value = "1/" + (1 / time) + " sec.";
                        }
                        else if (key.Key == SystemProperties.System.Media.Duration)
                        {
                            double length = 0;
                            double.TryParse(prop.ToString(), out length);

                            double lengthInSeconds = length / (Math.Pow(10, 7));
                            TimeSpan t = TimeSpan.FromSeconds(lengthInSeconds);

                            value = t.ToString(@"hh\:mm\:ss\:fff");
                        }
                        else
                        {
                            value = prop.ToString();
                        }

                        MyProperty newProperty = new MyProperty(name, value);
                        properties.Add(newProperty);
                    }
                }

                return properties;

                //foreach (PropertyInfo prop in file.GetType().GetProperties())
                //{
                //    Console.WriteLine(prop.Name);
                //}

                //foreach (PropertyInfo prop in typeof(SystemProperties.System.Photo).GetProperties())
                //{
                //    Console.WriteLine(prop.Name);

                //    Console.WriteLine();
                //}
            }
            else
            {
                return new List<MyProperty>();
            }
        }

        private void GetFileProperties()
        {
            ClearGridViews();

            List<MyProperty> ImageProperties = GetImageProperties();
            List<MyProperty> PhotoProperties = GetPhotoProperties();
            List<MyProperty> GPSProperties = GetGPSProperties();

            List<MyProperty> VideoProperties = GetVideoProperties();

            List<MyProperty> AudioProperties = GetAudioProperties();
            List<MyProperty> MusicProperties = GetMusicProperties();

            List<MyProperty> DocumentProperties = GetDocumentProperties();
            List<MyProperty> DRMProperties = GetDRMProperties();
            List<MyProperty> MediaProperties = GetMediaProperties();

            PopulateGridView(ImageDataGridView, PhotoProperties);
            PopulateGridView(ImageDataGridView, ImageProperties);
            PopulateGridView(ImageDataGridView, GPSProperties);

            PopulateGridView(VideoDataGridView, VideoProperties);

            PopulateGridView(AudioDataGridView, AudioProperties);
            PopulateGridView(AudioDataGridView, MusicProperties);

            PopulateGridView(OtherDataGridView, DocumentProperties);
            PopulateGridView(OtherDataGridView, MediaProperties);
            PopulateGridView(OtherDataGridView, DRMProperties);

            foreach (DataGridView gridView in gridViews)
            {
                foreach (DataGridViewRow row in gridView.Rows)
                {
                    AllDataGridView.Rows.Add(row.Cells[0].Value, row.Cells[1].Value);
                }

            }

            AllDataGridView.Sort(AllDataGridView.Columns[0], ListSortDirection.Ascending);
        }

        private void PopulateGridView(DataGridView dataGridView, List<MyProperty> properties)
        {
            foreach (MyProperty property in properties)
            {
                bool containsRow = false;
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (row.Cells[0].Value.ToString() == property.Name)
                    {
                        containsRow = true;
                        break;
                    }
                }

                if (!containsRow)
                    dataGridView.Rows.Add(property.Name, property.Value);
            }

            dataGridView.Sort(dataGridView.Columns[0], ListSortDirection.Ascending);
        }
        private void ClearGridViews()
        {
            foreach (DataGridView gridView in gridViews)
            {
                gridView.Rows.Clear();
            }
        }
        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filepath = openFileDialog1.FileName;
                FilePathTextbox.Text = filepath;

                myFile = ShellObject.FromParsingName(filepath);

                GetFileProperties();
            }
        }
    }
}
